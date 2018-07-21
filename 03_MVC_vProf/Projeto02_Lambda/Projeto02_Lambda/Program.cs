using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02_Lambda
{
    class Program
    {
        public delegate int Calculo(int x, int y);
        public delegate int Busca(string s);
        public delegate string Mensagem(string s, int x);

        public delegate T BuscarElemento<T>(T item, int x);

        static void Main(string[] args)
        {
            //Calculo calc1 = (a, b) => a * b;
            //Calculo calc2 = (x1, x2) => x1 / x2;

            //Console.WriteLine("calc1: " + calc1(2, 3));
            //Console.WriteLine("calc2: " + calc2(6, 3));

            ////delegate: Busca
            //Busca busca1 = s => Convert.ToInt32(s);
            //Console.WriteLine(busca1("123"));

            //Busca busca2 = texto => texto.Replace(" ", "").Length;
            //Console.WriteLine(busca2("Minha expressao           lambda"));

            ////delegate: Mensagem
            //Mensagem msg1 = (a, b) => a + b;
            //Console.WriteLine(msg1("texto qualquer", 123));

            //Mensagem msg2 = (s, x) =>
            //{
            //    Console.WriteLine("Digite um texto");
            //    string entrada = Console.ReadLine();
            //    return s + " - " + entrada.Substring(0, x);
            //};
            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine(msg2("Parametro", 4));

            //BuscarElemento<string> elemento = (p1, p2) => p1.Substring(p2);
            //Console.WriteLine(elemento("Desenvolvimento Web", 6));
            string[] cursos = { "android", "dot.net", "php", "html5" };
            ListaElementos<string> lista = new ListaElementos<string>();
            lista.AtribuirArray(cursos);

            string resposta = lista.Buscar(s => s.Length >= 3 && s.Length <= 6);
            Console.WriteLine("resposta = " + resposta);

            //---------------------------------------------------
            List<string> cursos2 = new List<string>()
            {
                "android", "dot.net", "php", "html5"
            };

            string resposta2 = cursos2.Find(s => s.Length >= 3 && s.Length <= 6);
            Console.WriteLine("resposta2 = " + resposta2);







            Console.ReadKey();
        }



        //static int Calcular(int x, int y)
        //{
        //    return x - y;
        //}
    }
}
