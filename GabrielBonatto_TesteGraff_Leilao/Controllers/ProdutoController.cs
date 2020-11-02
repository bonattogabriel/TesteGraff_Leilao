using GabrielBonatto_TesteGraff_Leilao.Models;
using GabrielBonatto_TesteGraff_Leilao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GabrielBonatto_TesteGraff_Leilao.Controllers
{
  public class ProdutoController : Controller
  {
    private ProdutoRepository repository = new ProdutoRepository();
    public ActionResult IndexProduto()
    {
      return View(repository.GetAll());
    }

    public ActionResult CadProduto()
    {
      return View();
    }

    [HttpPost]
    public ActionResult CadProduto(Produto produto)
    {
      if (ModelState.IsValid)
      {
        repository.Save(produto);
        return RedirectToAction("IndexProduto");
      }
      else
      {
        return View(produto);
      }
    }
    public ActionResult CadProdutoAlterar(int id)
    {
      var produto = repository.GetById(id);

      if (produto == null)
      {
        return HttpNotFound();
      }

      return View(produto);
    }

    [HttpPost]
    public ActionResult Edit(Produto produto)
    {
      if (ModelState.IsValid)
      {
        repository.Update(produto);
        return RedirectToAction("IndexProduto");
      }
      else
      {
        return View(produto);
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
