using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace victorina
{
    class Answer
    {
        public string question { get; set; }
        public string trueAnswer { get; set; }

        public string falseAnswer { get; set; }
        public override string ToString()
        {
            return $"{question}\nВарианты ответов:\n{falseAnswer}\n";
        }
        public Answer(string question,string trueAnswer,string falseAnswer)
        {
            this.question = question;
            this.trueAnswer = trueAnswer;
            this.falseAnswer = falseAnswer;
        }
    }
    

}
