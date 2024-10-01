using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Final : Exams
    {
      public Final(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {

        }

        public int[] Answer;
        public int mark;
        public int sum;
        public override void ShowExam(Exams exam)
        {
            mark = 0;
            sum = 0;
            Answer = new int[exam.questions.Length];
            bool flag;
            if (exam is not null) {
                for (int i = 0; i < exam.questions.Length; i++)
                {
                    Console.WriteLine(exam.questions[i].Header);
                    Console.WriteLine("");
                    //Console.WriteLine(exam.questions[i].Mark);
                    Console.WriteLine(exam.questions[i].Body);
                    Console.WriteLine("");
                    if (exam.questions[i] is MCQ)
                    {
                        for (int j = 0; j < exam.questions[i].AnswerList.Length; j++)
                        {
                            Console.WriteLine(exam.questions[i].AnswerList[j]);
                        }
                        int answerId;
                        do {
                            Console.WriteLine("(Please enter the Answer Id)");
                            flag=int.TryParse(Console.ReadLine(), out answerId);
                        } while (flag==false || (answerId!=1 && answerId!=2 && answerId!=3));
                        Answer[i] = answerId;
                        if (exam.questions[i].CorrectAnswer == answerId)
                            mark += exam.questions[i].Mark;
                    }
                    else if (exam.questions[i] is TrueFalse)
                    {
                        int answerId;
                        do
                        {
                            Console.WriteLine("(Enter 1 for true or 2 for false)");
                            flag = int.TryParse(Console.ReadLine(), out answerId);
                        } while (flag == false || (answerId != 1 && answerId != 2));

                        Answer[i] = answerId;
                        /*string TrueFalseAnswer;
                        if (answerId == 1)
                            TrueFalseAnswer = "true";
                        else
                            TrueFalseAnswer = "false";*/

                        if (exam.questions[i].CorrectAnswer == answerId)
                        {
                            mark += exam.questions[i].Mark;
                        }
                    }
                    sum += exam.questions[i].Mark;
                    Console.WriteLine("****************************");
                }
                
            }
        }

       
        public override void ShowRightAnswers(Exams exam)
        {
            for(int i = 0; i < exam.questions.Length; i++)
            {
                Console.Write($"Question {i+1}: ");
                Console.WriteLine(exam.questions[i].Body);
                Console.Write("Your answer is: ");
                if (exam.questions[i] is MCQ)
                {                
                    int answer = Answer[i];
                    Console.WriteLine(exam.questions[i].AnswerList[answer - 1]);
                    Console.Write("The right answer is: ");
                    Console.WriteLine(exam.questions[i].AnswerList[exam.questions[i].CorrectAnswer - 1]);
                }
                else
                {
                    int answer = Answer[i];
                    string result;
                    if(answer == 1)
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
                }
                Console.WriteLine("");

                Console.WriteLine("*****************************");
            }
            Console.WriteLine("");
            Console.WriteLine($"Your mark in the exam is: {mark} from {sum}");
        }

    }
}
