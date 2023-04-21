using LINQ_Labb.Data;
using LINQ_Labb.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using LINQ_Labb.Utillity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace LINQ_Labb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DBMethods.DisplayAllSubjects();
            //CourseNameExist("Programmering 2");
            // DBMethods.EditCourseName("OOP", "Programmering 2");
            //DBMethods.ChangeAnasToReidar("Reidar");
            //DBMethods.GetAllCourseTeachers();

            // EditTeacherCourseAnasToReidar();

            ConsoleMenu.Run();

        }

       
    
        



        

    }
}