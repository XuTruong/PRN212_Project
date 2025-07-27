using DataAccess.Models;
using Moq;
using Repositories;
using Services;

namespace UnitTests
{
    public class RoomServiceTests
    {
        private readonly Mock<RoomRepo> _mockRoomRepo;
        private readonly RoomService _roomService;

        public RoomServiceTests()
        {
            _mockRoomRepo = new Mock<RoomRepo>();
            _roomService = new RoomService(_mockRoomRepo.Object);
        }

        [Fact]
        public void GetAllRooms_ShouldReturnAllRooms()
        {
            // Arrange
            var rooms = new List<Room>
            {
                new Room { RoomId = 1, RoomName = "Room 101", Status = "Available", Price = 100 },
                new Room { RoomId = 2, RoomName = "Room 102", Status = "Occupied", Price = 120 }
            };
            _mockRoomRepo.Setup(repo => repo.GetAllRooms()).Returns(rooms);

            // Act
            var result = _roomService.GetAllRooms();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Room 101", result[0].RoomName);
        }

        [Fact]
        public void SearchRooms_ShouldReturnMatchingRooms()
        {
            // Arrange
            var rooms = new List<Room>
            {
                new Room { RoomId = 1, RoomName = "Deluxe Room", Status = "Available", Price = 200 },
                new Room { RoomId = 2, RoomName = "Standard Room", Status = "Available", Price = 100 }
            };
            _mockRoomRepo.Setup(repo => repo.SearchRooms("Deluxe")).Returns(new List<Room> { rooms[0] });

            // Act
            var result = _roomService.SearchRooms("Deluxe");

            // Assert
            Assert.Single(result);
            Assert.Equal("Deluxe Room", result[0].RoomName);
        }

        [Fact]
        public void UpdateRoom_ShouldCallUpdateRoomOnRepo()
        {
            // Arrange
            var roomToUpdate = new Room { RoomId = 1, RoomName = "Updated Room", Status = "Available", Price = 150 };

            // Act
            _roomService.UpdateRoom(roomToUpdate);

            // Assert
            _mockRoomRepo.Verify(repo => repo.UpdateRoom(roomToUpdate), Times.Once);
        }

        [Fact]
        public void CreateRoom_ShouldCallCreateRoomOnRepo()
        {
            // Arrange
            var newRoom = new Room { RoomName = "New Room", Status = "Available", Price = 180 };

            // Act
            _roomService.CreateRoom(newRoom);

            // Assert
            _mockRoomRepo.Verify(repo => repo.CreateRoom(newRoom), Times.Once);
        }

        [Fact]
        public void DeleteRoom_ShouldCallDeleteRoomOnRepo()
        {
            // Arrange
            var roomIdToDelete = 1;

            // Act
            _roomService.DeleteRoom(roomIdToDelete);

            // Assert
            _mockRoomRepo.Verify(repo => repo.DeleteRoom(roomIdToDelete), Times.Once);
        }
    }
}
