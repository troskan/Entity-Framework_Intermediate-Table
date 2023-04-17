using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb.Models
{
    internal class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Teacher> Teacher { get; set; }
        public ICollection<Student> Student { get; set; }

    }
}
