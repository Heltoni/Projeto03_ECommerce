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

    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.Pedidos = new HashSet<Pedido>();
        }
    
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O CNPJ � obrigat�rio!")]
        [Display(Name = "CNPJ do Cliente")]
        [StringLength(maximumLength:14,MinimumLength =14, ErrorMessage = "O CNPJ deve conter apenas 14 n�meros!")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O Nome do cliente � obrigat�rio!")]
        [Display(Name = "Nome do Cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Telefone � obrigat�rio!")]
        [Display(Name = "Telefone do Cliente")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Endere�o � obrigat�rio!")]
        [Display(Name = "Endere�o do Cliente")]
        public string Endereco { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
