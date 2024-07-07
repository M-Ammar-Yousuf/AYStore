using AYStore.Controllers;
using AYStore.Tests.Mocks;
using AYStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AYStore.Tests.Controllers
{
    public class ProductControllerTests
    {
        [Fact]
        public void List_EmptyCategory_Return_AllProducts()
        {
            //arange
            var mockProductRepo = RepositoryMocks.GetProductRepository();
            var mockCategoryRepo = RepositoryMocks.GetCategoryRepository();

            var productController = new ProductController(mockProductRepo.Object, mockCategoryRepo.Object);

            //act
            var result = productController.Index("");

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<ProductListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(6, pieListViewModel.Products.Count());
        }
    }
}
