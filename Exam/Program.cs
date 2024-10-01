namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
               
                bool flag;
                int choosed;
                Console.WriteLine("====================CREATE EXAM======================");
                do
                {
                    Console.WriteLine("Please enter type of exam(1 for final and 2 for practical)");
                    flag = int.TryParse(Console.ReadLine(), out choosed);
                } while (flag == false || (choosed != 1 && choosed != 2));

                // Exams exam = new Exams();
                Console.WriteLine("");
                int time;
                do
                {
                    Console.WriteLine("Please enter time of exam(30min to 180min)");
                    flag = int.TryParse(Console.ReadLine(), out time);
                } while (flag == false || (time < 30 || time > 180));
                Console.WriteLine("");
                int num;
                do
                {
                    Console.WriteLine("Please enter number of questions");
                    flag = int.TryParse(Console.ReadLine(), out num);
                } while (flag == false || num <= 0);
                Console.WriteLine("");
                Exams exam;
                Console.Clear();
                if (choosed == 1)
                {
                    exam = new Final(time, num);
                    Subject subject = new Subject(1, "Cs", 1, exam);
                    subject.CreateExam(exam);

                }
                else
                {
                    exam = new Practical(time, num);
                    Subject subject = new Subject(1, "Cs", 1, exam);
                    subject.CreateExam(exam);
                }

                Console.WriteLine("=============================EXAM=================================");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                exam.ShowExam(exam);
                Console.Clear();
                Console.WriteLine("=============================Model Answer==========================");
                exam.ShowRightAnswers(exam);
                
                watch.Stop();
                var elapsedMs = watch.Elapsed;
                Console.Write("Time taken to solve the exam: ");
                Console.WriteLine(elapsedMs);
                Console.WriteLine("Thank You");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
