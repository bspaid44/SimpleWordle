using CsvHelper.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace WordleTry
{
    internal class Program
    {
        public string guess;
        public string answer;
        

        

        static void Main(string[] args)
        {
            string answer = Aback.ReadCsv();

            Console.WriteLine("Welcome to totally not copywrited Wordle");
            Console.WriteLine("\n\n");

            int i = 0;


            while (i == 0)
            {
                Console.WriteLine("\nPlease type your five-letter guess in: \n");
                string guess = Console.ReadLine();

                var results = Aback.CheckLetters(answer, guess);

                foreach (var result in results)
                {
                    Console.Write(result + " ");

                    if (answer == guess)
                    {
                        Console.WriteLine("You win!!!");
                        i++;
                    }
                }
            }
        }
    }
}