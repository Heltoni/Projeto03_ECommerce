using Projeto03_ECommerce.Models;
using Projeto03_ECommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto03_ECommerce.DB
{
    public class PedidoDB
    {
        public static void CriarPedido(Pedido pedido)
        {
            using (var ctx = new ECommerceEntities())
            {
                ctx.Pedidos.Add(pedido);
                ctx.SaveChanges();
            }
        }
        public static List<Pedido> ListarPedido()
        {
            using (var ctx = new ECommerceEntities())
            {
                return ctx.Pedidos.ToList<Pedido>();
            }
        }
        public static Pedido BuscarProduto(int? id)
        {
            using (var ctx = new ECommerceEntities())
            {
                return ctx
                    .Pedidos
                    .Where(s => s.PedidoId == id)
                    .FirstOrDefault();
            }
        }

        //AQUI UTILIZANDO ENTITY PARA RETORNO DOS DADOS CLIENTE x PEDIDOS
        public static List<ClientePedidoViewModel> ListarPedidosVM(int? id)
        {
            using (var ctx = new ECommerceEntities())
            {
                /*resultado SE TORNOU UM OBJETO COLLECTION DE ANONIMOS*/
                var resultado = ctx.Clientes
                    .Join(
                        ctx.Pedidos,
                        c => c.ClienteId,
                        p => p.ClienteId,
                        (c, p) => new
                        {
                            /*AQUI FORAM CRIADAS PROPRIEDADES PARA UM OBJETO ANONIMO*/
                            CodigoCliente = c.ClienteId,
                            NomeCliente = c.Nome,
                            DataPedido = p.DataPedido,
                            NumeroPedido = p.NumeroPedido                            
                        }).Where(cod => cod.CodigoCliente == id); //AQUI PODERIAMOS INCLUIR UM TERNARIO PARA TRATAR NULO
                /*CRIAMOS UM NOVO OBJETO QUE TERÁ AS PROPRIEDADES E VALORES DAS DUAS TABELAS*/

                List<ClientePedidoViewModel> lista = new List<ClientePedidoViewModel>();
                foreach (var item in resultado)
                {
                    lista.Add(new ClientePedidoViewModel(
                        item.NomeCliente,
                        item.DataPedido,
                        item.NumeroPedido));
                }
                return lista;
            }
        }

        //AQUI UTILIZANDO LINQ PARA RETORNAR OS DADOS CLIENTES x PEDIDOS
        public static List<ClientePedidoViewModel> ListarPedidosLinq(int? id)
        {
            var ctx = new ECommerceEntities();
            var resultado = from c in ctx.Clientes
                            join p in ctx.Pedidos
                            on c.ClienteId equals p.ClienteId
                            where (id == null ? c.ClienteId > 0 : c.ClienteId == id)
                            select new
                            {
                                CodigoCliente = c.ClienteId,
                                NomeCliente = c.Nome,
                                DataPedido = p.DataPedido,
                                NumeroPedido = p.NumeroPedido
                            };

            List<ClientePedidoViewModel> lista = new List<ClientePedidoViewModel>();
            foreach (var item in resultado)
            {
                lista.Add(new ClientePedidoViewModel(
                    item.NomeCliente,
                    item.DataPedido,
                    item.NumeroPedido));
            }
            return lista;
        }
        public static List<ClienteCodPedidoViewModel> ListarTodosPedidosVM()
        {
            using (var ctx = new ECommerceEntities())
            {
                /*resultado SE TORNOU UM OBJETO COLLECTION DE ANONIMOS*/
                var resultado = ctx.Clientes
                    .Join(
                        ctx.Pedidos,
                        c => c.ClienteId,
                        p => p.ClienteId,
                        (c, p) => new
                        {
                            /*AQUI FORAM CRIADAS PROPRIEDADES PARA UM OBJETO ANONIMO*/
                            PedidoId = p.PedidoId,
                            PedidoCliente = c.Nome + " - " + p.NumeroPedido,
                        }); //AQUI PODERIAMOS INCLUIR UM TERNARIO PARA TRATAR NULO
                /*CRIAMOS UM NOVO OBJETO QUE TERÁ AS PROPRIEDADES E VALORES DAS DUAS TABELAS*/

                List<ClienteCodPedidoViewModel> lista = new List<ClienteCodPedidoViewModel>();
                foreach (var item in resultado)
                {
                    lista.Add(new ClienteCodPedidoViewModel(
                        item.PedidoId,
                        item.PedidoCliente));
                }
                return lista;
            }
        }
    }
}