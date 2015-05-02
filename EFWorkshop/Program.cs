using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EFWorkshop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter option");
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.A:
                    LazyLoading();
                    break;
                case ConsoleKey.B:
                    EagerLoading();
                    break;
                case ConsoleKey.C:
                    ExplicitLoading();
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }

        private static void LazyLoading()
        {
            using (var ctx = new WorkshopContext())
            {

                var student = ctx.Students.FirstOrDefault();

                Console.WriteLine("Student Name " + student.Name);
                Console.WriteLine("Class Name " + student.StudentClass.Name);
            }

        }

        private static void EagerLoading()
        {
            using (var ctx = new WorkshopContext())
            {

                var student = ctx.Students
                    .Where(s => s.Name.Equals("Vanita"))
                    .Include(a => a.StudentClass)
                    .FirstOrDefault();

                Console.WriteLine("Student Name " + student.Name);
                Console.WriteLine("Class Name " + student.StudentClass.Name);
            }
            
        }
        private static void ExplicitLoading()
        {
            using (var ctx = new WorkshopContext())
            {

                var student = ctx.Students
                    .Where(s => s.Name.Equals("Vanita"))
                    .Select(s => new
                    {
                       StudentName = s.Name,
                       ClassName = s.StudentClass.Name
                    })
                    .FirstOrDefault();

                Console.WriteLine("Student Name " + student.StudentName);
                Console.WriteLine("Class Name " + student.ClassName);
            }

        }
    }
}
