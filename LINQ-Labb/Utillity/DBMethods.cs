using LINQ_Labb.Data;
using LINQ_Labb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb.Utillity
{
    internal class DBMethods
    {
        public static void ChangeAnasToReidar(string removeTeacher)
        {
            int courseID = 0;
            int oldTeacherID = 0;
            int newTeacherID = 0;


            if (removeTeacher == "Anas")
            {
                courseID = 4;
                oldTeacherID = 1;
                newTeacherID = 3;
                EditTeacherForCourse(courseID, oldTeacherID, newTeacherID);
                Console.WriteLine("Reidar is now teacher.");
            }

            else if (removeTeacher == "Reidar")
            {
                courseID = 4;
                oldTeacherID = 3;
                newTeacherID = 1;
                EditTeacherForCourse(courseID, oldTeacherID, newTeacherID);
                Console.WriteLine("Anas is now teacher.");

            }
            else
            {
                Console.WriteLine("No teacher added.");
            }


        }
        public static void EditTeacherForCourse(int courseID, int oldTeacherID, int newTeacherID)
        {
            using (var db = new Context())
            {
                var course = db.Course.Include(c => c.Teacher).FirstOrDefault(c => c.CourseID == courseID);

                var oldTeacher = course.Teacher.FirstOrDefault(t => t.TeacherID == oldTeacherID);

                if (oldTeacher == null)
                {
                    Console.WriteLine($"Teacher with ID {oldTeacherID} is not associated with course {courseID}.");
                    return;
                }

                var newTeacher = db.Teacher.FirstOrDefault(t => t.TeacherID == newTeacherID);

                if (newTeacher == null)
                {
                    Console.WriteLine($"Teacher with ID {newTeacherID} does not exist.");
                    return;
                }

                course.Teacher.Remove(oldTeacher);
                course.Teacher.Add(newTeacher);

                db.SaveChanges();

                Console.WriteLine($"Teacher with ID {oldTeacherID} has been replaced with teacher with ID {newTeacherID} for course {courseID}.");
            }
        }

        public static void EditCourseName(string courseName, string newCourseName)

        {
            using (var db = new Context())
            {
                var selectCourse = db.Course.FirstOrDefault(c => c.Name == courseName);

                if (selectCourse.Name.Contains(courseName))
                {
                    Course course = selectCourse;

                    course.Name = newCourseName;

                    db.SaveChanges();

                    Console.WriteLine("Name found! Course name has been changed!");
                }
                else
                {
                    Console.WriteLine("Did not find course name, no changes have been made.");
                }


            }
            }
            public static void CourseNameExist(string courseName)
        {
            using (var db = new Context())
            {
                var course = db.Course.Any(s => s.Name == courseName);
                if (course)
                {
                    Console.WriteLine($"{courseName} does exist in subjects!");
                }
                else
                {
                    Console.WriteLine($"{courseName} does not in subjects!");

                }
            }
        }

        public static void GetAllTeachersWithStudent()
        {
            using (var db = new Context())
            {
                var course = db.Course.Include(x => x.Student).Include(t => t.Teacher).ToList();

                foreach (var i in course)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"\t Course: {i.Name}");
                    Console.WriteLine();
                    Console.WriteLine();

                    foreach (var s in i.Student)
                    {
                        if (s.FirstName.Length != 10)
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
        }
        //public static void AddTeacherToCourse(int courseID, int teacherID)
        //{
        //    using (var db = new Context())
        //    {
        //        var selectCourse = db.Course.FirstOrDefault(c => c.CourseID == courseID);

        //        var selectTeacher = db.Teacher.FirstOrDefault(t => t.TeacherID == teacherID);

        //        selectCourse.Teacher = new List<Teacher>()
        //        {
        //            selectTeacher
        //        };

        //        db.SaveChanges();
        //    }
        //}

        //public static void RemoveTeacherInCourse(int teacherID)
        //{
        //    //using(var db = new Context())
        //    //{
        //    //    var select = db.Course.Include(c => c.Teacher).ToList();

        //    //    select.RemoveAll(x => x.CourseID != 0);
        //    //    select.


        //    //    db.SaveChanges();

        //    //}
        //}
        public static void ChangeAllTeacherName(string oldName, string newName)
        {
            using (var db = new Context())
            {
                var selectTeacher = db.Teacher.FirstOrDefault(t => t.FirstName == oldName);

                Teacher editTeacher = selectTeacher;

                editTeacher.FirstName = newName;

                db.SaveChanges();

            }
        }
        public static void GetAllCourseTeachers()
        {
            using (var db = new Context())
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

        public static void DisplayCoursesWithStudents()
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
        public static void AddManyStudentsToCourse(int startIndex, int stopIndex, int courseID)
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
            var subjects = db.Subject.Include(c => c.Course).ToList();
            Console.WriteLine("************************");
            Console.WriteLine("Displaying all subjects registered in school.");
            Console.WriteLine();
            var courseName = "";


            foreach (var s in subjects)
            {
                Console.WriteLine($"SubjectID #{s.SubjectID}\nSubject: {s.Name}\nCourseID: {s.CourseID}\nCourse:{s.Course.Name}");
                Console.WriteLine();
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

        public static void AddStudent(string fname, string lname)
        {
            Context db = new Context();
            Student student = new Student();

            student.FirstName = fname;
            student.LastName = lname;

            db.Student.Add(student);

            db.SaveChanges();
            Console.WriteLine($"#{student.StudentID} {student.FirstName} {student.LastName} was added successfully!");
        }
        public static void AddTeacher(string fname, string lname)
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

            Course courseObj = db.Course.FirstOrDefault(x => x.CourseID == courseID);

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
                var student = db.Student.FirstOrDefault(s => s.StudentID == studentID);
                var selectCourse = db.Course.FirstOrDefault(c => c.CourseID == courseID);

                if (db.Student.Contains(db.Student.FirstOrDefault(s => s.StudentID == studentID)))
                {
                    selectCourse.Student = new List<Student> 
                    { 
                        student
                    };


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
