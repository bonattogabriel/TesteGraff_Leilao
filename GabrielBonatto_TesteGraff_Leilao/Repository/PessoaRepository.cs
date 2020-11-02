using GabrielBonatto_TesteGraff_Leilao.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GabrielBonatto_TesteGraff_Leilao.Repository
{
  public class PessoaRepository : AbstractRepository<Pessoa, int>
  {
    public override void Delete(Pessoa entity)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "DELETE Leilao.Pessoa Where Id=@Id";
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
        string sql = "DELETE Leilao.Pessoa Where Id=@Id";
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
    public override List<Pessoa> GetAll()
    {
      string sql = "Select Id, Nome, Idade FROM Leilao.Pessoa ORDER BY Nome";
      using (var conn = new SqlConnection(StringConnection))
      {
        var cmd = new SqlCommand(sql, conn);
        List<Pessoa> list = new List<Pessoa>();
        Pessoa p = null;
        try
        {
          conn.Open();
          using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
          {
            while (reader.Read())
            {
              p = new Pessoa();
              p.Id = (int)reader["Id"];
              p.Nome = reader["Nome"].ToString();
              p.Idade = (int)reader["Idade"];
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
    public override Pessoa GetById(int id)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "Select Id, Nome, Idade FROM Leilao.Pessoa WHERE Id=@Id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        Pessoa p = null;
        try
        {
          conn.Open();
          using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
          {
            if (reader.HasRows)
            {
              if (reader.Read())
              {
                p = new Pessoa();
                p.Id = (int)reader["Id"];
                p.Nome = reader["Nome"].ToString();
                p.Idade = (int)reader["Idade"];
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
    public override void Save(Pessoa entity)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "INSERT INTO Leilao.Pessoa (Nome, Idade) VALUES (@Nome, @Idade)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Nome", entity.Nome);
        cmd.Parameters.AddWithValue("@Idade", entity.Idade);

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
    public override void Update(Pessoa entity)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "UPDATE Leilao.Pessoa SET Nome=@Nome, Idade=@Idade Where Id=@Id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", entity.Id);
        cmd.Parameters.AddWithValue("@Nome", entity.Nome);
        cmd.Parameters.AddWithValue("@Idade", entity.Idade);
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