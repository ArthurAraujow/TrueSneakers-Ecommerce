using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrueSneakersWeb.Infrastructure;
using TrueSneakersWeb.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TrueSneakersWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UsuariosController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(Usuario usuario)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
                return BadRequest("E-mail já cadastrado.");

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Usuário criado com sucesso!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
            if (usuario == null) return Unauthorized("Usuário ou senha inválidos.");

            var token = GerarToken(usuario);
            return Ok(new { token = token, usuario = usuario.Nome, perfil = usuario.Perfil });
        }

        private string GerarToken(Usuario usuario)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, usuario.Nome), new Claim(ClaimTypes.Role, usuario.Perfil) }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}