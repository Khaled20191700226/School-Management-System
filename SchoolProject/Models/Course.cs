using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class Course
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CourseId { get; set; }
        [MinLength(5)]
        [MaxLength(15)]
        public string CourseName { get; set; }
        
        
        //TeacherId is fk for teacherId pk in teacher 
        public int TeacherId { get; set; }
        public Teacher teacher;


        [Range(0, 25)]
        public int CapicityCourse { get; set; }




    }



}
