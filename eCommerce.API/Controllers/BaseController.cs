using eCommerce.Model;
using eCommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TSearch> : ControllerBase 
        where TSearch : BaseSearchObject
    {

        protected new IService<TModel, TSearch> _service;
        public BaseController(
                IService<TModel, TSearch> service
            )
        {
            _service = service;
        }

        [HttpGet]
        public PagedResult<TModel> GetPaged([FromQuery] TSearch searchObject) {

            return _service.GetPaged(searchObject);
        }


        [HttpGet("{id}")]
        public TModel GetById(int id)
        {

            return _service.GetById(id);
        }
    }
}
