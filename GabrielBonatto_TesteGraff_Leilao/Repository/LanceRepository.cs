using GabrielBonatto_TesteGraff_Leilao.DTO;
using GabrielBonatto_TesteGraff_Leilao.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GabrielBonatto_TesteGraff_Leilao.Repository
{
  public class LanceRepository : AbstractRepository<Lance, int>
  {
    public override void Delete(Lance entity)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "DELETE Leilao.Lance Where Id=@Id";
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
        string sql = "DELETE Leilao.Lance Where Id=@Id";
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
    public List<LanceGridDTO> GetAll(string nomePessoa)
    {
      string sql = "Select a.Id, a.Valor, b.Nome as PessoaNome, c.Nome as ProdutoNome FROM Leilao.Lance a JOIN Leilao.Pessoa b ON a.PessoaId = b.Id JOIN Leilao.Produto c ON a.ProdutoId = c.Id";

      if (!nomePessoa.IsNullOrWhiteSpace())
        sql += " WHERE b.Nome like '%" + nomePessoa + "%' ORDER BY b.Nome;";
      else
        sql += " ORDER BY b.Nome;";

      using (var conn = new SqlConnection(StringConnection))
      {
        var cmd = new SqlCommand(sql, conn);
        List<LanceGridDTO> list = new List<LanceGridDTO>();
        LanceGridDTO p = null;
        try
        {
          conn.Open();
          using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
          {
            while (reader.Read())
            {
              p = new LanceGridDTO();
              p.Id = (int)reader["Id"];
              p.PessoaNome = reader["PessoaNome"].ToString();
              p.ProdutoNome = reader["ProdutoNome"].ToString();
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

    public override List<Lance> GetAll() => throw new NotImplementedException();

    public override Lance GetById(int id)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "Select Id, PessoaId, ProdutoId, Valor FROM Leilao.Lance WHERE Id=@Id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        Lance p = null;
        try
        {
          conn.Open();
          using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
          {
            if (reader.HasRows)
            {
              if (reader.Read())
              {
                p = new Lance();
                p.Id = (int)reader["Id"];
                p.PessoaId = (int)reader["PessoaId"];
                p.ProdutoId = (int)reader["ProdutoId"];
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
    public override void Save(Lance entity)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "INSERT INTO Leilao.Lance (PessoaId, ProdutoId, Valor) VALUES (@PessoaId, @ProdutoId, @Valor)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@PessoaId", entity.PessoaId);
        cmd.Parameters.AddWithValue("@ProdutoId", entity.ProdutoId);
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
    public override void Update(Lance entity)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "UPDATE Leilao.Lance SET PessoaId=@PessoaId, ProdutoId=@ProdutoId Where Id=@Id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", entity.Id);
        cmd.Parameters.AddWithValue("@PessoaId", entity.PessoaId);
        cmd.Parameters.AddWithValue("@ProdutoId", entity.ProdutoId);
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
    public List<Lance> GetAllByProdutoId(int id)
    {
      using (var conn = new SqlConnection(StringConnection))
      {
        string sql = "Select Id, PessoaId, ProdutoId, Valor FROM Leilao.Lance WHERE ProdutoId=@Id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        List<Lance> p = new List<Lance>();
        try
        {
          conn.Open();
          using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
          {
            if (reader.HasRows)
            {
              if (reader.Read())
              {
                p.Add(new Lance
                {
                  Id = (int)reader["Id"],
                  PessoaId = (int)reader["PessoaId"],
                  ProdutoId = (int)reader["ProdutoId"],
                  Valor = (decimal)reader["Valor"]
                });
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
  }
}