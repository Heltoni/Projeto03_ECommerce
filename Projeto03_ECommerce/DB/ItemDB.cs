using Projeto03_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto03_ECommerce.DB
{
    public class ItemDB
    {
        public static void IncluirItem(Item item)
        {
            using (var ctx = new ECommerceEntities())
            {
                ctx.Itens.Add(item);
                ctx.SaveChanges();
            }
        }
    }
}