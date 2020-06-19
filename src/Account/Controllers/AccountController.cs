using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Models;
using Account.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody]User model)
        {
            try
            {
                var service = new UserService();
                var user = service.Authenticate(model.Username, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Usuário ou senha inválidos" });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}