
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjetFinal_Ecommerce.Controllers;
using ProjetFinal_Ecommerce.Database;
using ProjetFinal_Ecommerce.Models;

namespace TestProjet_Commerce
{
    public class UnitTest1
    {
        private Db_CommerceContext _context;
        private ProduitsController _produitsController;
        private void Setup() 
        {
            // Simuler la Bd
            var options = new DbContextOptionsBuilder<Db_CommerceContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new Db_CommerceContext(options);

            _context.DbSet_Produits.AddRange(
                new Produit() { Id = 1, Nom= "Produit1" },
                new Produit() { Id = 2, Nom = "Produit2" }
                );
            _context.SaveChanges();
            _produitsController = new ProduitsController( _context );


            // Simuler une session
            var httpContext = new DefaultHttpContext();
            var session = new Mock<ISession>();
            var sessionStorage = new Dictionary<string, byte[]>();

            // Mock du comportement de Get / Set pour ISession
            session.Setup(s => s.Set(It.IsAny<string>(), It.IsAny<byte[]>()))
                   .Callback<string, byte[]>((key, value) => sessionStorage[key] = value);

            session.Setup(s => s.TryGetValue(It.IsAny<string>(), out It.Ref<byte[]>.IsAny))
                   .Returns((string key, out byte[] value) =>
                   {
                       return sessionStorage.TryGetValue(key, out value);
                   });

            httpContext.Session = session.Object;

            // Injecter le HttpContext simulé
            _produitsController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };


        }
        [Fact]
        public async Task Test_Index_NbProduits()
        {
            Setup();

            var result = await _produitsController.Index(1);

            var viewResult = Assert.IsType<ViewResult>( result );
            var model = Assert.IsType<PaginatedList<Produit>>( viewResult.Model );

            Assert.Equal(2, model.Count);
        }
        [Fact]
        public async Task Test_ValidId_Details() 
        {
            Setup();

            // Act
            var result = await _produitsController.Details(2);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Produit>( viewResult.Model );
            Assert.Equal("Produit2", model.Nom);
        }
    }
}
