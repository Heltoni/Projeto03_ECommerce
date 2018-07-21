using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02_Lambda
{
    public delegate bool Verificacao<T>(T item);

    public class ListaElementos<T>
    {
        private T[] elementos;

        public void AtribuirArray(T[] elementos)
        {
            this.elementos = elementos;
        }
        public IEnumerable<T> Listar()
        {
            return this.elementos;
        }

        public T Buscar(Verificacao<T> valida)
        {
            foreach(var item in elementos)
            {
                if (valida(item))
                {
                    return item;
                }
            }
            return default(T);
        }
    }
}
