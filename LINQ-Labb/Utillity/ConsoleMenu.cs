using LINQ_Labb.Utillity;
using System;

namespace LINQ_Labb.Utillity
{
    public class ConsoleMenu
    {
        public static void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. #Get Students/Teachers/Course<---");
                Console.WriteLine("2. #Does Course Contain()<---");
                Console.WriteLine("3. #Edit course name<---");
                Console.WriteLine("4. Add subject");
                Console.WriteLine("5. Add student to course");
                Console.WriteLine("6. Delete course");
                Console.WriteLine("7. Delete subject");
                Console.WriteLine("8. Display all persons");
                Console.WriteLine("9. Display all courses");
                Console.WriteLine("10. Display all subjects");
                Console.WriteLine("11. Display courses with students");
                Console.WriteLine("12. Get all course teachers");
                Console.WriteLine("13. Change all teacher name");
                Console.WriteLine("14. Course name exists");
                Console.WriteLine("15. #Change Anas to Reidar <---");

                Console.WriteLine("16. Exit");



                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        string fname;
                        string lname;
                        DBMethods.GetAllTeachersWithStudent();
                        break;

                    case "2":
                        Console.Clear();
                        DBMethods.CourseNameExist("Programmering 2");
                        break;

                    case "3":
                        Console.Clear();
                        DBMethods.EditCourseName("Programmering 2", "OOP");
                        break;

                    case "4":
                        Console.Write("Enter subject name: ");
                        string subjectName = Console.ReadLine();
                        Console.Write("Enter course ID: ");
                        int courseID = int.Parse(Console.ReadLine());
                        DBMethods.AddSubject(subjectName, courseID);
                        break;

                    case "5":
                        Console.Write("Enter course ID: ");
                        courseID = int.Parse(Console.ReadLine());
                        Console.Write("Enter student ID: ");
                        int studentID = int.Parse(Console.ReadLine());
                        DBMethods.AddStudentToCourse(courseID, studentID);
                        break;

                    case "6":
                        Console.Write("Enter course ID: ");
                        courseID = int.Parse(Console.ReadLine());
                        DBMethods.DeleteCourse(courseID);
                        break;

                    case "7":
                        Console.Write("Enter subject ID: ");
                        int subjectID = int.Parse(Console.ReadLine());
                        DBMethods.DeleteSubject(subjectID);
                        break;

                    case "8":
                        DBMethods.DisplayAll();
                        break;

                    case "9":
                        DBMethods.DisplayAllCourses();
                        break;

                    case "10":
                        DBMethods.DisplayAllSubjects();
                        break;

                    case "11":
                        DBMethods.DisplayCoursesWithStudents();
                        break;

                    case "12":
                        DBMethods.GetAllCourseTeachers();
                        break;

                    case "13":
                        Console.Write("Enter old name: ");
                        string oldName = Console.ReadLine();
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        DBMethods.ChangeAllTeacherName(oldName, newName);
                        break;

                    case "14":
                        Console.Write("Enter course name: ");
                        string courseName = Console.ReadLine();
                        DBMethods.CourseNameExist(courseName);
                        break;

                    case "15":
                        Console.Write("Enter teacher to remove (Anas or Reidar): ");
                        string removeTeacher = Console.ReadLine();
                        DBMethods.ChangeAnasToReidar(removeTeacher);
                        break;

                    case "16":

                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }
    }
}

