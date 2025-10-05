using System;

namespace Atividade_Hospital_Atendimento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Paciente[] filaPacientes = new Paciente[15];
            int totalPacientes = 0;
            string opcao = "";

            while (opcao != "q" && opcao != "Q")
            {
                Console.WriteLine("1 - Cadastrar paciente");
                Console.WriteLine("2 - Listar pacientes");
                Console.WriteLine("3 - Atender paciente");
                Console.WriteLine("4 - Alterar dados do paciente");
                Console.WriteLine("Q - Sair");
                Console.Write("Digite a opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        if (totalPacientes >= 15)
                        {
                            Console.WriteLine("Fila cheia!");
                        }
                        else
                        {
                            Paciente novo = new Paciente();
                            novo.IndiceCadastro = totalPacientes;

                            Console.Write("Nome completo: ");
                            novo.NomeCompleto = Console.ReadLine();

                            Console.Write("Data de nascimento (DD/MM/AAAA): ");
                            novo.DataNascimento = Console.ReadLine();

                            Console.Write("Tipo de atendimento (P - Preferencial / N - Normal): ");
                            novo.TipoAtendimento = Console.ReadLine();

                            int pos;
                            bool ehPreferencial = novo.TipoAtendimento == "P" || novo.TipoAtendimento == "p";

                            if (ehPreferencial)
                            {
                                pos = totalPacientes;
                                bool posicaoEncontrada = false;

                                for (int i = 0; i < totalPacientes; i++)
                                {
                                    bool pacienteAtualNaoEhPreferencial = filaPacientes[i].TipoAtendimento != "P" && filaPacientes[i].TipoAtendimento != "p";
                                    if (pacienteAtualNaoEhPreferencial)
                                    {
                                        pos = i;
                                        posicaoEncontrada = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                pos = totalPacientes;
                            }

                            for (int i = totalPacientes; i > pos; i--)
                            {
                                filaPacientes[i] = filaPacientes[i - 1];
                            }

                            filaPacientes[pos] = novo;
                            totalPacientes++;

                            Console.WriteLine("\nPaciente cadastrado com sucesso!");
                        }
                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;

                    case "2":
                        if (totalPacientes == 0)
                        {
                            Console.WriteLine("Fila vazia!");
                        }
                        else
                        {
                            for (int i = 0; i < totalPacientes; i++)
                            {
                                string tipo = (filaPacientes[i].TipoAtendimento == "P" || filaPacientes[i].TipoAtendimento == "p") ? "Preferencial" : "Normal";
                                Console.WriteLine((i + 1) + " - " + filaPacientes[i].NomeCompleto + " - Tipo: " + tipo);
                            }
                        }
                        Console.WriteLine("\nPressione Enter para continuar...");
                        Console.ReadLine();
                        break;

                    case "3":
                        if (totalPacientes == 0)
                        {
                            Console.WriteLine("Nenhum paciente para atender!");
                        }
                        else
                        {
                            Paciente atendido = filaPacientes[0];
                            Console.WriteLine("Atendendo paciente: " + atendido.NomeCompleto);

                            for (int i = 0; i < totalPacientes - 1; i++)
                            {
                                filaPacientes[i] = filaPacientes[i + 1];
                            }
                            filaPacientes[totalPacientes - 1] = null;
                            totalPacientes--;

                            Console.WriteLine("Paciente atendido!");
                        }
                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;

                    case "4":
                        if (totalPacientes == 0)
                        {
                            Console.WriteLine("Fila vazia!");
                        }
                        else
                        {
                            for (int i = 0; i < totalPacientes; i++)
                            {
                                Console.WriteLine((i + 1) + " - " + filaPacientes[i].NomeCompleto);
                            }

                            Console.Write("Escolha o paciente pelo número: ");
                            string escolhaTexto = Console.ReadLine();
                            int escolha = int.Parse(escolhaTexto);

                            if (escolha > 0 && escolha <= totalPacientes)
                            {
                                escolha--;
                                Paciente p = filaPacientes[escolha];

                                Console.Write("Novo nome (atual: " + p.NomeCompleto + "): ");
                                string novoNome = Console.ReadLine();
                                if (novoNome != "")
                                    p.NomeCompleto = novoNome;

                                Console.Write("Nova data (atual: " + p.DataNascimento + "): ");
                                string novaData = Console.ReadLine();
                                if (novaData != "")
                                    p.DataNascimento = novaData;

                                Console.Write("Novo tipo de atendimento (P/N) (atual: " + p.TipoAtendimento + "): ");
                                string novoTipo = Console.ReadLine();

                                if (novoTipo != "" && novoTipo != p.TipoAtendimento)
                                {
                                    p.TipoAtendimento = novoTipo;

                                    for (int i = escolha; i < totalPacientes - 1; i++)
                                    {
                                        filaPacientes[i] = filaPacientes[i + 1];
                                    }
                                    totalPacientes--;

                                    int pos;
                                    bool ehPreferencial = p.TipoAtendimento == "P" || p.TipoAtendimento == "p";

                                    if (ehPreferencial)
                                    {
                                        pos = totalPacientes;
                                        bool posicaoEncontrada = false;
                                        for (int i = 0; i < totalPacientes; i++)
                                        {
                                            bool pacienteAtualNaoEhPreferencial = filaPacientes[i].TipoAtendimento != "P" && filaPacientes[i].TipoAtendimento != "p";
                                            if (pacienteAtualNaoEhPreferencial)
                                            {
                                                pos = i;
                                                posicaoEncontrada = true;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        pos = totalPacientes;
                                    }

                                    for (int i = totalPacientes; i > pos; i--)
                                    {
                                        filaPacientes[i] = filaPacientes[i - 1];
                                    }
                                    filaPacientes[pos] = p;
                                    totalPacientes++;
                                    Console.WriteLine("\nPaciente reposicionado na fila.");
                                }

                                Console.WriteLine("\nDados atualizados!");
                            }
                            else
                            {
                                Console.WriteLine("Número inválido!");
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
                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}

