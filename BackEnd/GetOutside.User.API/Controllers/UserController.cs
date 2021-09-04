using GetOutside.User.Domain.In;
using GetOutside.User.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOutside.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UserCreateIn userCreateIn)
        {
            var userWasInsert = await _userService.Insert(userCreateIn);

            if (userWasInsert)
            {
                return Created("User/Insert", userWasInsert);
            }
            else
            {
                return Ok();
            }
        }
    }
}
