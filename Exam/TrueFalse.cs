using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class TrueFalse:Question
    {
        public TrueFalse(string header, string body, int mark, Answers[] answerList,int correctanswer) : base(header, body, mark, answerList,correctanswer)
        {
        }
    }
}
