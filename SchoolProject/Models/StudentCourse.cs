using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class StudentCourse
    {
        //one thing :make pk for this entity
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int StudentCourseId { get; set; }


        public int StudentId { get; set; }
        public Student student { get; set; }

        public int CourseId { get; set; }
        public Course course { get; set; }

    }
}
