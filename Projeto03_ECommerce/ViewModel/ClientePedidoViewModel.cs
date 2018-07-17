using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto03_ECommerce.ViewModel
{
    //VIEWMODELS NÃO TEM VINCULO DIRETO COM AS TABELAS DA BASE
    //ASSIM PODEMOS LINCAR VARIAS TABELAS
    public class ClientePedidoViewModel
    {
        [Required]
        [Display(Name = "Cliente")]
        public string NomeCliente { get; set; }

        [Required]
        [Display(Name = "Data do Pedido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataPedido { get; set; }

        [Required]
        [Display(Name = "Núm. pedido")]
        public string NumeroPedido { get; set; }

        public ClientePedidoViewModel(string Nomecliente, DateTime DataPedido, string NumeroPedido)
        {
            this.NomeCliente = Nomecliente;
            this.DataPedido = DataPedido;
            this.NumeroPedido = NumeroPedido;
        }
    }
}