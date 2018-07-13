﻿using Projeto03_ECommerce.Models;
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

        public static List<Cliente> ListarClientes()
        {
            using (var ctx = new ECommerceEntities())
            {
                return ctx.Clientes.ToList<Cliente>();
            }
        }
        public static Cliente BuscarCliente(int? id)
        {
            using (var ctx = new ECommerceEntities())
            {
                //PROPRIEDADE WHERE É DO ENTITY PROPRIEDADE FIND É DO IENUMERABLE
                //MAIS INDICADO UTILIZAR O ENTITY
                //O WHERE RETORNA UMA LISTA, POR ISSO UTILIZAMOS O FIRSTORDEFAULT
                return ctx
                    .Clientes
                    .Where(s => s.ClienteId == id)
                    .FirstOrDefault();
            }
        }

        //public static bool ExcluirCliente(int id)
        //{

        //    using (var ctx = new ECommerceEntities())
        //    {

        //        return ctx
        //            .Clientes
        //            .Remove()                 

        //    }

        //}
    }
}