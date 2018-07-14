using Projeto03_ECommerce.Models;
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
    }
}