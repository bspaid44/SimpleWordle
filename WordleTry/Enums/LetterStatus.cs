using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleTry.Enums
{
    public enum LetterStatus
    {
        Empty = 0,          // "This space does not contain a letter."
        Wrong = 1,          // "This letter is not in the word."
        WrongPosition = 2,  // "This letter is in the word, but not in this position."
        Correct = 3         // "This letter is in the word in this position."
    }
}
