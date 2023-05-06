using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleTry.Enums;
using WordleTry.Models;

namespace WordleTry
{
    public class Aback
    {
        public WordRecord _wordRecord;

        public Aback(WordRecord wordRecord) 
        {
            _wordRecord = wordRecord;
        }

        public static string ReadCsv()
        {
            using (var reader = new StreamReader("word-bank.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<WordRecord>();

                string error = "Word cannot be found";
                Random random = new Random();
                int rand_num = random.Next(0, 2313);

                foreach (var record in records)
                {                    
                    if (rand_num == record.Index)
                    {
                        return record.Word;
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
