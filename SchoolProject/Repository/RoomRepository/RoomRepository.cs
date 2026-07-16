using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class RoomRepository:IRoomRepository
    {
        private readonly MyDbContext _myDbContext;


        public RoomRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;

        }

        public void Create(Room room)
        {
            _myDbContext.Rooms.Add(room);
            _myDbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            Room room = (from roomobj in _myDbContext.Rooms
                               where roomobj.RoomId == id
                               select roomobj).FirstOrDefault();

            _myDbContext.Rooms.Remove(room);
            _myDbContext.SaveChanges();

        }

        public List<Room> GetAllRooms()
        {

            List<Room> rooms = (from roomobj in _myDbContext.Rooms
                                      select roomobj).ToList();

            return rooms;

        }

    }
}
