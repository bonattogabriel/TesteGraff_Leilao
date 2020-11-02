using GabrielBonatto_TesteGraff_Leilao.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GabrielBonatto_TesteGraff_Leilao.Repository
{
  public class ProdutoRepository : AbstractRepository<Produto, int>
  {
    public override void Delete(Produto entity)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "DELETE Leilao.Produto Where Id=@Id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", entity.Id);
        try
        {
          conn.Open();
          cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
          throw e;
        }
      }
    }
    public override void DeleteById(int id)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "DELETE Leilao.Produto Where Id=@Id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        try
        {
          conn.Open();
          cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
          throw e;
        }
      }
    }
    public override List<Produto> GetAll()
    {
      string sql = "Select Id, Nome, Valor FROM Leilao.Produto ORDER BY Nome";
      using (var conn = new SqlConnection(StringConnection))
      {
        var cmd = new SqlCommand(sql, conn);
        List<Produto> list = new List<Produto>();
        Produto p = null;
        try
        {
          conn.Open();
          using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
          {
            while (reader.Read())
            {
              p = new Produto();
              p.Id = (int)reader["Id"];
              p.Nome = reader["Nome"].ToString();
              p.Valor = (decimal)reader["Valor"];
              list.Add(p);
            }
          }
        }
        catch (Exception e)
        {
          throw e;
        }
        return list;
      }
    }
    public override Produto GetById(int id)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "Select Id, Nome, Valor FROM Leilao.Produto WHERE Id=@Id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        Produto p = null;
        try
        {
          conn.Open();
          using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
          {
            if (reader.HasRows)
            {
              if (reader.Read())
              {
                p = new Produto();
                p.Id = (int)reader["Id"];
                p.Nome = reader["Nome"].ToString();
                p.Valor = (decimal)reader["Valor"];
              }
            }
          }
        }
        catch (Exception e)
        {
          throw e;
        }
        return p;
      }
    }
    public override void Save(Produto entity)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "INSERT INTO Leilao.Produto (Nome, Valor) VALUES (@Nome, @Valor)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Nome", entity.Nome);
        cmd.Parameters.AddWithValue("@Valor", entity.Valor);

        try
        {
          conn.Open();
          cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
          throw e;
        }
      }
    }
    public override void Update(Produto entity)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "UPDATE Leilao.Produto SET Nome=@Nome, Valor=@Valor Where Id=@Id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", entity.Id);
        cmd.Parameters.AddWithValue("@Nome", entity.Nome);
        cmd.Parameters.AddWithValue("@Valor", entity.Valor);
        try
        {
          conn.Open();
          cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
          throw e;
        }
      }
    }
  }
}