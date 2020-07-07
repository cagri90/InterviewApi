using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Model;
using WebApi.Models.Repositories;
using RegisterModel = WebApi.Models.Model.RegisterModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repo;

        public UserController(UserRepository repo)
        {
            _repo = repo; 
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] User model)
        {
            var result = _repo.Login(model.Username,model.Password);
            return Ok(result);
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var result = _repo.Register(model);
            return Ok(result);
        }
    }
}