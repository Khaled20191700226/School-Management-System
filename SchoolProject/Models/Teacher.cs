using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TeacherId { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string TeacherName { get; set; }

        [Range(22, 60)] 
        public int TeacherAge { get; set; }



    }
}
