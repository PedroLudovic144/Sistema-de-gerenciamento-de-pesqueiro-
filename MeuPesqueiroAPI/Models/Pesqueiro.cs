 namespace MeuPesqueiroAPI.Models;

public class Pesqueiro
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public List<Produto> Produtos { get; set; }
}

