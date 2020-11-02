using GabrielBonatto_TesteGraff_Leilao.Models;
using GabrielBonatto_TesteGraff_Leilao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GabrielBonatto_TesteGraff_Leilao.Controllers
{
  public class PessoaController : Controller
  {
    private PessoaRepository repository = new PessoaRepository();

    public ActionResult IndexPessoa()
    {
      return View(repository.GetAll());
    }

    public ActionResult CadPessoa()
    {
      return View();
    }

    [HttpPost]
    public ActionResult CadPessoa(Pessoa pessoa)
    {
      if (ModelState.IsValid)
      {
        repository.Save(pessoa);
        return RedirectToAction("IndexPessoa");
      }
      else
      {
        return View(pessoa);
      }
    }

    public ActionResult CadPessoaAlterar(int id)
    {
      var pessoa = repository.GetById(id);

      if (pessoa == null)
      {
        return HttpNotFound();
      }

      return View(pessoa);
    }

    [HttpPost]
    public ActionResult Edit(Pessoa pessoa)
    {
      if (ModelState.IsValid)
      {
        repository.Update(pessoa);
        return RedirectToAction("IndexPessoa");
      }
      else
      {
        return View(pessoa);
      }
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
      repository.DeleteById(id);
      return Json(repository.GetAll());
    }
  }
}
