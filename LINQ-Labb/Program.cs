using LINQ_Labb.Data;
using LINQ_Labb.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using LINQ_Labb.Utillity;

namespace LINQ_Labb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Get all teachers that do math.
            //// GetAllCourseTeachers();
            GetAllTeachersWithStudent();
            //Get all teachers with their connected teacher


            //DBMethods.DisplayAll();
            // DisplayTeacherConnection("Mathematics");
            //AddTeacherToCourse(4, 1);
            //AddTeacherToCourse(5, 2);
            //AddTeacherToCourse(7, 3);

            // DisplayTeacherConnection();


        }

        public static void GetAllTeachersWithStudent()
        {
            using (var db = new Context())
            {
                //      var query = db.Course
                //.SelectMany(c => c.Student, (course, student) => new { Course = course, Student = student })
                //.Join(db.Teacher,
                //    x => x.Course.Teacher,
                //    tc => tc.Course,
                //    (x, tc) => new { Course = x.Course, Student = x.Student, TeacherCourse = tc })
                //.Join(db.Teacher,
                //    x => x.TeacherCourse.TeacherId,
                //    t => t.Id,
                //    (x, t) => new { Course = x.Course, Student = x.Student, Teacher = t });

                //      foreach (var row in query)
                //      {
                //          Console.WriteLine($"Course: {row.Course.Name}, Student: {row.Student.FirstName} {row.Student.LastName}, Teacher: {row.Teacher.FirstName} {row.Teacher.LastName}");
                //      }


                //  };
                var course = db.Course.Include(x => x.Student).Include(t => t.Teacher).ToList();

                foreach (var i in course)
                {
                    Console.WriteLine();
                    Console.WriteLine($"\t##\t\t\t##");
                    Console.WriteLine($"\t   Course: {i.Name}");
                    Console.WriteLine($"\t##\t\t\t##");
                    Console.WriteLine();

                    foreach (var s in i.Student)
                    {
                        if(s.FirstName.Length != 10)
                        {
                            for (int c = s.FirstName.Length; c != 10; c++)
                            {
                                s.FirstName += " ";
                            }
                        }
                        Console.Write($"Student: {s.FirstName}  Teachers: ");

                        foreach (var c in i.Teacher)
                        {
                            Console.Write($"{c.FirstName} ");
                        }

                        Console.WriteLine();
                    }
                }


            }


            //using (var db = new Context())
            //{
            //    var course = db.Course.Include(c => c.Teacher).Include(s => s.Teacher).ToList();

            //    foreach (var co in course)
            //    {
            //        Console.WriteLine($"{co.Name}");

            //        foreach (var st in co.Student)
            //        {
            //            Console.WriteLine($"Student: {st.FirstName}");
            //        }
            //        foreach (var te in co.Teacher)
            //        {
            //            Console.WriteLine($"Teacher:{te.FirstName} {te.LastName}");
            //        }
            //    }
            //}
        }
            public static void AddTeacherToCourse(int courseID, int teacherID)
        {
            using(var db = new Context())
            {
                var selectCourse = db.Course.FirstOrDefault(c => c.CourseID == courseID);

                var selectTeacher = db.Teacher.FirstOrDefault(t=>t.TeacherID == teacherID);

                selectCourse.Teacher = new List<Teacher>()
                {
                    selectTeacher
                };


                db.SaveChanges();

            }
        } 
        public static void RemoveTeacherInCourse(int teacherID)
        {
            //using(var db = new Context())
            //{
            //    var select = db.Course.Include(c => c.Teacher).ToList();

            //    select.RemoveAll(x => x.CourseID != 0);
            //    select.


            //    db.SaveChanges();

            //}
        }
        public static void GetAllCourseTeachers() 
        {
            using(var db = new Context())
            {
                var course = db.Course.Include(t => t.Teacher).ToList();

                foreach (var c in course)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("****************************************");
                    Console.ForegroundColor = ConsoleColor.Red;


                    Console.WriteLine($"ID:{c.CourseID} Course: {c.Name}");


                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("****************************************");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    foreach (var t in c.Teacher)
                    {
                        Console.WriteLine($"ID:{t.TeacherID} Name: {t.FirstName} {t.LastName}");
                        Console.WriteLine();
                    }
                }

            }
        }
        public static void DisplayTeacherConnection(string courseName)
        {
            //using (var db = new Context())
            //{
            //    var course = db.Course.FirstOrDefault(c=>c.Name ==  courseName);

            //    foreach (var i in course)
            //    {
            //        Console.WriteLine($"Course:{i}, Teachers:");

            //        foreach (var t in course.Teacher)
            //        {
            //            Console.WriteLine($"ID: {t.TeacherID} Name:{t.FirstName}");
            //        }
            //    }
            //}
        }

    }
}