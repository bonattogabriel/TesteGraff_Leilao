using GabrielBonatto_TesteGraff_Leilao.DTO;
using GabrielBonatto_TesteGraff_Leilao.Models;
using GabrielBonatto_TesteGraff_Leilao.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GabrielBonatto_TesteGraff_Leilao.Controllers
{
  public class LanceController : Controller
  {
    private LanceRepository repository = new LanceRepository();
    private PessoaRepository repositoryPessoa = new PessoaRepository();
    private ProdutoRepository repositoryProduto = new ProdutoRepository();
    public ActionResult IndexLance(string filtro)
    {
      ViewData["lstPessoa"] = repositoryPessoa.GetAll();
      ViewData["lstProduto"] = repositoryProduto.GetAll();

      return View(repository.GetAll(filtro));
    }

    public ActionResult CadLance()
    {
      ViewBag.PessoaId = new SelectList(
        repositoryPessoa.GetAll(),
        "Id",
        "Nome"
      );

      ViewBag.ProdutoId = new SelectList(
        repositoryProduto.GetAll(),
        "Id",
        "Nome"
      );

      return View();
    }

    [HttpPost]
    public ActionResult CadLance(LanceGridDTO lanceDTO)
    {
      var lance = new Lance
      {
        PessoaId = lanceDTO.PessoaId,
        ProdutoId = lanceDTO.ProdutoId,
        Valor = lanceDTO.Valor,
      };
      var lstLance = repository.GetAllByProdutoId(lance.ProdutoId);
      if(lstLance.Count > 0)
      {
        foreach (var l in lstLance) { 
          if(l.Valor >= lance.Valor)
          {
            ModelState.AddModelError("Valor", "Existe outro lance igual ou maior com valor de: R$" + l.Valor.ToString());
            return CadLance();
          }
        }
      }

      if (ModelState.IsValid)
      {
        repository.Save(lance);
        return RedirectToAction("IndexLance");
      }
      else
      {
        return View(lance);
      }
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
      repository.DeleteById(id);
      return Json(repository.GetAll(""));
    }
  }
}