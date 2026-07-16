using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        
        private readonly IStudentRepository _studentRepository;

        private readonly ICourseRepository _courseRepository;

        private readonly IWebHostEnvironment _environment;

        public StudentController(IStudentRepository studentRepository, ICourseRepository courseRepository,
            IWebHostEnvironment environment)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _environment = environment;


        }


        //goal from this Index retrieve list of students

        [HttpGet]
        public ActionResult Index()
        {
            
            //return los and used fDB
            List<Student> stdLst = _studentRepository.GetAllStudents();

            return View(stdLst);
        
        
        }

        //Render the creation view,not contain logic   

        [HttpGet]
        public ViewResult create()
        {


            return View();
        
        }



        //do: create for new student
        [HttpPost]
        public ActionResult create(Student student,IFormFile StudentPicture)
        {
            
            var wwwwrootPath = _environment.WebRootPath + "/StudentPictures/";
            //unique value 
            Guid guid = Guid.NewGuid();
            //save pic in inside file,take from StudentPicture file name and identify full poath
            string fullpath = System.IO.Path.Combine(wwwwrootPath, guid + StudentPicture.FileName);
            //now identify operation save
            //using make despose for stream
            using (var fileStream = new FileStream(fullpath, FileMode.Create))
            {
                //make create in fullpath
                StudentPicture.CopyTo(fileStream);
            }

            student.PictureName = guid + StudentPicture.FileName;

            if (student != null)
            {
                _studentRepository.Create(student);
                
            }


            List<Student> stdLst = _studentRepository.GetAllStudents();
            return View("Index", stdLst);





        }


        [HttpGet]
        public ViewResult Register()
        {
            StudentCourseVM data = new StudentCourseVM();
            //i want to fill the obj with data
            
            data.students= _studentRepository.GetAllStudents();

            data.courses = _courseRepository.GetAllCourses();

            return View(data);
        
        
        }


        [HttpPost]
        public ActionResult Register(int StudentId,int CourseId)
        {


            _studentRepository.Register(StudentId, CourseId);

            return RedirectToAction("Register");

        }


        
        public ViewResult Delete(int id)
        {

            if (id > 0)
            {
                _studentRepository.Delete(id);

            }

            List<Student> stdLst = _studentRepository.GetAllStudents();

            return View("Index", stdLst);


        }







    }
}
