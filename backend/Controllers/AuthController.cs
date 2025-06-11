using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using usuario_sis.Models;
using usuario_sis.Repositories;
using usuario_sis.Services;
using Microsoft.AspNetCore.Authorization;
using System;



namespace usuario_sis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly TokenService _tokenService;

        public AuthController(IUserRepository repository, TokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLogin login)
        {
            var user = await _repository.GetByUsernameAsync(login.Username);
            if (user == null)
                return Unauthorized("Usuário não encontrado");

            if (!BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
                return Unauthorized("Senha inválida");

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}