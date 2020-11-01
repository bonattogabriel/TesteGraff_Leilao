using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GabrielBonatto_LeilaoGraff.Models
{
  public class Pessoa
  {
    public long Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa(
      int id,
      string nome,
      int idade)
    {
      Id = id;
      Nome = nome ?? throw new ArgumentNullException(nameof(nome));
      Idade = idade;
    }

    public override bool Equals(object obj) => obj is Pessoa pessoa && Id == pessoa.Id && Nome == pessoa.Nome && Idade == pessoa.Idade;

    public override int GetHashCode()
    {
      int hashCode = -983755712;
      hashCode = hashCode * -1521134295 + Id.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
      hashCode = hashCode * -1521134295 + Idade.GetHashCode();
      return hashCode;
    }
  }
}