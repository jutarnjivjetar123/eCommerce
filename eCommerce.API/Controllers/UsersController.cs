using eCommerce.Model;
using eCommerce.Model.Requests;
using eCommerce.Model.SearchObjects;
using eCommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(
            IUsersService service
        ) : ControllerBase
    {
        private readonly IUsersService _service = service;


        [HttpGet]
        public PagedResult<Model.Users> GetList([FromQuery] UsersSearchObject searchObject) {

            return _service.GetList(searchObject);
        }

        [HttpPost]
        public Model.Users Insert(UsersInsertRequest request) {
            return _service.Insert(request);
        }

        [HttpPut("{id:int}")]
        public Model.Users Update([FromRoute] int id, UsersUpdateRequest request) {

            return _service.Update(id, request);
        }
    }



}
