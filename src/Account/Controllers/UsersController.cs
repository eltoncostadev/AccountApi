using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Data;
using Account.Models;
using Account.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _users;
        private ILogger<IUserRepository> _logger;
        public UsersController(IUserRepository users, ILogger<IUserRepository> logger)
        {
            _users = users;
            _logger = logger;
        }

        // GET api/users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _users.GetAll();
            return Ok(users);
        }

        #region missing404docs
        // GET api/Users/{guid}
        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(typeof(User),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Get(int id)
        {
            var contact = _users.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }
        #endregion

        // POST api/Users
        [HttpPost]
        public IActionResult Post([FromBody]User model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                //
                _users.Add(model);
                //
                return CreatedAtRoute("GetById",
                    new { id = model.UserId }, model);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Application Error: {0}.", ex.Message);
                return Problem(ex.Message, statusCode: 500);
            }
        }

        // PUT api/Users/{guid}
        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            if (ModelState.IsValid && id == user.UserId)
            {
                var contactToUpdate = _users.Get(id);

                if (contactToUpdate != null)
                {
                    _users.Update(user);
                    return NoContent();
                }

                return NotFound();
            }

            return BadRequest();
        }

        // DELETE api/Users/{guid}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(int id)
        {
            var user = _users.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _users.Remove(id);

            return NoContent();
        }

    }
}