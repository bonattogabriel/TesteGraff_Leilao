using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GabrielBonatto_LeilaoGraff.Models
{
  public class Produto
  {
    public long Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }

    public Produto(
      long id,
      string nome,
      decimal valor)
    {
      Id = id;
      Nome = nome ?? throw new ArgumentNullException(nameof(nome));
      Valor = valor;
    }

    public override bool Equals(object obj) => obj is Produto produto && Id == produto.Id && Nome == produto.Nome && Valor == produto.Valor;

    public override int GetHashCode()
    {
      int hashCode = -747438927;
      hashCode = hashCode * -1521134295 + Id.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
      hashCode = hashCode * -1521134295 + Valor.GetHashCode();
      return hashCode;
    }
  }
}