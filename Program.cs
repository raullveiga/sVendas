using System;

namespace cpfVal
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();

         








        }
        /// <summary>
        /// A função retorna em boolean se o CPF é valido ou não.
        /// </summary>
        /// <param name="cpf">CPF a ser validado</param>
        /// <returns>Boolean</returns>
        static bool ValidaCPF(string cpf)
        {   
            bool retorno = true;
            string calcCPF ="";
            int[] p =    {10,9,8,7,6,5,4,3,2};
            int[] p2 =   {11,10,9,8,7,6,5,4,3,2};
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
                sum +=Int16.Parse((calcCPF[i]).ToString()) * p2[i];

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

