using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _RoomRepository;

        public RoomController(IRoomRepository RoomRepository)
        {
            _RoomRepository = RoomRepository;

        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Room> rooms = _RoomRepository.GetAllRooms();
            return View(rooms);
        
        }


        [HttpGet]
        public ViewResult create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult create(Room room)
        {
            if (room != null)
            {
                _RoomRepository.Create(room);

            }

            List<Room> rooms = _RoomRepository.GetAllRooms();
            return View("Index", rooms);

        }


        public ViewResult Delete(int id)
        {


            if (id > 0)
            {
                _RoomRepository.Delete(id);
            }
            List<Room> rooms = _RoomRepository.GetAllRooms();
            return View("Index", rooms);
        
        
        }



    }
}
