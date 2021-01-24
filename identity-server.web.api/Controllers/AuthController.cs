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

        /// <summary>
        /// End-point for create new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("DeleteUser")]
        [HttpDelete]
        public IActionResult DeleteUser([FromBody] Guid userId)
        {
            if (Guid.Empty != userId)
            {
                authService.DeleteUser(userId);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("GetUser")]
        [HttpGet]
        public IActionResult GetUser([FromBody] Guid userId)
        {
            if (Guid.Empty != userId)
            {
                var user = authService.GetUser(userId);
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get list of users
        /// </summary>
        /// <returns></returns>
        [Route("GetUsers")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = authService.GetUsers();
            return Ok(users);
        }


        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody] UserData user)
        {
            if (user != null)
            {
                var _user = mapper.Map<UserBL>(user);
                authService.Login(_user);
                return Ok();
            } 
            else
            {
                return BadRequest();
            }
        }


    }
}
