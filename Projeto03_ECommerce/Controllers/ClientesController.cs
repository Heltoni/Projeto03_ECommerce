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
                ClienteDB.IncluirCliente(cliente);
                return RedirectToAction("Listar");
            }

            return View();

        }

        public ActionResult Listar()
        {
            return View(ClienteDB.ListarClientes());            
        }

        //? ESTE SIMBOLO FAZ COM QUE A VARIAVEL INT POSSA SER NULA
        public ActionResult Detalhar(int? id)
        {
            if (id==null)
            {
                ViewBag.MensagemErro = "Nenhum parâmetro informado na URL!";
                return View("Erro");
            }

            var cliente = ClienteDB.BuscarCliente(id);

            if (cliente == null)
            {
                ViewBag.MensagemErro = "Cliente não encontrado!";
                return View("Erro");
            }
            
            return View(cliente);
            
        }

        public ActionResult Alterar(int? id)
        {

            if (id == null)
            {
                ViewBag.MensagemErro = "Nenhum parâmetro informado na URL!";
                return View("Erro");
            }

            var cliente = ClienteDB.BuscarCliente(id);

            if (cliente == null)
            {
                ViewBag.MensagemErro = "Cliente não encontrado!";
                return View("Erro");
            }

            return View(cliente);

        }

        [HttpPost]
        public ActionResult Alterar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                ClienteDB.AlterarCliente(cliente);
                return RedirectToAction("Listar");
            }
                        
            return Alterar(cliente.ClienteId);
        }

        //public ActionResult Excluir(int? id)
        //{            
        //    if (id == null)
        //    {
        //        ViewBag.MensagemErro = "Nenhum parâmetro informado na URL!";
        //        return View("Erro");
        //    }

        //    bool cliente = Dados.ExcluirCliente(id);
        //    if (cliente == false)
        //    {
        //        ViewBag.MensagemErro = "Cliente não pode ser excluído!";
        //        return View("Erro");
        //    }
        //    ViewBag.MensagemSucesso = "Cliente excluído!";
        //    return View("Sucesso");
        //}
        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                ViewBag.MensagemErro = "Nenhum parâmetro informado na URL!";
                return View("Erro");
            }

            var cliente = ClienteDB.BuscarCliente(id);

            if (cliente == null)
            {
                ViewBag.MensagemErro = "Cliente não encontrado!";
                return View("Erro");
            }

            return View(cliente);
        }

        //FOI NECESSÁRIO INSERIR UM METODO POST PARA QUE O USUARIO POSSA SE DEFENDER
        [HttpPost]
        public ActionResult Excluir(int? id, Cliente cliente)
        {
            cliente.ClienteId = (int)id;
            ClienteDB.RemoverCliente(ClienteDB.BuscarCliente(id));
            return RedirectToAction("Listar");
        }

        //REQUISIÇÃO AJAX
        public ActionResult PesquisarClientes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PesquisarClientes(string busca)
        {
            List<Cliente> lista = ClienteDB.ListarClientes(busca);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListaClientes", lista);
            }
            else
            {
                return View(lista);
            }
        }
    }

}