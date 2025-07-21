using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repositories;

namespace Services
{
    public class RoomService
    {
        RoomRepo RoomRepo;

        public RoomService()
        {
            RoomRepo = new RoomRepo();
        }

        public List<Room> GetAllRooms()
        {
            return RoomRepo.GetAllRooms();
        }

        public List<Room> SearchRooms(string roomName)
        {
            return RoomRepo.SearchRooms(roomName);
        }

        public void UpdateRoom(Room roomUpdate)
        {
            RoomRepo.UpdateRoom(roomUpdate);
        }

        public bool IsRoomAvailable(int roomId)
        {
            return RoomRepo.IsRoomAvailable(roomId);
        }

        public void CreateRoom(Room room)
        {
            RoomRepo.CreateRoom(room);
        }

        public void DeleteRoom(int roomId) { RoomRepo.DeleteRoom(roomId); }

        public List<Room> getAllRoomhaveStatus()
        {
            return RoomRepo.GetAllRoomsHaveStatus();
        }

        public List<Room> GetAllRoomsHaveStatusOccupied()
        {
            return  RoomRepo.GetAllRoomsHaveStatusOccupied();
        }

        public decimal GetCurrentRoomPrice(int roomId)
        {
            return RoomRepo.GetCurrentRoomPrice(roomId);
        }

        public int GetRoomIdByContractId(int contractId)
        {
            return RoomRepo.GetRoomIdByContractId(contractId);
        }
    }
}
