using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RoomRepo
    {
        RoomManagerContext _context;

        public RoomRepo()
        {
            _context = new RoomManagerContext();
        }

        // CRUD
        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public List<Room> GetAllRoomsHaveStatus()
        {
            return _context.Rooms.Where(r => r.Status.Equals("Đang thuê")).ToList();
        }

        public List<Room> GetAllRoomsHaveStatusOccupied()
        {
            return _context.Rooms.Where(r => r.Status.Equals("Trống")).ToList();
        }

        public void CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void UpdateRoom(Room roomUpdate)
        {
            _context.Rooms.Update(roomUpdate);
            _context.SaveChanges();
        }

        public void DeleteRoom(int roomId)
        {
            var room = _context.Rooms
                .Include(r => r.Contracts)
                .FirstOrDefault(r => r.RoomId == roomId);

            if (room == null)
                throw new Exception("Room not found.");

            if (room.Contracts != null && room.Contracts.Count > 0)
                throw new Exception("Cannot delete room with active contracts.");

            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }


        // search by RoomName and Status (available, booked, etc.)
        public List<Room> SearchRooms(string roomName)
        {
            List<Room> searchRoom = new List<Room>();

            foreach (var r in GetAllRooms())
            {
                if (r.RoomName.ToLower().Contains(roomName.ToLower()))
                {
                    searchRoom.Add(r);
                }
            }
            return searchRoom;
        }

        public bool IsRoomAvailable(int roomId)
        {
            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                return true;
            }
            return false;
        }

        public void UpdateAfterHaveContract(int roomId)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
            room.Status = "Trống";
            _context.SaveChanges();
        }

        public decimal GetCurrentRoomPrice(int roomId)
        {
            Room room = _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
            return (decimal)(room != null ? room.Price : 0);
        }

        public int GetRoomIdByContractId(int contractId)
        {
            Contract con = _context.Contracts.FirstOrDefault(c => c.ContractId == contractId);
            return (int)con.RoomId;
        }

        public List<Room> GetRoomsWithActiveContracts()
        {
            return _context.Rooms
                .Where(r => _context.Contracts
                    .Any(c => c.RoomId == r.RoomId && c.IsActive == true))
                .ToList();
        }
    }
}
