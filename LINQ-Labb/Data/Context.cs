using LINQ_Labb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb.Data
{
    internal class Context : DbContext
    {
        DbSet<Student> Student { get; set; }
        DbSet<Teacher> Teacher { get; set; }
        DbSet<Course> Course { get; set; }
        DbSet<Subject> Subject { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-273ULK4\\SQLEXPRESS;Database=LabbLinq;Encrypt=False;Trusted_Connection=True;");
        }
        
    }
}
