using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class CourseController : Controller
    {

        private readonly ICourseRepository _CourseRepository;
        private readonly ITeacherRepository _teacherRepository;

        public CourseController(ICourseRepository CourseRepository, ITeacherRepository teacherRepository)
        {
            _CourseRepository = CourseRepository;
            _teacherRepository = teacherRepository;

        }

        [HttpGet]
        public ActionResult Index()
        {

            List<Course>courses= _CourseRepository.GetAllCourses();

            return View(courses);
        
        
        }


        [HttpGet]
        public ViewResult create()
        {
            List<Teacher> teacherLst = _teacherRepository.GetAllTeacherts();

            return View(teacherLst);
        }



        [HttpPost]
        public ActionResult create(Course course)
        {
            if (course != null)
            {
                _CourseRepository.Create(course);

            }

            List<Course> courses = _CourseRepository.GetAllCourses();

            return View("Index",courses);
        }


        public ViewResult Delete(int id)
        {

            if (id > 0)
            {
                _CourseRepository.Delete(id);
            }


            List<Course> courses = _CourseRepository.GetAllCourses();
            return View("Index",courses);


        }



    }
}
