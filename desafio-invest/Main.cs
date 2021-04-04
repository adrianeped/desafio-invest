using System;
using System.Text.RegularExpressions;


namespace desafio_invest
{
    class Program
    {
        static int AskQuestion(){

            Console.WriteLine("");
            Console.WriteLine("--------- WALLET INVEST ---------");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Add Asset--------------------");
            Console.WriteLine("2 - View Assets------------------");
            Console.WriteLine("3 - Sell Assets------------------");
            Console.WriteLine("4 - Resume Assets----------------");
            Console.WriteLine("0 - Skip-------------------------");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("");
            
            return Convert.ToInt32(Console.ReadLine());
        }

        static int GetNumber(string question){
            string number;
            Match match;
            Regex regex = new Regex(@"^\d+$");
            do {
                Console.WriteLine(question);
                number = Console.ReadLine();
                match = regex.Match(number);
            } while (!match.Success);
            
            return Convert.ToInt32(number);
        }

        static string GetText(string question){           
            string text;
            do {
                Console.WriteLine(question);
                text = Console.ReadLine();
            } while (String.IsNullOrEmpty(text));

            return text;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
