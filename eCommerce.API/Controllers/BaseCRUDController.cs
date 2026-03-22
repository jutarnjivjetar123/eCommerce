using eCommerce.Model;
using eCommerce.Model.Requests;
using eCommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<TModel, TSearch, TInsert, TUpdate>(ICRUDService<TModel, TSearch, TInsert, TUpdate> service) : BaseController<TModel, TSearch>(service)
        where TSearch : BaseSearchObject
        where TModel : class
    {

        [HttpPost]
        public TModel Insert(TInsert request)
        {
               return service.Insert(request);
        }

        [HttpPut("{id:int}")]
        public TModel Update([FromRoute] int id, TUpdate request)
        {

            return service.Update(id, request);
        }
    }
}
