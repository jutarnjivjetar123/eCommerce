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
    public class BaseCRUDController<TModel, TSearch, TInsert, TUpdate> : BaseController<TModel, TSearch>
        where TSearch : BaseSearchObject
        where TModel : class
    {
        
        protected new ICRUDService<TModel, TSearch, TInsert, TUpdate> _service;

        public BaseCRUDController(ICRUDService<TModel, TSearch, TInsert, TUpdate> service) : base(service)
        {
           _service = service;
        }

        [HttpPost]
        public TModel Insert(TInsert request)
        {
               return _service.Insert(request);
        }

        [HttpPut("{id:int}")]
        public TModel Update([FromRoute] int id, TUpdate request)
        {

            return _service.Update(id, request);
        }
    }
}
