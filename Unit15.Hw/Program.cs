using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit15.Hw
{
    class Program
    {
        static void Main(string[] args)
        {
            var classes = new[]
            {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
           };
            var allStudents = GetAllStudents(classes);
            Console.WriteLine(string.Join(" ", allStudents));

            Console.ReadKey();
        }

        static string[] GetAllStudents(Classroom[] classes)
        {
            var studentNames = from cl in classes
                               from student in cl.Students
                                   //orderby cl.Students   // здесь и так OrderBy не прошло потому что  cl.Students это List<string>
                               orderby student   //  так OrderBy  прошло и ушло в результат
                               select student;
            //foreach (var studentName in studentNames.OrderBy(s=>s)) // а здесь OrderBy  прошло но естественно только на печать
            //foreach (var studentName in studentNames) // 
            //    Console.WriteLine(studentName);
            //Console.WriteLine("-----------------------------");
            return studentNames.ToArray();
        }

        public class Classroom
        {
            public List<string> Students = new List<string>();
        }
    }
}
