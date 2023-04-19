using LINQ_Labb.Data;
using LINQ_Labb.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace LINQ_Labb
{
    internal class Program
    {
        public static int CourseCounter = 3;
        static void Main(string[] args)
        {
            DisplayAllSubjects();


            DisplayCoursesWithStudents();
            DisplayAllCourses();



        }
        private static void DisplayCoursesWithStudents()
        {
            using (var db = new Context())
            {
                var jTable = db.Course.Include(s => s.Student).ToList();

                foreach (var c in jTable)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("****************************************");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ID:{c.CourseID} Course: {c.Name}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("****************************************");
                    Console.ForegroundColor = ConsoleColor.White;

                    foreach (var s in c.Student)
                    {
                        Console.WriteLine($"ID: {s.StudentID} Name: {s.FirstName} {s.LastName}");
                    }
                }
                

               
            }
        }
        private static void AddManyStudentsToCourse(int startIndex, int stopIndex, int courseID)
        {
            Context db = new Context();
            var students = db.Student;
            int counter = 0;

            for (int i = startIndex; i <= stopIndex; i++)
            {
                Console.WriteLine($"Added StudentID #{i}");
                AddStudentToCourse(courseID, i);
                counter++;
            }
            Console.WriteLine($"Attempt to add {counter} students has been made and is finished.");
        }

        public static void DisplayAllCourses()
        {
            Context db = new Context();
            var courses = db.Course.ToList();
            Console.WriteLine("************************");
            Console.WriteLine("Displaying all courses registered in school.");
            foreach (var c in courses)
            {
                Console.WriteLine($"#{c.CourseID} Course: {c.Name}");
            }
        }
        public static void DisplayAllSubjects()
        {
            Context db = new Context();
            var subjects = db.Subject.Include(c=>c.Course).ToList();
            Console.WriteLine("************************");
            Console.WriteLine("Displaying all subjects registered in school.");
            var courseName = "";
            

            foreach (var c in subjects)
            {
                Console.WriteLine($"#{c.SubjectID} Subject: {c.Name} - CourseID: {c.CourseID} Course: {c.Name}");
            }
        }
        public static void DisplayAll()
        {
            Context db = new Context();
            var students = db.Student.ToList();
            var teachers = db.Teacher.ToList();

            Console.WriteLine("************************");
            Console.WriteLine("Displaing all persons registered in school.");
            foreach (var s in students)
            {
                Console.WriteLine($"#{s.StudentID} Student: {s.FirstName} {s.LastName}");
            }
            Console.WriteLine("-----");
            foreach (var t in teachers)
            {
                Console.WriteLine($"#{t.TeacherID} Teachers: {t.FirstName} {t.LastName}");
            }
        }

        public static void AddStudent(string fname,string lname)
        {
            Context db = new Context();
            Student student = new Student();

            student.FirstName = fname;
            student.LastName = lname;
           
            db.Student.Add(student);

            db.SaveChanges();
            Console.WriteLine($"#{student.StudentID} {student.FirstName} {student.LastName} was added successfully!");
        } 
        public static void AddTeacher(string fname,string lname)
        {
            Context db = new Context();
            Teacher teacher = new Teacher();

            teacher.FirstName = fname;
            teacher.LastName = lname;

            db.Teacher.Add(teacher);
            db.SaveChanges();
            Console.WriteLine($"#{teacher.TeacherID} {teacher.FirstName} {teacher.LastName} was added successfully!");
        }
        public static void AddCourse(string courseName)
        {
            Context db = new Context();
            Course course = new Course();

            course.Name = courseName;

            db.Course.Add(course);
            db.SaveChanges();

            Console.WriteLine($"#{course.CourseID} {courseName} was added successfully!");
        }
        public static void AddSubject(string subjectName, int courseID)
        {
            Context db = new Context();
            Subject subject = new Subject();

            var courseObj = db.Course.FirstOrDefault(x => x.CourseID == courseID);
            
            subject.Name = subjectName;
            subject.CourseID = courseID;
            subject.Course = courseObj;
            
            db.Subject.Add(subject);
            db.SaveChanges();

        }

        public static string AddStudentToCourse(int courseID, int studentID)
        {
            using (var db = new Context())
            {
                var selectCourse = db.Course.FirstOrDefault(x => x.CourseID == courseID);

                var student = db.Student.FirstOrDefault(s => s.StudentID == studentID);


                if (db.Student.Contains(db.Student.FirstOrDefault(s => s.StudentID == studentID)))
                {
                    selectCourse.Student = new List<Student> { student };


                    db.SaveChanges();
                    Console.WriteLine($"Sucessfully added Student: ID# {student.StudentID}, Name: {student.FirstName}");
                    return "Successfully added.";
                }

                Console.WriteLine($"Could not add Student: ID# {student.StudentID}, Name: {student.FirstName}");

                return "Error, could not add.";

            }



        }
        public static void DeleteSubject(int subjectID)
        {
            using (Context db = new Context())
            {
                // Retrieve the student with the specified ID
                Subject subject = db.Subject.FirstOrDefault(s => s.SubjectID == subjectID);

                if (subject != null)
                {
                    // Remove the student from the DbSet
                    db.Subject.Remove(subject);

                    // Save changes to the database
                    db.SaveChanges();
                    

                    Console.WriteLine($"#{subject.SubjectID} {subject.Name} was deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Subject with ID {subjectID} not found.");
                }
            }
        }
        public static void DeleteCourse(int courseID)
        {
            using (Context db = new Context())
            {
                // Retrieve the student with the specified ID
                Course course = db.Course.FirstOrDefault(s => s.CourseID == courseID);

                if (course != null)
                {
                    // Remove the student from the DbSet
                    db.Course.Remove(course);
                    
                    // Save changes to the database
                    db.SaveChanges();

                    Console.WriteLine($"#{course.CourseID} {course.Name} was deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Subject with ID {courseID} not found.");
                }
            }
        }

    }
}