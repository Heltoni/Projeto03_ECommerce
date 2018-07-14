using Projeto03_ECommerce.DB;
using Projeto03_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto03_ECommerce.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CriarPedido()
        {
            var listaClientes = ClienteDB.ListarClientes();

            
            
            
            
            
            /*LEMBRAR O PROFESSOR DE FAZER A VALIDAÇÃO QUANDO CLIENTES NÃO CADASTRADOS
             APRESENTAR PÁGINA DE ERRO*/






            if (listaClientes.Count==0)
            {
                //RETORNAR PÁGINA DE ERRO
            }

            ViewBag.Clientes = new SelectList(listaClientes, "ClienteId", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult CriarPedido(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                PedidoDB.CriarPedido(pedido);
                return RedirectToAction("Index");
            }

            //PARA QUE NÃO OCORRA ERRO RETORNAMOS O CRIAR PEDIDO
            //PARA RETORNAR A VIEWBAG DE CLIENTES
            return CriarPedido();

        }
    }
}