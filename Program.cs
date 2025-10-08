using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atendimento_Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Paciente[] fila = new Paciente[15];
            int total = 0;
            int numeroCadastro = 0;
            string opcao = "";

            while (opcao != "q" && opcao != "Q")
            {
                Console.WriteLine("1 - Cadastrar paciente");
                Console.WriteLine("2 - Listar pacientes");
                Console.WriteLine("3 - Atender paciente");
                Console.WriteLine("4 - Alterar dados do paciente");
                Console.WriteLine("Q - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        if (total >= 15)
                        {
                            Console.WriteLine("Fila cheia!");
                        }
                        else
                        {
                            Paciente novo = new Paciente();
                            numeroCadastro++;
                            novo.PosicaoCadastro = numeroCadastro;

                            Console.Write("Nome completo: ");
                            novo.Nome = Console.ReadLine();

                            Console.Write("Idade: ");
                            novo.Idade = int.Parse(Console.ReadLine());

                            Console.Write("Tipo de atendimento (P - Preferencial / N - Normal): ");
                            novo.Tipo = Console.ReadLine();

                            int posicaoInserir = total;

                            if (novo.Tipo == "P" || novo.Tipo == "p")
                            {
                                for (int i = 0; i < total; i++)
                                {
                                    if (fila[i].Tipo == "N" || fila[i].Tipo == "n")
                                    {
                                        posicaoInserir = i;
                                        break;
                                    }
                                }
                            }

                            for (int i = total; i > posicaoInserir; i--)
                            {
                                fila[i] = fila[i - 1];
                            }

                            fila[posicaoInserir] = novo;
                            total++;

                            Console.WriteLine("Paciente cadastrado com sucesso!");
                        }
                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;

                    case "2":
                        if (total == 0)
                        {
                            Console.WriteLine("Nenhum paciente cadastrado!");
                        }
                        else
                        {
                            Console.WriteLine("Lista de Pacientes");
                            for (int i = 0; i < total; i++)
                            {
                                string tipo;
                                if (fila[i].Tipo == "P" || fila[i].Tipo == "p")
                                {
                                    tipo = "Preferencial";
                                }
                                else
                                {
                                    tipo = "Normal";
                                }
                                int numero = i + 1;
                                string nome = fila[i].Nome;
                                int idade = fila[i].Idade;
                                Console.WriteLine(numero + " - " + nome + " | Idade: " + idade + " | Tipo: " + tipo);
                            }
                        }
                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;

                    case "3":
                        if (total == 0)
                        {
                            Console.WriteLine("Nenhum paciente na fila!");
                        }
                        else
                        {
                            Console.WriteLine("Atendendo paciente: " + fila[0].Nome);

                            for (int i = 0; i < total - 1; i++)
                            {
                                fila[i] = fila[i + 1];
                            }

                            total--;
                            Console.WriteLine("Paciente atendido!");
                        }
                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;

                    case "4":
                        if (total == 0)
                        {
                            Console.WriteLine("Nenhum paciente cadastrado!");
                        }
                        else
                        {
                            Console.WriteLine("Pacientes:");
                            for (int i = 0; i < total; i++)
                            {
                                Console.WriteLine((i + 1) + " - " + fila[i].Nome);
                            }

                            Console.Write("Digite o nome do paciente que deseja alterar: ");
                            string nomeBuscar = Console.ReadLine();

                            int num = -1;
                            for (int i = 0; i < total; i++)
                            {
                                if (fila[i].Nome == nomeBuscar)
                                {
                                    num = i;
                                    break;
                                }
                            }

                            if (num != -1)
                            {
                                Paciente p = fila[num];

                                Console.Write("Novo nome (atual: " + p.Nome + "): ");
                                string novoNome = Console.ReadLine();
                                if (novoNome != "")
                                    p.Nome = novoNome;

                                Console.Write("Nova idade (atual: " + p.Idade + "): ");
                                string novaIdade = Console.ReadLine();
                                if (novaIdade != "")
                                    p.Idade = int.Parse(novaIdade);

                                Console.Write("Novo tipo (P/N) (atual: " + p.Tipo + "): ");
                                string novoTipo = Console.ReadLine();

                                if (novoTipo != "" && novoTipo != p.Tipo)
                                {
                                    p.Tipo = novoTipo;

                                    for (int i = num; i < total - 1; i++)
                                    {
                                        fila[i] = fila[i + 1];
                                    }
                                    total--;

                                    int posInserir = total;

                                    if (p.Tipo == "P" || p.Tipo == "p")
                                    {
                                        for (int i = 0; i < total; i++)
                                        {
                                            if (fila[i].Tipo == "N" || fila[i].Tipo == "n")
                                            {
                                                posInserir = i;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int i = 0; i < total; i++)
                                        {
                                            if (fila[i].PosicaoCadastro > p.PosicaoCadastro)
                                            {
                                                posInserir = i;
                                                break;
                                            }
                                        }
                                    }

                                    for (int i = total; i > posInserir; i--)
                                    {
                                        fila[i] = fila[i - 1];
                                    }
                                    fila[posInserir] = p;
                                    total++;

                                    Console.WriteLine("Tipo alterado e paciente reposicionado!");
                                }
                                else
                                {
                                    Console.WriteLine("Dados atualizados!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Paciente não encontrado!");
                            }
                        }

                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;
                    case "q":
                    case "Q":
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
