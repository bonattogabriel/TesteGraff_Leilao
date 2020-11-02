using GabrielBonatto_TesteGraff_Leilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GabrielBonatto_TesteGraff_Leilao.DTO
{
  public class LanceGridDTO
  {
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public int PessoaId { get; set; }
    public string PessoaNome { get; set; }
    public int ProdutoId { get; set; }
    public string ProdutoNome { get; set; }
    public IEnumerable<Pessoa> Pessoas { get; set; }
    public IEnumerable<Produto> Produtos { get; set; }
  }
}