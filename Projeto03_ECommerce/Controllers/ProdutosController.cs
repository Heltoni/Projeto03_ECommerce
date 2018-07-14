using Projeto03_ECommerce.DB;
using Projeto03_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto03_ECommerce.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incluir()
        {
            return View();
        }
                
        [HttpPost]
        public ActionResult Incluir(Produto produto)
        {
            if (ModelState.IsValid)
            {
                ProdutoDB.IncluirProduto(produto);
                return RedirectToAction("Listar");
            }

            return View();

        }

        public ActionResult Listar()
        {
            return View(ProdutoDB.ListarProduto());
        }
        
        public ActionResult Detalhar(int? id)
        {
            if (id == null)
            {
                ViewBag.MensagemErro = "Nenhum parâmetro informado na URL!";
                return View("Erro");
            }

            var produto = ProdutoDB.BuscarProduto(id);

            if (produto == null)
            {
                ViewBag.MensagemErro = "Produto não encontrado!";
                return View("Erro");
            }

            return View(produto);

        }
    }
}