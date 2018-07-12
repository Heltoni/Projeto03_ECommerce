using Projeto03_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto03_ECommerce.DB
{
    public class Dados
    {
        //METODO PARA INCLUIR UM NOVO CLIENTE
        public static void IncluirCliente(Cliente cliente)
        {
            //ctx É A ABREVIAÇÃO PARA CONTEXT E O ECommerceEntities É O CONTEXTO QUE POSSUI AS TABELAS
            //ABRIRÁ E FECHARÁ O BANCO
            using (var ctx = new ECommerceEntities())
            {
                ctx.Clientes.Add(cliente);
                ctx.SaveChanges();
            }
        }
    }
}