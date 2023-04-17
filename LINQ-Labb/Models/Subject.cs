using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb.Models
{
    internal class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        [Required]
        public string Name { get; set; }
        public Course Course { get; set; }
    }

}
