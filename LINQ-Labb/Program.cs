using LINQ_Labb.Data;
using LINQ_Labb.Models;
using Microsoft.EntityFrameworkCore;

namespace LINQ_Labb
{
    internal class Program
    {
        public static int CourseCounter = 3;
        static void Main(string[] args)
        {
            //AddCourse("Mathemathics");
            //AddSubject("Algebra",1);
            // AddCourse("Programmering 2");
            //AddSubject("Advanced .Net",2);
            //AddCourse("Dancing");
            //AddSubject("BoogieWoogie", 3);


            //AddSubject("Algebra", 4);

            AddSubject("Avancerad .Net", 5);

            DisplayAllCourses();
            DisplayAllSubjects();




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
            var subjects = db.Subject.ToList();
            Console.WriteLine("************************");
            Console.WriteLine("Displaying all subjects registered in school.");
            foreach (var c in subjects)
            {
                Console.WriteLine($"#{c.SubjectID} Course: {c.Name}");
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

            CourseCounter++; //Increment course counter by 1 to keep track of index for subject.

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
           // subject.CourseID = 10;


            db.Subject.Add(subject);
            db.SaveChanges();

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