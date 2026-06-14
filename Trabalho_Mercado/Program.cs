using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Mercado
{
    internal class Program
    {
        const int MAX = 100; // Limite de linhas para as matrizes

        // Matriz de Produtos: Linhas X 4 Colunas (Cod, Descricao, Valor, Qtd)
        static string[,] matrizProdutos = new string[MAX, 4];
        static int totalProdutos = 0;

        // Matriz de Vendas: Linhas X 3 Colunas (CodProd, CodFunc, Qtd)
        static string[,] matrizVendas = new string[MAX, 3];
        static int totalVendas = 0;

        static void Main()
        {
            int opcao = 0;
            do
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("1 - Cadastrar produtos");
                Console.WriteLine("2 - Realizar uma venda");
                Console.WriteLine("3 - Relatório de vendas");
                Console.WriteLine("4 - Relatório de vendas por funcionário");
                Console.WriteLine("0 - Sair");
                Console.Write("Selecione uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
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
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                    opcao = -1;
                }
            } while (opcao != 0);
        }

        // Função para exibir a tabela de produtos logo após o cadastro ou antes da venda
        static void ExibirTabelaProdutos()
        {
            Console.WriteLine("\n--- MATRIZ DE PRODUTOS ATUAL ---");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("CodProd\t\tDescricao\tValor\t\tQtd");
            Console.WriteLine("--------------------------------------------------");

            for (int i = 0; i < totalProdutos; i++)
            {
                Console.WriteLine($"{matrizProdutos[i, 0]}\t\t{matrizProdutos[i, 1]}\t\tR$ {double.Parse(matrizProdutos[i, 2]):F2}\t{matrizProdutos[i, 3]}");
            }
            Console.WriteLine("--------------------------------------------------\n");
        }

        static void CadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine("--- CADASTRAR PRODUTO ---");

            Console.Write("Insira o código do produto: ");
            matrizProdutos[totalProdutos, 0] = Console.ReadLine();

            Console.Write("Insira a descrição do produto: ");
            matrizProdutos[totalProdutos, 1] = Console.ReadLine();

            Console.Write("Insira o valor do produto: ");
            matrizProdutos[totalProdutos, 2] = Console.ReadLine();

            Console.Write("Insira a quantidade disponível em estoque: ");
            matrizProdutos[totalProdutos, 3] = Console.ReadLine();

            totalProdutos++;
            Console.WriteLine("\nProduto cadastrado com sucesso!");

            // Mostra a tabela de produtos imediatamente após cadastrar
            ExibirTabelaProdutos();
        }

        static void RealizarVenda()
        {
            Console.Clear();
            Console.WriteLine("--- REALIZAR VENDA ---");

            // Mostra os produtos em estoque para o operador saber o que está disponível
            ExibirTabelaProdutos();

            Console.Write("Digite o código do produto: ");
            string codProd = Console.ReadLine();

            // Busca o produto na matriz de produtos para validações
            int indiceProduto = -1;
            for (int i = 0; i < totalProdutos; i++)
            {
                if (matrizProdutos[i, 0] == codProd)
                {
                    indiceProduto = i;
                    break;
                }
            }

            if (indiceProduto == -1)
            {
                Console.WriteLine("Produto não encontrado!");
                return;
            }

            Console.Write("Digite o código do funcionário: ");
            string codFunc = Console.ReadLine();

            Console.Write("Digite a quantidade do produto vendido: ");
            int qtdVenda = int.Parse(Console.ReadLine());

            // Validação de estoque
            int estoqueAtual = int.Parse(matrizProdutos[indiceProduto, 3]);
            if (qtdVenda > estoqueAtual)
            {
                Console.WriteLine("Quantidade insuficiente em estoque! Estoque atual: " + estoqueAtual);
                return;
            }

            // textAtualiza o estoque na matriz de produtos
            int novoEstoque = estoqueAtual - qtdVenda;
            matrizProdutos[indiceProduto, 3] = novoEstoque.ToString();

            // Salva o registro da venda na matriz de vendas
            matrizVendas[totalVendas, 0] = codProd;
            matrizVendas[totalVendas, 1] = codFunc;
            matrizVendas[totalVendas, 2] = qtdVenda.ToString();
            totalVendas++;

            Console.WriteLine("\nVenda realizada com sucesso!");

            // Mostra a tabela novamente para comprovar a atualização do estoque
            ExibirTabelaProdutos();
        }

        static void RelatorioVendas()
        {
            Console.Clear();
            Console.WriteLine("--- RELATÓRIO DE VENDAS ---");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Cod. Prod\tCod. Func\tValor da Venda");
            Console.WriteLine("--------------------------------------------------");

            double valorTotalGeral = 0;

            for (int i = 0; i < totalVendas; i++)
            {
                string codProd = matrizVendas[i, 0];
                string codFunc = matrizVendas[i, 1];
                int qtdVendida = int.Parse(matrizVendas[i, 2]);

                // Procura o valor unitário correspondente na matriz de produtos
                double valorUnitario = 0;
                for (int j = 0; j < totalProdutos; j++)
                {
                    if (matrizProdutos[j, 0] == codProd)
                    {
                        valorUnitario = double.Parse(matrizProdutos[j, 2]);
                        break;
                    }
                }

                double valorVenda = qtdVendida * valorUnitario;
                valorTotalGeral += valorVenda;

                Console.WriteLine($"{codProd}\t\t{codFunc}\t\tR$ {valorVenda:F2}");
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"VALOR TOTAL DE TODAS AS VENDAS: R$ {valorTotalGeral:F2}");
            Console.WriteLine("--------------------------------------------------");
        }

        static void RelatorioVendasPorFuncionario()
        {
            Console.Clear();
            Console.WriteLine("--- RELATÓRIO DE VENDAS POR FUNCIONÁRIO ---");
            Console.Write("Digite o código do funcionário para filtrar: ");
            string filtroFunc = Console.ReadLine();

            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("Cod. Prod\tCod. Func\tValor da Venda");
            Console.WriteLine("--------------------------------------------------");

            double valorTotalFuncionario = 0;

            for (int i = 0; i < totalVendas; i++)
            {
                string codFunc = matrizVendas[i, 1];

                // Filtra apenas as vendas do funcionário especificado
                if (codFunc == filtroFunc)
                {
                    string codProd = matrizVendas[i, 0];
                    int qtdVendida = int.Parse(matrizVendas[i, 2]);

                    double valorUnitario = 0;
                    for (int j = 0; j < totalProdutos; j++)
                    {
                        if (matrizProdutos[j, 0] == codProd)
                        {
                            valorUnitario = double.Parse(matrizProdutos[j, 2]);
                            break;
                        }
                    }

                    double valorVenda = qtdVendida * valorUnitario;
                    valorTotalFuncionario += valorVenda;

                    Console.WriteLine($"{codProd}\t\t{codFunc}\t\tR$ {valorVenda:F2}");
                }
            }

            double comissao = valorTotalFuncionario * 0.10;

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"VALOR TOTAL DO FUNCIONÁRIO: R$ {valorTotalFuncionario:F2}");
            Console.WriteLine($"COMISSÃO (10%): R$ {comissao:F2}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}