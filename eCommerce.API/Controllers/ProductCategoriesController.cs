using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Model;
using eCommerce.Services;
using eCommerce.Model.SearchObjects;
using eCommerce.Model.Requests;
namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : BaseCRUDController<Model.ProductCategories, ProductCategoriesSearchObject, ProductCategoriesUpsertRequest, ProductCategoriesUpsertRequest>
    {
        
        public ProductCategoriesController(
                IProductCategoriesService service
               ) : base(service)
        {
            
        }


        
    }
}
