using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete_Restaurante
{
    internal class Program
    {
        static int proximoID = 1;
        static void Main(string[] args)
        {
            List<ItemCardapio> listaCardapio = new List<ItemCardapio>();

            while (true)
            {
                LimpaTela();
                
                Console.WriteLine("========================================");
                Console.WriteLine("   A Sociedade do Burger ");
                Console.WriteLine("========================================");
                Console.WriteLine("1 - Cadastrar Item: ");
                Console.WriteLine("2 - Listar Cardapio: ");
                Console.WriteLine("3 - Alterar Preço / Aplicar Desonto: ");
                Console.WriteLine("4 - Pausar / Reativar Vendas: ");
                Console.WriteLine("5 - Remover Item: ");
                Console.WriteLine("6 - Sair.");
                Console.WriteLine("\nEscolha uma opção: ");
                
                int menu;
                if (!int.TryParse(Console.ReadLine(), out menu))
                {
                    Console.WriteLine("Entrada inválida! Digite um número de 1 a 6.");
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                if (menu == 6)
                {
                    Console.WriteLine("Saindo...");
                    break;    
                }
                
                switch (menu)
                {
                    case 1: CadastrarItem(listaCardapio); 
                        break;
                    case 2: ListarCardapio(listaCardapio);
                        break;
                    case 3: AlterarPreco_Desconto(listaCardapio);
                        break;
                    case 4: PausarReativar_Vendas(listaCardapio);
                        break;
                    case 5: RemoverItem(listaCardapio);
                        break;
                    default: break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void CadastrarItem(List<ItemCardapio> listaCardapio)
        {
            Console.Clear();
            
            Console.WriteLine("Informe o nome do item: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe a categoria do item: ");
            string categoria = Console.ReadLine();

            Console.WriteLine("Informe o preço base do item: ");
            decimal precoBase = Convert.ToDecimal(Console.ReadLine());

            int id = proximoID;
            proximoID++;
            
            listaCardapio.Add(new ItemCardapio(id, nome, categoria, precoBase));

            Console.WriteLine($"Item {nome} cadastrado com sucesso!");

        }

        static void ListarCardapio(List<ItemCardapio> listaCardapio)
        {
            if (listaCardapio.Count == 0)
            {
                Console.WriteLine("Não há itens cadastrados no cardápio.");
                return;
            }

            foreach (var item in listaCardapio)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine($"ID: {item.Id} | Nome: {item.Nome} | Categoria: {item.Categoria} | Preço Base: {item.PrecoBase} | Disponível: {item.EstaDisponivel}");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
        }

        static void AlterarPreco_Desconto(List<ItemCardapio> listaCardapio)
        {
            Console.WriteLine("Informe o ID do item que deseja aplicar o desconto ou alterar o preço: ");
            int id = Convert.ToInt32(Console.ReadLine());

            ItemCardapio itemEncontrado = null;
            foreach (var item in listaCardapio)
            {
                if (item.Id == id)
                {
                    itemEncontrado = item;
                    break;
                }
            }
            
            if (itemEncontrado == null)
            {
                Console.WriteLine("Item não encontrado.");
                return;
            }
            
            Console.WriteLine("1 - Alterar o preço base: \n2 - Aplicar desconto: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            if (opcao == 1)
            {
                Console.WriteLine("Novo preço: ");
                decimal novoPreco = Convert.ToDecimal(Console.ReadLine());
                try
                {
                    itemEncontrado.AlterarPrecoBase(novoPreco);
                    Console.WriteLine($"Preço atualizado: {itemEncontrado.PrecoBase}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }else if (opcao == 2)
            {
                Console.WriteLine("Informe a porcentagem de desconto que deseja aplicar (até 30%): ");
                decimal porcentagem = Convert.ToDecimal(Console.ReadLine());
            
                try
                {
                    itemEncontrado.AplicarDesconto(porcentagem);
                    Console.WriteLine($"Desconto aplicado!\nPreço atualizado: {itemEncontrado.PrecoBase}");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Opção  invalida.");
            }
        }

        static void PausarReativar_Vendas(List<ItemCardapio> listaCardapio)
        {
            Console.WriteLine("Informe o ID do item que deseja pausar ou reativar as vendas: ");
            int id = Convert.ToInt32(Console.ReadLine());

            ItemCardapio itemEncontrado = null;
            foreach (var item in listaCardapio)
            {
                if (item.Id == id)
                {
                    itemEncontrado = item;
                    break;
                }
            }
            
            if (itemEncontrado == null)
            {
                Console.WriteLine("Item não encontrado.");
                return;
            }

            Console.WriteLine("1 - Pausar vendas: \n2 - Reativar vendas: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            if (opcao == 1)
            {
                itemEncontrado.PausarVendas();
                Console.WriteLine($"Vendas do item {itemEncontrado.Nome} pausadas.");
            }else if (opcao == 2)
            {
                itemEncontrado.ReativarVendas();
                Console.WriteLine($"Vendas do item {itemEncontrado.Nome} reativadas.");
            }
            else
            {
                Console.WriteLine("Opção  invalida.");
            }
            
        }

        static void RemoverItem(List<ItemCardapio> listaCardapio)
        {
            Console.WriteLine("Informe o ID do item que deseja remover: ");
            int id = Convert.ToInt32(Console.ReadLine());

            ItemCardapio itemEncontrado = null;
            foreach (var item in listaCardapio)
            {
                if (item.Id == id)
                {
                    itemEncontrado = item;
                    break;
                }
            }
            
            if (itemEncontrado == null)
            {
                Console.WriteLine("Item não encontrado.");
                return;
            }
            
            listaCardapio.Remove(itemEncontrado);
            Console.WriteLine($"Item {itemEncontrado.Nome} removido com sucesso.");
        }

        static void LimpaTela()
        {
            Console.Clear();
        }
    }
}
