using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Model;
using eCommerce.Services;
using eCommerce.Model.SearchObjects;
namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : BaseController<Model.ProductCategories, ProductCategoriesSearchObject>
    {
        
        public ProductCategoriesController(
                IProductCategoriesService service
               ) : base(service)
        {
            
        }


        
    }
}
