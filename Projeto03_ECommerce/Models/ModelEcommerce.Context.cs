﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projeto03_ECommerce.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ECommerceEntities : DbContext
    {
        public ECommerceEntities()
            //base ENVIA A STRING PARA A SUPERCLASSE
            //ESTÁ É A STRING DE CONEXÃO QUE ESTÁ SENDO ENVIADA PARA A SUPERCLASSE
            : base("name=ECommerceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Item> Itens { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
    }
}
