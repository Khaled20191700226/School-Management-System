using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class TeacherController : Controller
    {

        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        
        }

        [HttpGet]
        public ActionResult Index()
        {
           List<Teacher>teacherLst= _teacherRepository.GetAllTeacherts();
           return View(teacherLst);
        
        
        }


        [HttpGet]
        public ViewResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(Teacher teacher)
        {
            if (teacher != null)
            {
                _teacherRepository.Create(teacher);

            }

            List<Teacher> teacherLst = _teacherRepository.GetAllTeacherts();
            return View("Index", teacherLst);
        
        }


        public ViewResult Delete(int id)
        {
            if (id > 0)
            {
                _teacherRepository.Delete(id);
            }

            List<Teacher> teacherLst = _teacherRepository.GetAllTeacherts();
            return View("Index", teacherLst);


        }




    }
}
