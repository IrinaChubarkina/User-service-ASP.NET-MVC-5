using MyBase.BLL.Services.UserService;
using MyBase.BLL.Services.UserService.Dto;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyBase.WEB.Controllers.Api
{
    public class UsersController : ApiController 
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/Users/{id}")]
        public async Task<UserDto> Get(int id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);

            return userDto;
        }

        [HttpPost]
        [Route("api/Users")]
        public async Task<int> Create([FromBody]UserDto user)
        {
            return await _userService.CreateUserAsync(user);
        }

        [HttpPut]
        [Route("api/Users")]
        public async Task Edit([FromBody]UserDto user)
        {
            await _userService.UpdateUserAsync(user);
        }

        [HttpDelete]
        [Route("api/Users/{id}")]
        public async Task Delete(int id)
        {
            await _userService.DeleteUserByIdAsync(id);
        }
    }
}
