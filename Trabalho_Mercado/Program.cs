using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Mercado
{
    internal class Program
    {
        const int MAX = 9999;
        
        static int[] prodCodigo = new int[MAX];
        static string[] prodDescricao = new string[MAX];
        static double[] prodValor = new double[MAX];
        static int[] prodEstoque = new int[MAX];
        static int totalProdutos = 0; 
                                      
        static int[] vendaProduto = new int[MAX];
        static int[] vendaFuncionario = new int[MAX];
        static int[] vendaQuantidade = new int[MAX];
        static int totalVendas = 0; 
        static void Main()
        {
            int opcao = 0;
            do
            {
                Console.WriteLine("========================================");
                Console.WriteLine("1 - Cadastrar produtos");
                Console.WriteLine("2 - Realizar uma venda");
                Console.WriteLine("3 - Relatório de vendas");
                Console.WriteLine("4 - Relatório de vendas por funcionário");
                Console.WriteLine("0 - Sair");
                Console.Write("Selecione uma opção: ");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        CadastrarProduto();
                        break;
                    case 2:
                        RealizarVenda();
                        break;
                    case 3:
                        RelatorioVendas();
                        break;
                    case 4:
                        RelatorioVendasPorFuncionario();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 0);
        }
        static void CadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine("--- CADASTRAR PRODUTO ---");
            Console.WriteLine("Insira o código do produto: ");
            prodCodigo[totalProdutos] = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a descrição do produto: ");
            prodDescricao[totalProdutos] = Console.ReadLine();

            Console.WriteLine("Insira o valor do produto: ");
            prodValor[totalProdutos] = double.Parse(Console.ReadLine());

            Console.WriteLine("Insira a quantidade disponível em estoque: ");
            prodEstoque[totalProdutos] = int.Parse(Console.ReadLine());

            totalProdutos++;
            Console.WriteLine("Produto cadastrado!");
        }
        static void RealizarVenda()
        {
            
        }
        static void RelatorioVendas()
        {
           
        }
        static void RelatorioVendasPorFuncionario()
        {
            
        }
    }
}

