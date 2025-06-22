using Microsoft.AspNetCore.Mvc;
using MeuPesqueiroAPI.Data;
using MeuPesqueiroAPI.Models;

namespace MeuPesqueiroAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }


[HttpPost("produto")]
public IActionResult RegistrarProduto(Produto produto)
{
    var pesqueiroExistente = _context.Pesqueiros.Find(produto.PesqueiroId);
        if (pesqueiroExistente == null)
        {
            return BadRequest($"PesqueiroId {produto.PesqueiroId} não encontrado.");
        }
        else
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

}

    [HttpGet("estoque")]
    public IActionResult ConsultaEstoque()
    {
        var produtos = _context.Produtos
            .Select(p => new { p.Nome, p.Quantidade })
            .ToList();
        return Ok(produtos);
    }

    [HttpPatch("{id}/estoque")]
    public IActionResult AtualizarEstoque(int id, [FromBody] int novaQtd)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null) return NotFound();

        produto.Quantidade = novaQtd;
        _context.SaveChanges();
        return Ok(produto);
    }

    [HttpPost("{id}/venda")]
    public IActionResult RegistraVenda(int id, [FromBody] int qtdVendida)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null || produto.Quantidade < qtdVendida)
            return BadRequest("Estoque insuficiente.");

        produto.Quantidade -= qtdVendida;
        _context.SaveChanges();
        return Ok(produto);
    }
}

