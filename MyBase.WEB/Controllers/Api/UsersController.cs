using MyBase.BLL.DTO;
using MyBase.BLL.Services.UserService;
using MyBase.WEB.Controllers.Api.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyBase.WEB.Controllers.Api
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController 
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        [Route("")]
        public async Task<Page> Get([FromUri]int? page, [FromUri]int? size)
        {
            var pageSize = size ?? 10;
            var pageNumber = page ?? 1;
            var users = await _userService.GetListOfUsersAsync(pageSize, pageNumber);

            var result = new Page
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = await _userService.GetCountOfUsersAsync(),
                Users = users
            };
            return result;
        }

        // GET: api/Users/8
        [HttpGet]
        [Route("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            var userDto = await _userService.GetUserAsync(id);

            return userDto;
        }

        // POST: api/Users
        [HttpPost]
        [Route("")]
        public async Task<int> Create([FromBody]UserDTO user)
        {
            return await _userService.CreateUserAsync(user);
        }

        // PUT: api/Users/5
        [HttpPut]
        [Route("")]
        public async Task Edit([FromBody]UserDTO user)
        {
            await _userService.UpdateUserAsync(user);
        }

        // DELETE: api/Users/5
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
        }
    }
}
