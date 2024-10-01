using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal abstract class Exams
    {

        public int TimeOfExam { 
            get;
            set; 
        }

        public int NumberOfQuestions { get; set; }

        public Question[] questions { get; set; }
        public Exams(int timeOfExam, int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            questions = new Question[NumberOfQuestions];
        }

        public abstract void ShowExam(Exams exam);

        public abstract void ShowRightAnswers(Exams exam);



    }
}
