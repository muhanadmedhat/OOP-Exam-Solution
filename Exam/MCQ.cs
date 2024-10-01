using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class MCQ : Question
    {
        public int CorrectAnswer { get; set; }
        public MCQ(string header, string body, int mark, Answers[] answerList,int correctanswer) : base(header, body, mark, answerList, correctanswer)
        {          
           
        }
    }
}
