using System;

namespace Trabalho_Mercado
{
    internal class Program
    {
        const int MAX = 100;

        static string[,] matrizProdutos = new string[MAX, 4];
        static int totalProdutos = 0;

        static string[,] matrizVendas = new string[MAX, 3];
        static int totalVendas = 0;

        static void Main()
        {
            int opcao;

            do
            {
                Console.Clear();

                Console.WriteLine("========================================");
                Console.WriteLine("1 - Cadastrar produtos");
                Console.WriteLine("2 - Realizar uma venda");
                Console.WriteLine("3 - Relatório de vendas");
                Console.WriteLine("4 - Relatório de vendas por funcionário");
                Console.WriteLine("0 - Sair");
                Console.Write("Selecione uma opção: ");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        CadastrarProduto();
                        break;

                    case 2:
                        RealizarVenda();
                        break;

                    case 3:
                        MostrarRelatorio();
                        break;

                    case 4:
                        RelatorioFuncionario();
                        break;

                    case 0:
                        Console.WriteLine("Encerrando programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }

            } while (opcao != 0);
        }

        static void MostrarProdutos()
        {
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Código | Descrição | Valor | Qtd");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < totalProdutos; i++)
            {
                Console.WriteLine(
                    $"{matrizProdutos[i, 0]}\t" +
                    $"{matrizProdutos[i, 1]}\t\t" +
                    $"R$ {double.Parse(matrizProdutos[i, 2]):F2}\t" +
                    $"{matrizProdutos[i, 3]}"
                );
            }

            Console.WriteLine("----------------------------------------");
        }

        static void CadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine("=== CADASTRO DE PRODUTO ===");

            Console.Write("Código: ");
            matrizProdutos[totalProdutos, 0] = Console.ReadLine();

            Console.Write("Descrição: ");
            matrizProdutos[totalProdutos, 1] = Console.ReadLine();

            Console.Write("Valor: ");
            double valor = double.Parse(Console.ReadLine());
            matrizProdutos[totalProdutos, 2] = valor.ToString();

            Console.Write("Quantidade em estoque: ");
            int qtd = int.Parse(Console.ReadLine());
            matrizProdutos[totalProdutos, 3] = qtd.ToString();

            totalProdutos++;

            Console.WriteLine("\nProduto cadastrado com sucesso!");

            MostrarProdutos();

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static void RealizarVenda()
        {
            Console.Clear();
            Console.WriteLine("=== REALIZAR VENDA ===");

            if (totalProdutos == 0)
            {
                Console.WriteLine("Não há produtos cadastrados.");
                Console.ReadKey();
                return;
            }

            MostrarProdutos();

            Console.Write("\nCódigo do produto: ");
            string codProd = Console.ReadLine();

            int indiceProduto = -1;

            for (int i = 0; i < totalProdutos; i++)
            {
                if (codProd == matrizProdutos[i, 0])
                {
                    indiceProduto = i;
                }
            }

            if (indiceProduto == -1)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                return;
            }

            Console.Write("Código do funcionário: ");
            string codFunc = Console.ReadLine();

            Console.Write("Quantidade vendida: ");
            int qtdVenda = int.Parse(Console.ReadLine());

            int estoque = int.Parse(matrizProdutos[indiceProduto, 3]);

            if (qtdVenda > estoque)
            {
                Console.WriteLine("Estoque insuficiente!");
                Console.ReadKey();
                return;
            }

            estoque -= qtdVenda;
            matrizProdutos[indiceProduto, 3] = estoque.ToString();

            matrizVendas[totalVendas, 0] = codProd;
            matrizVendas[totalVendas, 1] = codFunc;
            matrizVendas[totalVendas, 2] = qtdVenda.ToString();

            totalVendas++;

            Console.WriteLine("\nVenda registrada com sucesso!");

            MostrarProdutos();

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static void MostrarRelatorio()
        {
            Console.Clear();

            Console.WriteLine("=== RELATÓRIO DE VENDAS ===");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Produto | Funcionário | Valor");
            Console.WriteLine("----------------------------------------");

            double totalGeral = 0;

            for (int i = 0; i < totalVendas; i++)
            {
                string codProd = matrizVendas[i, 0];
                string codFunc = matrizVendas[i, 1];
                int qtdVendida = int.Parse(matrizVendas[i, 2]);

                double valorUnitario = 0;

                for (int j = 0; j < totalProdutos; j++)
                {
                    if (codProd == matrizProdutos[j, 0])
                    {
                        valorUnitario = double.Parse(matrizProdutos[j, 2]);
                    }
                }

                double valorVenda = qtdVendida * valorUnitario;
                totalGeral += valorVenda;

                Console.WriteLine($"{codProd}\t{codFunc}\tR$ {valorVenda:F2}");
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Total das vendas: R$ {totalGeral:F2}");

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static void RelatorioFuncionario()
        {
            Console.Clear();

            Console.WriteLine("=== RELATÓRIO POR FUNCIONÁRIO ===");
            Console.Write("Código do funcionário: ");
            string codigoFuncionario = Console.ReadLine();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Prod\tFunc\tValor");
            Console.WriteLine("----------------------------------------");

            double totalFuncionario = 0;

            for (int i = 0; i < totalVendas; i++)
            {
                if (matrizVendas[i, 1] == codigoFuncionario)
                {
                    string codProd = matrizVendas[i, 0];
                    int qtdVendida = int.Parse(matrizVendas[i, 2]);

                    double valorUnitario = 0;

                    for (int j = 0; j < totalProdutos; j++)
                    {
                        if (codProd == matrizProdutos[j, 0])
                        {
                            valorUnitario = double.Parse(matrizProdutos[j, 2]);
                        }
                    }

                    double valorVenda = qtdVendida * valorUnitario;

                    totalFuncionario += valorVenda;

                    Console.WriteLine(
                        $"{codProd}\t{codigoFuncionario}\tR$ {valorVenda:F2}"
                    );
                }
            }

            double comissao = totalFuncionario * 0.10;

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Total vendido: R$ {totalFuncionario:F2}");
            Console.WriteLine($"Comissão (10%): R$ {comissao:F2}");

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}