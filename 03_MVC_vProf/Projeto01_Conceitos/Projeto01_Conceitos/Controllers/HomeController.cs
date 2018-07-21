using Projeto01_Conceitos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto01_Conceitos.Controllers
{
    public class HomeController : Controller
    {
        public string ExibirTexto()
        {
            return "Primeiro exemplo de MVC";
        }

        public Empresa ExibirEmpresa()
        {
            return new Empresa()
            {
                Cnpj = "03734487000124",
                Descricao = "Impacta"
            };
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarPdf()
        {
            return File("~/pdf/VS 2017 - Projeto 01.pdf", "application/pdf");
        }

        public ActionResult LunchBreak()
        {
            return View();
        }

        //actions que transferem objetos para a view
        //Strongly Typed View (View Fortemente Tipada)
        public ActionResult ExibirProduto()
        {
            Produto produto = new Produto()
            {
                Codigo = 1000,
                Descricao = "Bicleta",
                Preco = 1500
            };

            ViewBag.TituloPagina = "Detalhe de um produto";
            return View(produto);
        }

        public ActionResult ListarProdutos()
        {
            List<Produto> produtos = new List<Produto>()
            {
                new Produto(){Codigo = 10, Descricao = "Shampoo", Preco = 20 },
                new Produto(){Codigo = 20, Descricao = "Barbeador", Preco = 10 },
                new Produto(){Codigo = 30, Descricao = "Guarda chuva", Preco = 15 },
                new Produto(){Codigo = 40, Descricao = "Agasalho", Preco = 89 }
            };

            ViewData["TituloLista"] = "Lista Detalhada de Produtos";
            return View(produtos);
        }

        public ActionResult BuscarProduto(int id)
        {
            List<Produto> produtos = new List<Produto>()
            {
                new Produto(){Codigo = 10, Descricao = "Shampoo", Preco = 20 },
                new Produto(){Codigo = 20, Descricao = "Barbeador", Preco = 10 },
                new Produto(){Codigo = 30, Descricao = "Guarda chuva", Preco = 15 },
                new Produto(){Codigo = 40, Descricao = "Agasalho", Preco = 89 }
            };

            Produto produto = produtos.Find(s => s.Codigo == id);

            if(produto != null)
            {
                return View(produto);
            }
            else
            {
                return View("Index");
            }
        }
    }
}