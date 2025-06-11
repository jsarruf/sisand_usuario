using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using usuario_sis.Models;
using usuario_sis.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace usuario_sis.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get() => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            if (string.IsNullOrWhiteSpace(user.Password))
                return BadRequest("Senha é obrigatória");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = null;
            await _repository.AddAsync(user);
            await _repository.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User updated)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();

            user.Username = updated.Username;
            if (!string.IsNullOrWhiteSpace(updated.PasswordHash))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updated.PasswordHash);

            await _repository.UpdateAsync(user);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}