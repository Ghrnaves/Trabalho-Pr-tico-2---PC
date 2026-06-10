using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Mercado
{
    internal class Program
    {
        const int MAX = 100;
        
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
            int opcao;
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

