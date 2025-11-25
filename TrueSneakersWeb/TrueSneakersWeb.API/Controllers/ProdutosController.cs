using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrueSneakersWeb.Infrastructure;
using TrueSneakersWeb.Domain;
using Microsoft.AspNetCore.Authorization;

namespace TrueSneakersWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // <--- Tranca a porta! Só entra com Token.
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return NotFound();
            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(string nome, string marca, decimal preco, string urlImagem, string tamanhos, int quantidade)
        {
            try
            {
                var produto = new Produto(nome, marca, preco, urlImagem, tamanhos, quantidade);
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return NotFound();
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}