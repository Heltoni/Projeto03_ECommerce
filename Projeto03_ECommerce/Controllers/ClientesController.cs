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
                return RedirectToAction("Listar");
            }

            return View();

        }

        public ActionResult Listar()
        {
            return View(Dados.ListarClientes());            
        }

        //? ESTE SIMBOLO FAZ COM QUE A VARIAVEL INT POSSA SER NULA
        public ActionResult Detalhar(int? id)
        {
            var cliente = Dados.BuscarCliente(id);

            if (id==null)
            {
                ViewBag.MensagemErro = "Nenhum parâmetro informado na URL!";
                return View("Erro");
            }

            if (cliente == null)
            {
                ViewBag.MensagemErro = "Cliente não encontrado!";
                return View("Erro");
            }
            
            return View(cliente);
            
        }

        //public ActionResult Excluir(int? id)
        //{
        //    var cliente = Dados.ExcluirCliente(id);

        //    if (id == null)
        //    {
        //        ViewBag.MensagemErro = "Nenhum parâmetro informado na URL!";
        //        return View("Erro");
        //    }
        //    if (cliente)
        //    {
        //        ViewBag.MensagemErro = "Cliente não encontrado!";
        //        return View("Erro");
        //    }

        //}
    }

}