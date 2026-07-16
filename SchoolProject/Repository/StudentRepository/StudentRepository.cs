using SchoolProject.Models;
using SchoolProject.Repository;
using SchoolProject.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class StudentRepository : IStudentRepository
    {

        private readonly MyDbContext _myDbConnection;

        public StudentRepository(MyDbContext myDbContext)
        {

            _myDbConnection = myDbContext;
        
        }

        public List<Student> GetAllStudents()
        {

            try
            {
                List<Student> students = (from studsobj in _myDbConnection.Students
                                          select studsobj).ToList();
                return students;
            }

            catch(Exception ex)
            {
                return null;
            
            }

        }


        public void Create(Student student)
        {
            _myDbConnection.Students.Add(student);
            _myDbConnection.SaveChanges();


        }

        public void Delete(int id)
        {

            //FirstOrDefault() the first val returned
            Student student = (from studobj in _myDbConnection.Students
                               where studobj.StudentId == id
                               select studobj).FirstOrDefault();



            //if i want to write linq query return one val no obj

            /*string studentname = (from myobj in _myDbConnection.Students
                                  select myobj.StudentName).FirstOrDefault();*/

            _myDbConnection.Students.Remove(student);
            _myDbConnection.SaveChanges();
        
        }


       
        public void Register(int StudentId, int CourseId)
        {
            //two way to execute that

            /*one way
            StudentCourse obj= new StudentCourse();
            obj.StudentId = StudentId;
            obj.CourseId = CourseId;
            _myDbConnection.StudentCourses.Add(obj);
            _myDbConnection.SaveChanges();
            */

            //second way

            _myDbConnection.StudentCourses.Add(new StudentCourse
            {
                StudentId=StudentId,
                CourseId=CourseId
            
            }); 


            _myDbConnection.SaveChanges();


        }


    }
}
