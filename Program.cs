using System;
using System.IO;
using NetOffice.ExcelApi;

namespace cpfVal
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;

            Application ex = new Application();

            FileInfo Cli = new FileInfo(@"C:\Users\Cadastro\Clientes.xlsx");
            FileInfo Prod = new FileInfo(@"c:\Users\Cadastro\Produtos.xlsx");
            FileInfo Vend = new FileInfo(@"c:\Users\Cadastro\Vendas.xlsx");

            while (opcao != 9)
            {
                Console.Clear();
                Console.WriteLine("sVendas");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Digite a opção desejadas");
                Console.WriteLine("1 - Cadastro de Clientes.\n2 - Cadastro de Produtos.\n3 - Cadastro de Vendas.\n4 - Extrato do Cliente.\n9 - Sair.-");
                opcao = Convert.ToInt16(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do cliente:");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Digite o email do cliente");
                        string email = Console.ReadLine();
                        Console.WriteLine("Pessoa Física ou Jurídica?");
                        if("FISICA" == Console.ReadLine().ToUpper())
                            string pessoa = Console.ReadLine();
                            
                        if (Cli.Exists)
                        {

                            ex.Workbooks.Open(@"C:\Users\Cadastro\Clientes.xlsx"
                            );
                            ex.Range("A1").Select();
                            for (int i = 1; i < 1000; i++)
                            {
                                if (ex.Range("A" + i).Value == null)
                                {
                                    ex.Range("A" + i).Value = nome;
                                    ex.Range("B" + i).Value = email;
                                    ex.Range("C" + i).Value = pessoa;

                                    ex.Range("D" + i).Value =
                                    DateTime.Now.ToShortDateString();
                                    ex.ActiveWorkbook.Save();
                                    break;
                                }
                            }
                        }
                        else
                        {

                            ex.Workbooks.Add();
                            ex.Range("A1").Select();
                            ex.Range("A1").Value = "Nome";
                            ex.Range("B1").Value = "E-mail";
                            ex.Range("C1").Value = "CPF/CNPJ";
                            ex.Range("D1").Value = "Data de Cadastro";


                            ex.Range("A2").Value = nome;
                            ex.Range("B2").Value = email;
                            ex.Range("C2").Value = pessoa;
                            ex.Range("D2").Value =
                            DateTime.Now.ToShortDateString();

                            ex.ActiveWorkbook.SaveAs(@"C:\Users\Cadastro\Clientes.xlsx");
                        }

                        ex.Quit();
                        break;













                }










            }
            /// <summary>
            /// A função retorna em boolean se o CPF é valido ou não.
            /// </summary>
            /// <param name="cpf">CPF a ser validado</param>
            /// <returns>Boolean</returns>
            static bool ValidaCPF(string cpf)
            {
                bool retorno = true;
                string calcCPF = "";
                int[] p = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] p2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int sum = 0, res = 0;


                calcCPF = cpf.Substring(0, 9);

                for (int i = 0; i < calcCPF.Length; i++)
                    sum += Int16.Parse((calcCPF[i]).ToString()) * p[i];

                res = sum % 11;

                if (res < 2)
                    calcCPF += "0";
                else
                    calcCPF += (+11 - res).ToString();

                sum = 0;

                for (int i = 0; i < calcCPF.Length; i++)
                    sum += Int16.Parse((calcCPF[i]).ToString()) * p2[i];

                res = sum % 11;

                if (res < 2)
                    calcCPF += "0";
                else
                    calcCPF += (+11 - res).ToString();



                if (calcCPF != cpf)
                    retorno = false;

                return retorno;
            }
        }
    }

