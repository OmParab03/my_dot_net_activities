// See https://aka.ms/new-console-template for more information


using StudentCRUDApp.Data;
using student_CRUD_app.models;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {
            // CREATE
            var student = new Student
            {   
                Name = "omkar",
                Age = 20,
                Email = "omkar@example.com"
            };
            context.Students.Add(student);
            context.SaveChanges();

            Console.WriteLine("Student Added!");

            // READ
            var students = context.Students.ToList();
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Id} {s.Name}");
            }

            // UPDATE
            var firstStudent = context.Students.FirstOrDefault();
            if (firstStudent != null)
            {
                firstStudent.Name = "Updated";
                context.SaveChanges();
                Console.WriteLine("Student Updated!");
            }

            // DELETE
            var deleteStudent = context.Students.FirstOrDefault();
            if (deleteStudent != null)
            {
                context.Students.Remove(deleteStudent);
                context.SaveChanges();
                Console.WriteLine("Student Deleted!");
            }
        }
    }
}
