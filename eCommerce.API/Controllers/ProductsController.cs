using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Model;
using eCommerce.Services;
using eCommerce.Model.SearchObjects;
namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<Products, ProductsSearchObject>
    {
        public ProductsController(IService<Products, ProductsSearchObject> service) : base(service)
        {
        }
    }
}
