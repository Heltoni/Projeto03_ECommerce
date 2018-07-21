using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto01_Conceitos
{
    public class Empresa
    {
        public string Cnpj { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return this.Cnpj + " - " + this.Descricao;
        }
    }
}