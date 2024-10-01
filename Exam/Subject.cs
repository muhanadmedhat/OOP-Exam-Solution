using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Exam
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public int ExamOfSubject { get; set; }

        public Exams exams { get; set; }

        public Subject(int subjectId, string subjectName, int examOfSubject, Exams exams)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            ExamOfSubject = examOfSubject;
            this.exams = exams;
        }

        public void CreateExam(Exams exam)
        {
            exams = exam;
            if (exams != null && exams is Final)
            {
                int cnt = 0;
                while (cnt < exams.NumberOfQuestions)
                {
                    bool flag;
                    int type;
                    do {
                        Console.WriteLine("Choose type of question(1 for MCQ and 2 for True & False)");
                        flag=int.TryParse(Console.ReadLine(), out type);
                    } while (flag==false || (type!=1 && type!=2));
                   
                    if (type == 1)
                    {
                        Answers[] AnswerList = new Answers[3];
                        string body;
                        do {
                            Console.WriteLine("Please enter Question body");
                             body = Console.ReadLine();
                        } while (body =="");

                        int mark;
                        do
                        {
                            Console.WriteLine("Please enter mark of question");
                            flag=int.TryParse(Console.ReadLine(), out mark);
                        } while (flag==false || mark<=0);
                        string header = $"MCQ question Mark:{mark}";


                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine($"Please enter choice number {i+1}");
                            string text;
                            do
                            {
                                text = Console.ReadLine();
                            } while (text == "");
                            AnswerList[i] = new Answers(i + 1, text);
                        }
                        int id;
                        do {
                            Console.WriteLine("Please enter right answer ID");
                            flag=int.TryParse(Console.ReadLine(), out id);

                        } while (flag==false || (id!=1 && id!=2 && id!=3));
                        int CorrectAnswer = id;
                        MCQ mcq = new MCQ(header, body, mark, AnswerList,CorrectAnswer);
                        exam.questions[cnt] = mcq;
                        Console.WriteLine("");
                    }
                    else if (type == 2)
                    {
                        Answers[] AnswerList = new Answers[1];
                        string body;
                        do
                        {
                            Console.WriteLine("Please enter Question body");
                            body = Console.ReadLine();
                        } while (body == "");


                        int mark;
                        do
                        {
                            Console.WriteLine("Please enter mark of question");
                            flag = int.TryParse(Console.ReadLine(), out mark);
                        } while (flag == false || mark <= 0);

                        string header = $"True/False question Mark:{mark}";
                        int choosedanswer;
                        do {
                            Console.WriteLine("Enter 1 for true 2 for false");
                            flag=int.TryParse(Console.ReadLine(), out choosedanswer);
                        } while (flag==false || (choosedanswer!=1 && choosedanswer!=2));
                        int correctanswer;
                        if (choosedanswer == 1)
                        {
                            AnswerList[0] = new Answers(1, "true");
                            correctanswer = 1;
                        }
                        else
                        {
                            AnswerList[0] = new Answers(2, "false");
                            correctanswer = 2;
                        }
                        TrueFalse trueFalse = new TrueFalse(header, body, mark, AnswerList,correctanswer);
                        exam.questions[cnt] = trueFalse;
                        Console.WriteLine("");
                    }
                    cnt++;
                    Console.Clear();
                }

                /* for (int i = 0; i < exams.NumberOfQuestions; i++)
                 {
                     Console.WriteLine(exam.questions[i].Header);
                     Console.WriteLine(exam.questions[i].Mark);
                     Console.WriteLine(exam.questions[i].Body);
                     for (int j = 0; j < exams.questions[i].AnswerList.Length; j++)
                     {
                         Console.WriteLine(exams.questions[i].AnswerList[j]);
                     }
                 }*/

            }

            if (exams != null && exams is Practical)
            {
                int cnt = 0;
                bool flag;
                while (cnt < exams.NumberOfQuestions)
                {

                    Answers[] AnswerList = new Answers[1];

                    string body;
                    do
                    {
                        Console.WriteLine("Please enter Question body");
                        body = Console.ReadLine();
                    } while (body == "");

                    int mark;
                    do
                    {
                        Console.WriteLine("Please enter mark of question");
                        flag = int.TryParse(Console.ReadLine(), out mark);
                    } while (flag == false || mark <= 0);

                    string header = $"True/False question Mark:{mark}";

                    int choosedanswer;
                    do
                    {
                        Console.WriteLine("Enter 1 for true 2 for false");
                        flag = int.TryParse(Console.ReadLine(), out choosedanswer);
                    } while (flag == false || (choosedanswer != 1 && choosedanswer != 2));

                    int correctanswer;
                    if (choosedanswer == 1)
                    {
                        AnswerList[0] = new Answers(1, "true");
                        correctanswer = 1;
                    }
                    else
                    {
                        AnswerList[0] = new Answers(2, "false");
                        correctanswer = 2;
                    }
                    TrueFalse trueFalse = new TrueFalse(header, body, mark, AnswerList, correctanswer);
                    exam.questions[cnt] = trueFalse;
                    Console.WriteLine("");
                    cnt++;
                    Console.Clear();
                }

                /*for (int i = 0; i < exams.NumberOfQuestions; i++)
                {
                    Console.WriteLine(exam.questions[i].Header);
                    Console.WriteLine(exam.questions[i].Mark);
                    Console.WriteLine(exam.questions[i].Body);
                    for (int j = 0; j < exams.questions[i].AnswerList.Length; j++)
                    {
                        Console.WriteLine(exams.questions[i].AnswerList[j]);
                    }
                }*/
            }
            
        }
    }
}
