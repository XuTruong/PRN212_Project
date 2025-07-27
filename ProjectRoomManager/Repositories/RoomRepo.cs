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
        public virtual List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public virtual List<Room> GetAllRoomsHaveStatus()
        {
            return _context.Rooms.Where(r => r.Status.Equals("Đang thuê")).ToList();
        }

        public virtual List<Room> GetAllRoomsHaveStatusOccupied()
        {
            return _context.Rooms.Where(r => r.Status.Equals("Trống")).ToList();
        }

        public virtual void CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public virtual bool RoomExists(string roomName)
        {
            return _context.Rooms.Any(r => r.RoomName.ToLower() == roomName.ToLower());
        }

        public virtual void UpdateRoom(Room roomUpdate)
        {
            _context.Rooms.Update(roomUpdate);
            _context.SaveChanges();
        }

        public virtual void DeleteRoom(int roomId)
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
        public virtual List<Room> SearchRooms(string roomName)
        {
            string searchTerm = roomName.ToLower();
            return _context.Rooms
                .Where(r => r.RoomName.ToLower().Contains(searchTerm))
                .ToList();
        }

        public virtual bool IsRoomAvailable(int roomId)
        {
            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                return true;
            }
            return false;
        }

        public virtual void UpdateAfterHaveContract(int roomId)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
            room.Status = "Đang thuê";
            _context.SaveChanges();
        }

        public virtual decimal GetCurrentRoomPrice(int roomId)
        {
            Room room = _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
            return (decimal)(room != null ? room.Price : 0);
        }

        public virtual int GetRoomIdByContractId(int contractId)
        {
            Contract con = _context.Contracts.FirstOrDefault(c => c.ContractId == contractId);
            return (int)con.RoomId;
        }

        public virtual List<Room> GetRoomsWithActiveContracts()
        {
            return _context.Rooms
                .Where(r => _context.Contracts
                    .Any(c => c.RoomId == r.RoomId && c.IsActive == true))
                .ToList();
        }
    }
}
