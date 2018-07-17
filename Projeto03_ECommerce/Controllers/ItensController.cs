using Projeto03_ECommerce.DB;
using Projeto03_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto03_ECommerce.Controllers
{
    public class ItensController : Controller
    {
        // GET: Itens
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IncluirItens()
        {
            var ListaPedidos = PedidoDB.ListarTodosPedidosVM();
            var ListaProdutos = ProdutoDB.ListarProduto();

            if (ListaPedidos == null || ListaPedidos.Count == 0)
            {
                ViewBag.MensagemErro = "Nenhum Pedido Cadastrado!";
                return View("Erro");
            }
            if (ListaProdutos == null || ListaProdutos.Count == 0)
            {
                ViewBag.MensagemErro = "Nenhum Produto Cadastrado!";
                return View("Erro");
            }

            ViewBag.Pedidos = new
                SelectList(ListaPedidos, "PedidoId", "PedidoCliente");

            ViewBag.Produtos = new
                SelectList(ListaProdutos, "ProdutoId", "Descricao");

            return View();
        }

        [HttpPost]
        public ActionResult IncluirItens(Item itens)
        {
            var ListaPedidos = PedidoDB.ListarTodosPedidosVM();
            var ListaProdutos = ProdutoDB.ListarProduto();

            if (ListaPedidos == null || ListaPedidos.Count == 0)
            {
                ViewBag.MensagemErro = "Nenhum Pedido Cadastrado!";
                return View("Erro");
            }
            if (ListaProdutos == null || ListaProdutos.Count == 0)
            {
                ViewBag.MensagemErro = "Nenhum Produto Cadastrado!";
                return View("Erro");
            }

            ViewBag.Pedidos = new
                SelectList(ListaPedidos, "PedidoId", "PedidoCliente");

            ViewBag.Produtos = new
                SelectList(ListaProdutos, "ProdutoId", "Descricao");

            if (ModelState.IsValid)
            {
                ItemDB.IncluirItem(itens);
                return RedirectToAction("Index");
            }

            return View();
        }

        public  ActionResult ListarItens(int? id)
        {
            var ListaPedidos = PedidoDB.ListarTodosPedidosVM();

            if (ListaPedidos == null || ListaPedidos.Count == 0)
            {
                ViewBag.MensagemErro = "Nenhum Pedido Cadastrado!";
                return View("Erro");
            }

            ViewBag.Pedidos = new
                SelectList(ListaPedidos, "PedidoId", "PedidoCliente");

            return View(PedidoDB.ListarItens(id));

        }

    }
}