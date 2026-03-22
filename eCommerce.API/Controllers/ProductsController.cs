using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Model;
using eCommerce.Services;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Model.Requests;
namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseCRUDController<Products, ProductsSearchObject, ProductsInsertRequest, ProductsUpdateRequest>
    {
        public ProductsController(IProductsService service) : base(service)
        {
        }
    }
}
