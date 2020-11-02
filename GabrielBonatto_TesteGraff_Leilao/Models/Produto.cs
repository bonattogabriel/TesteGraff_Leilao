using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GabrielBonatto_TesteGraff_Leilao.Models
{
  public class Produto
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo nome é obrigatório!")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo Valor é obrigatório!")]
    public decimal Valor { get; set; }
  }
}