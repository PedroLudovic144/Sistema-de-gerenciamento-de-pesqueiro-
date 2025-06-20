namespace MeuPesqueiroAPI.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public double Valor { get; set; }
    public string Fornecedor { get; set; }

    public int PesqueiroId { get; set; }
    public Pesqueiro? Pesqueiro { get; set; }
}
 
