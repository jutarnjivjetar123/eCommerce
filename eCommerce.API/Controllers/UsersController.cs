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
    public class UsersController : BaseCRUDController<Model.Users, UsersSearchObject, UsersInsertRequest, UsersUpdateRequest>
    {
        

        public UsersController(IUsersService service) : base(service)
        {
        }
    }



}
