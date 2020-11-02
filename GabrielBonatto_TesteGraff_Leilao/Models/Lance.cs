using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GabrielBonatto_TesteGraff_Leilao.Models
{
  public class Lance
  {
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public int ProdutoId { get; set; }
    public int PessoaId { get; set; }
  }
}