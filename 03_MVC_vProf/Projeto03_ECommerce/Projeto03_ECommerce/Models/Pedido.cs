//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.Itens = new HashSet<Item>();
        }
    
        public int PedidoId { get; set; }

        [Display(Name = "Selecione o cliente")]
        public int ClienteId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", 
            ApplyFormatInEditMode = true)]
        [Display(Name = "Data do Pedido")]
        public System.DateTime DataPedido { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2)]
        [Display(Name = "Numero do Pedido")]
        public string NumeroPedido { get; set; }
    
        public virtual Cliente ClienteInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Itens { get; set; }
    }
}
