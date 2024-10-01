using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Practical : Exams
    {
       public Practical(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {

        }
        public int[] Answer;

        public int mark;
        public int sum;
        public override void ShowExam(Exams exam)
        {
            mark = 0;
            Answer = new int[exam.questions.Length];
            bool flag;
            if (exam is not null)
            {
                for (int i = 0; i < exam.questions.Length; i++)
                {
                    Console.WriteLine(exam.questions[i].Header);
                    Console.WriteLine("");
                    // Console.WriteLine(exam.questions[i].Mark);
                    Console.WriteLine(exam.questions[i].Body);
                    Console.WriteLine("");
                    int answerId;
                    do
                    {
                        Console.WriteLine("(Enter 1 for true or 2 for false)");
                        flag = int.TryParse(Console.ReadLine(), out answerId);
                    } while (flag == false || (answerId != 1 && answerId != 2));

                    Answer[i] = answerId;
                    string TrueFalseAnswer;
                    if (answerId == 1)
                        TrueFalseAnswer = "true";
                    else
                        TrueFalseAnswer = "false";

                    if (exam.questions[i].AnswerList[0].AnswerText == TrueFalseAnswer)
                    {
                        mark += exam.questions[i].Mark;
                    }
                    sum += exam.questions[i].Mark;
                    Console.WriteLine("****************************");
                }
                //Console.WriteLine($"Your mark in the exam is: {mark}");
            }
        }

        public override void ShowRightAnswers(Exams exam)
        {
            for (int i = 0; i < exam.questions.Length; i++)
            {
                Console.WriteLine(exam.questions[i].Body);
                Console.Write("Your answer is: ");
                int answer = Answer[i];
                string result;
                if (answer == 1)
                {
                    result = "1:True";
                }
                else
                {
                    result = "2:False";
                }
                Console.WriteLine(result);
                Console.Write("The right answer is: ");
                Console.WriteLine(exam.questions[i].AnswerList[0]);
                Console.WriteLine("");

                Console.WriteLine("*****************************");
            }
            Console.WriteLine("");
            Console.WriteLine($"Your mark in the exam is: {mark} from {sum}");
        }


    }
}
