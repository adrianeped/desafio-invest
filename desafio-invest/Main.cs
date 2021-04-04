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
            Wallet wallet = new Wallet();

            int option = AskQuestion();

            while (option != 0) {
                switch(option){
                    case 1:{
                        string cod = GetText("Write down the asset's code you want to buy?");
                        int price = GetNumber("What is the value of the asset?");
                        int quantity = GetNumber("What is the quantity of the asset?");
                        wallet.AddAsset(cod, price, quantity);
                    break;
                    }

                    case 2:
                        wallet.ViewAsset();
                    break;

                    case 3: {
                        string cod = GetText("Write the code of the asset's code you want to sell?");
                        int quantity = GetNumber("How many assets do you want to sell?");
                        wallet.SellAsset(cod, quantity);
                    break;
                    }

                    case 4:
                        wallet.ResumeAsset();    
                    break;

                    default:
                        Console.WriteLine("Invalid option");
                    break;
                }
                option = AskQuestion();
            }
        }

    }         

}
