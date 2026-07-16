using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class CourseRepository:ICourseRepository
    {

        private readonly MyDbContext _myDbContext;


        public CourseRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;

        }

        public void Create(Course course)
        {
            _myDbContext.Courses.Add(course);
            _myDbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            Course course = (from courseobj in _myDbContext.Courses
                         where courseobj.CourseId == id
                         select courseobj).FirstOrDefault();

            _myDbContext.Courses.Remove(course);
            _myDbContext.SaveChanges();

        }

        public List<Course> GetAllCourses()
        {

            List<Course> courses = (from courseobj in _myDbContext.Courses
                                select courseobj).ToList();

            return courses;

        }



    }
}
