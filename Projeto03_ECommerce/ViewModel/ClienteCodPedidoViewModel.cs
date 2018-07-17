using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto03_ECommerce.ViewModel
{
    public class ClienteCodPedidoViewModel
    {
        [Required]
        [Display(Name = "Cód. Pedido")]
        public int PedidoId { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public string PedidoCliente { get; set; }        

        public ClienteCodPedidoViewModel(int PedidoId, string PedidoCliente)
        {
            this.PedidoId = PedidoId;
            this.PedidoCliente = PedidoCliente;
        }
    }
}