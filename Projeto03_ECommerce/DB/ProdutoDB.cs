using Projeto03_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto03_ECommerce.DB
{
    public class ProdutoDB
    {
        public static void IncluirProduto(Produto produto)
        {
            using (var ctx = new ECommerceEntities())
            {
                ctx.Produtos.Add(produto);
                ctx.SaveChanges();
            }
        }
        public static List<Produto> ListarProduto()
        {
            using (var ctx = new ECommerceEntities())
            {
                return ctx.Produtos.ToList<Produto>();
            }
        }
        public static Produto BuscarProduto(int? id)
        {
            using (var ctx = new ECommerceEntities())
            {
                return ctx
                    .Produtos
                    .Where(s => s.ProdutoId == id)
                    .FirstOrDefault();
            }
        }
    }
}