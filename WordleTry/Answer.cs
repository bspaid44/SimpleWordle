using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleTry
{

    public enum LetterStatus
    {
        Empty = 0,          // "This space does not contain a letter."
        Wrong = 1,          // "This letter is not in the word."
        WrongPosition = 2,  // "This letter is in the word, but not in this position."
        Correct = 3         // "This letter is in the word in this position."
    }

    public class Aback
    {
        public string word { get; set; }
        public int index { get; set; }

        public static string ReadCsv()
        {
            using (var reader = new StreamReader("word-bank.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var record = new Aback();
                var records = csv.GetRecords<Aback>();

                string error = "Word cannot be found";
                Random random = new Random();
                int rand_num = random.Next(0, 2313);

                foreach (var r in records)
                {
                    
                    string word = r.word;
                    int index = r.index;
                    
                    if (rand_num == index)
                    {
                        return word;
                    }

                } return error;
            }
        }

        

        public static LetterStatus[] CheckLetters(string answer, string guess)
        {
            var result = new LetterStatus[5];

            for (int i = 0; i < guess.Length; i++)
            {
                if (answer[i] == guess[i])
                {
                    result[i] = LetterStatus.Correct;
                }
                else if (answer.Contains(guess[i]))
                {
                    result[i] = LetterStatus.WrongPosition;
                }
                else
                {
                    result[i] = LetterStatus.Wrong;
                }
            }

            return result;
        }
    }
}
