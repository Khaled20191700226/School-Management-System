using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class TeacherRepository :ITeacherRepository
    {

        private readonly MyDbContext _myDbContext;


        public TeacherRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
       
        }

        public void Create(Teacher teacher)
        {
            _myDbContext.Teachers.Add(teacher);
            _myDbContext.SaveChanges();
        
        }

        public void Delete(int id)
        {
            Teacher teacher = (from teacherobj in _myDbContext.Teachers
                               where teacherobj.TeacherId==id
                               select teacherobj).FirstOrDefault();

            _myDbContext.Teachers.Remove(teacher);
            _myDbContext.SaveChanges();
        
        }

        public List<Teacher> GetAllTeacherts()
        {

            List<Teacher> teachers = (from teacherobj in _myDbContext.Teachers
                                      select teacherobj).ToList();

            return teachers;
        


        }
    }
}
