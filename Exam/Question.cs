using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Question
    {
        public string Header { get; set; }

        public string Body { get; set; }

        public int Mark { get; set; }

        public Answers[] AnswerList {  get; set; }

        public int CorrectAnswer { get; set; }
        public Question(string header, string body, int mark, Answers[] answerList , int correctanswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            CorrectAnswer = correctanswer;
        }

        public override string ToString()
        {
            return $"{Header}\n Mark of the question: {Mark}\n{Body}";
        }
    }
}
