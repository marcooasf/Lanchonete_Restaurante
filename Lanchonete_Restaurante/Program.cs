using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete_Restaurante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ItemCardapio> listaCardapio = new List<ItemCardapio>();

            while (true)
            {
                Console.WriteLine("1 - Cadastrar Item: ");
                Console.WriteLine("2 - Listar Cardapio: ");
                Console.WriteLine("3 - Alterar Preço / Aplicar Desonto: ");
                Console.WriteLine("4 - Pausar / Reativar Vendas: ");
                Console.WriteLine("5 - Remover Item: ");
                Console.WriteLine("6 - Sair.");
               
                int menu = int.Parse(Console.ReadLine());

                if (menu == 0)
                    Console.WriteLine("Saindo..."); break;

                switch (menu)
                {

                }

                
            }
        }
    }
}
