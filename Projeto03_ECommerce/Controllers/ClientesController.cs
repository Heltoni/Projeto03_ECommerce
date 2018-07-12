using Projeto03_ECommerce.DB;
using Projeto03_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto03_ECommerce.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incluir()
        {
            return View();
        }

        //AQUI SOBRECARREGAMOS O METODO PARA QUE ESTE RECEBA OS DADOS DA VIEW ATRAVÉS DA ATRIBUIÇÃO FEITA PELA LAMBDA
        [HttpPost] //DESTA FORMA ESSE METODO NÃO PODERÁ SER CHAMADO PELA URL
        public ActionResult Incluir(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                Dados.IncluirCliente(cliente);
                return RedirectToAction("Index");
            }

            return View();

        }

        public ActionResult Listar()
        {
            return View();
        }

    }

}