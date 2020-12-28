using AutoMapper;
using identity_server.web.api.Models;
using identity_server.web.BL.Models;
using identity_server.web.BL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity_server.web.api.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
            this.mapper = mapper;
        }

        [Route("AddUser")]
        [HttpPost]
        public IActionResult AddUser([FromBody] UserData user)
        {
            if (user != null)
            {
                var _user = mapper.Map<UserBL>(user);
                authService.AddUser(_user);
                return Ok(_user);
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
