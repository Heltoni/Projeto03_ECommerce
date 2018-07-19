using Projeto03_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto03_ECommerce.DB
{
    public class ClienteDB
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

        public static List<Cliente> ListarClientes(string busca)
        {
            using (var ctx = new ECommerceEntities())
            {
                if (string.IsNullOrEmpty(busca))
                {
                    return ListarClientes();
                }
                else
                {
                    return ctx.Clientes
                        .Where(c=>c.Nome.Contains(busca))
                        .ToList<Cliente>(); 
                }
            }
        }

        //LINQ - LANGUAGE INTEGRATED QUERY
        public static List<Cliente> ListarClientesLinq()
        {
            //NO LUGAR DE UTILIZAR O JOIN DO ENTITY PODEMOS UTILIZAR O LINQ

            var ctx = new ECommerceEntities();
            //NA PRIMEIRA LINHA FAZEMOS UMA REFERENCIA A COLEÇÃO CLIENTES
            //NA SEGUNDA LINHA EQUIVALE A SELECT * FROM
            var resposta = from c in ctx.Clientes
                           select c;
            return resposta.ToList();
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

        //public static bool ExcluirCliente(int? id)
        //{
        //    try
        //    {
        //        using (var ctx = new ECommerceEntities())
        //        {
        //            ctx
        //                .Clientes
        //                .Remove(
        //                    ctx
        //                    .Clientes
        //                    .Where(s => s.ClienteId == id)
        //                    .FirstOrDefault());
        //            ctx.SaveChanges();
        //            return true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}
        public static void AlterarCliente(Cliente cliente)
        {
            using (var ctx = new ECommerceEntities())
            {
                ctx.Entry<Cliente>(cliente).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public static void RemoverCliente(Cliente cliente)
        {
            using (var ctx = new ECommerceEntities ())
            {
                try
                {
                    ctx.Entry<Cliente>(cliente).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
                catch (Exception)
                {
                    //INSERIR TRY NO CONTROLLER E CHAMAR A VIEW
                    throw; //FormatException("");
                }
            }
        }        
    }
}