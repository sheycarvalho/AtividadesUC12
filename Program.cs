﻿using CadastroPessoa.Classes;

Console.Clear();
Console.WriteLine(@$"
===========================================
|    Bem vindo ao sistema de cadastro de  |
|        Pessoas Fisicas e Juridicas      |
===========================================
");

Utils.BarraCarregamento("Iniciando", 100, 40);

List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
============================================
|    Escolha uma das opções abaixo         |
|------------------------------------------|
|       1 - Pessoa Fisica                  |
|       2 - Pessoa Juridica                |
|                                          |
|       0 - Sair                           |
============================================
");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

        string? opcaoPf;
        do
        {

            Console.Clear();
            Console.WriteLine(@$"
============================================
|    Escolha uma das opções abaixo         |
|------------------------------------------|
|       1 - Cadastrar Pessoa Fisica        |
|       2 - Listar Pessoas Fisica          |
|                                          |
|       0 - Voltar ao menu anterior        |
============================================
");

            opcaoPf = Console.ReadLine();
            PessoaFisica metodosPf = new PessoaFisica();
            
            switch (opcaoPf)
            {
            case "1":
            PessoaFisica novaPf = new PessoaFisica();
            Endereco novoEndPf = new Endereco();

            Console.WriteLine($"Digite o nome da pessoa fisica que deseja cadastrar");
            novaPf.Nome = Console.ReadLine();

            bool dataValida;
            do
            {
                Console.WriteLine($"Digite a data de nascimento Ex: DD/MM/AAA");
                string? dataNascimento = Console.ReadLine();

                dataValida = metodosPf.ValidarDataNasc(dataNascimento);

                if (dataValida)
                {
                   DateTime DataConvertida;
                   DateTime.TryParse(dataNascimento, out DataConvertida);

                   novaPf.dataNasc = DataConvertida; 
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Data digitada invalida, por favor digite uma data valida");
                    Console.ResetColor();
                    Thread.Sleep(3000);                    
                }
                
            } while (dataValida == false);

            Console.WriteLine($"Digite o numero do CPF");
            novaPf.Cpf = Console.ReadLine();

            Console.WriteLine($"Digite o rendimento mensal (DIGITE SOMENTE NUMEROS)");
            novaPf.Rendimento = float.Parse(Console.ReadLine());
 
            Console.WriteLine($"Digite o logradouro");
            novoEndPf.logradouro = Console.ReadLine();
            
            Console.WriteLine($"Digite o numero");
            novoEndPf.numero = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
            novoEndPf.complemento = Console.ReadLine();

            Console.WriteLine($"Este endereco é comercial? S/N");
            string endCom = Console.ReadLine().ToUpper();

            if (endCom == "S")
            {
                novoEndPf.endComercial = true;
            }
            else
            {
                novoEndPf.endComercial = false;
            }

            novaPf.Endereco = novoEndPf;

            listaPf.Add(novaPf);



// arquivo txt
            // StreamWriter sw = new StreamWriter($"{novaPf.Nome}.txt");
            // sw.WriteLine(novaPf.Nome);
            // sw.Close();

//elimina uso do close
            using (StreamWriter sw = new StreamWriter($"{novaPf.Nome}.txt"))
            {
                sw.WriteLine(novaPf.Nome);
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Cadastrado realizado com sucesso");
            Console.ResetColor();
            Thread.Sleep(3000);

                break;

            case "2":

                Console.Clear();

                if (listaPf.Count > 0)
                {
                    foreach (PessoaFisica cadaPessoa in listaPf)
                    {
                           Console.Clear();
                           Console.WriteLine(@$"
Nome: {cadaPessoa.Nome}
Endereco: {cadaPessoa.Endereco.logradouro}, {cadaPessoa.Endereco.numero}
Imposto a ser pago: {metodosPf.PagarImposto(cadaPessoa.Rendimento).ToString("C")}
");

                        Console.WriteLine("Aperte 'ENTER' para continuar");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine($"Lista vazia");
                    Thread.Sleep(3000);
                }

                using (StreamReader sr = new StreamReader("Sheyenne.txt"))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($"{linha}");
                    }
                }

                Console.WriteLine($"Aperte ENTER para continuar!");
                Console.ReadLine();




                break;

            case "0":
                break;

            default:
            Console.Clear();
            Console.ForegroundColor - ConsoleColor.DarkRed;
            Console.WriteLine($"Opção Inválida, por favor digite uma opção válida");
            Console.ResetColor();
            Thred.Sleep(3000);
                break;
        }
  
        } while (opcaoPf != "0");
            
            break;

        case "2":
            
            string? opcaoPj;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"
============================================
|        Escolha uma das opções abaixo     |
|------------------------------------------|   
|           1 - Cadastrar Pessoa Jurídica  |
|           2 - Listar Pessoas Jurídicas   |
|                                          |
|           0 - Voltar ao menu anterior    |
============================================
");
                opcaoPj = Console.ReadLine();
                PessoaJuridica metodosPj = new PessoaJuridica();

                switch (opcaoPj)
                {
                    case "1":

                        PessoaJuridica novaPj = new PessoaJuridica();
                        Endereco novoEndPj = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa jurídica que deseja cadastrar:");
                        novaPj.nome = Console.ReadLine();

                        Console.WriteLine($"Digite a razão social da empresa:");
                        novaPj.razaoSocial = Console.ReadLine();

                        Console.WriteLine($"Digite o número do CNPJ");
                        novaPj.cnpj = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (Apenas números):");
                        novaPj.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro:");
                        novoEndPj.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número:");
                        novoEndPj.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio):");
                        novoEndPj.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N:");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEndPj.endComercial = true;
                        }
                        else
                        {
                            novoEndPj.endComercial = false;
                        }

                        novaPj.endereco = novoEndPj;

                        listaPj.Add(novaPj);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Console.ResetColor();
                        Thread.Sleep(3000);


                    metodosPj.Inserir(novaPj);



                    List<PessoaJuridica> ListaPj = metodosPj.LerArquivo();

                        break;

                    case "2":

                        Console.Clear();

                        if (listaPj.Count > 0)
                        {
                            foreach (PessoaJuridica cadaPessoaJ in listaPj)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
Nome: {cadaPessoaJ.nome}
Razão Social: {cadaPessoaJ.razaoSocial}
CNPJ: {cadaPessoaJ.cnpj}, Válido: {(metodosPj.validarCnpj(cadaPessoaJ.cnpj) ? "sim" : "não")}
Endereço: {cadaPessoaJ.endereco.logradouro}, {cadaPessoaJ.endereco.numero}, {cadaPessoaJ.endereco.complemento}
Endereço comercial: {(cadaPessoaJ.endereco.endComercial ? "sim" : "não")}
Rendimento: {cadaPessoaJ.rendimento}
Imposto devido: {metodosPj.PagarImposto(cadaPessoaJ.rendimento).ToString("C")}
");

                                Console.WriteLine($"Aperte ENTER para continuar!");
                                Console.ReadLine();
                                Console.ResetColor();

                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"Lista Vazia!");
                            Thread.Sleep(3000);
                            Console.ResetColor();
                        }
                        break;

                    case "0":

                        break;

                    default:

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Opção Incorreta!");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        break;
                }

            } while (opcaoPj != "0");

            break;

        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema!");
            Thread.Sleep(1500);
            LoadingBar("Finalizando ", 500, 20);

            break;

        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema!");
            Thread.Sleep(3000);

            Utils.BarraCarregamento("Finalizando", 500, 6);

            break;

        default:
            Console.Clear();
            Console.ForegroundColor - ConsoleColor.DarkRed;
            Console.WriteLine($"Opção Inválida, por favor digite uma opção válida");
            Console.ResetColor();
            Thred.Sleep(3000);
            break;
    }
    
} while (opcao !="0");

//Barra de Carregamento
static void BarraCarregamento(string texto, int tempo, int quantidade)
{
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            
            Console.Write(texto); 
            
            for (var contador = 0; contador < quantidade; contador++)
            {
                Console.Write(".");
                Thread.Sleep(tempo);
            }
            
            Console.ResetColor();
}