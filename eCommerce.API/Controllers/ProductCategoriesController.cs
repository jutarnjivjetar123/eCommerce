using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Model;
using eCommerce.Services;
using eCommerce.Model.SearchObjects;
namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        protected IProductCategoriesService _service;
        public ProductCategoriesController(
                IProductCategoriesService service
               )
        {
            _service = service;
        }


        [HttpGet]
        public List<ProductCategories> GetList([FromQuery] ProductCategoriesSearchObject searchObject)
        {

            return _service.GetList(searchObject);

        }
    }
}
