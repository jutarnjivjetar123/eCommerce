using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Model;
using eCommerce.Services;
namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected IProductsService _service;
        public ProductsController(
                IProductsService service
               )
        {
            _service = service;
        }


        [HttpGet]
        public List<Products> GetList()
        {

            return _service.GetList();

        }
    }
}
