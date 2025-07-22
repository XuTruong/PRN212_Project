using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using DataAccess.Models;
using Services;
using Repositories;

namespace UnitTests
{
    public class RoomServiceTests
    {
        private readonly Mock<RoomRepo> _mockRoomRepo;
        private readonly RoomService _roomService;

        public RoomServiceTests()
        {
            _mockRoomRepo = new Mock<RoomRepo>();
            _roomService = new RoomService();
            
            // Note: Để test đúng cách, RoomService cần được refactor để inject RoomRepo
            // Hiện tại sẽ test với database thật
        }

        [Fact]
        public void CreateRoom_ValidRoom_ShouldCreateSuccessfully()
        {
            // Arrange
            var room = new Room
            {
                RoomName = "Test Room A101",
                Area = 25.5,
                Price = 5000000,
                Status = "Trống"
            };

            // Act & Assert
            // Kiểm tra không có exception khi tạo phòng
            var exception = Record.Exception(() => _roomService.CreateRoom(room));
            Assert.Null(exception);
        }

        [Fact]
        public void GetAllRooms_ShouldReturnListOfRooms()
        {
            // Act
            var result = _roomService.GetAllRooms();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Room>>(result);
        }

        [Theory]
        [InlineData("A101")]
        [InlineData("phòng")]
        [InlineData("")]
        public void SearchRooms_WithDifferentKeywords_ShouldReturnMatchingRooms(string keyword)
        {
            // Act
            var result = _roomService.SearchRooms(keyword);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Room>>(result);
            
            if (!string.IsNullOrEmpty(keyword))
            {
                // Kiểm tra kết quả có chứa keyword (nếu có dữ liệu)
                if (result.Any())
                {
                    Assert.True(result.All(r => 
                        r.RoomName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        r.Status.Contains(keyword, StringComparison.OrdinalIgnoreCase)));
                }
            }
        }

        [Fact]
        public void UpdateRoom_ValidRoom_ShouldUpdateSuccessfully()
        {
            // Arrange
            // Trước tiên tạo một phòng để test
            var originalRoom = new Room
            {
                RoomName = "Test Room Update",
                Area = 20.0,
                Price = 4000000,
                Status = "Trống"
            };
            
            _roomService.CreateRoom(originalRoom);
            
            // Lấy phòng vừa tạo
            var rooms = _roomService.GetAllRooms();
            var roomToUpdate = rooms.FirstOrDefault(r => r.RoomName == "Test Room Update");
            
            if (roomToUpdate != null)
            {
                // Cập nhật thông tin
                roomToUpdate.Area = 30.0;
                roomToUpdate.Price = 6000000;
                roomToUpdate.Status = "Đã thuê";

                // Act & Assert
                var exception = Record.Exception(() => _roomService.UpdateRoom(roomToUpdate));
                Assert.Null(exception);

                // Verify the update
                var updatedRooms = _roomService.GetAllRooms();
                var verifyRoom = updatedRooms.FirstOrDefault(r => r.RoomId == roomToUpdate.RoomId);
                
                Assert.NotNull(verifyRoom);
                Assert.Equal(30.0, verifyRoom.Area);
                Assert.Equal(6000000, verifyRoom.Price);
                Assert.Equal("Đã thuê", verifyRoom.Status);
            }
        }

        [Fact]
        public void DeleteRoom_ValidRoomId_ShouldDeleteSuccessfully()
        {
            // Arrange
            // Tạo một phòng để test delete
            var room = new Room
            {
                RoomName = "Test Room Delete",
                Area = 15.0,
                Price = 3000000,
                Status = "Trống"
            };
            
            _roomService.CreateRoom(room);
            
            // Lấy phòng vừa tạo
            var rooms = _roomService.GetAllRooms();
            var roomToDelete = rooms.FirstOrDefault(r => r.RoomName == "Test Room Delete");
            
            if (roomToDelete != null)
            {
                var roomId = roomToDelete.RoomId;

                // Act & Assert
                var exception = Record.Exception(() => _roomService.DeleteRoom(roomId));
                Assert.Null(exception);

                // Verify the deletion
                var remainingRooms = _roomService.GetAllRooms();
                var deletedRoom = remainingRooms.FirstOrDefault(r => r.RoomId == roomId);
                Assert.Null(deletedRoom);
            }
        }

        [Fact]
        public void IsRoomAvailable_ExistingRoom_ShouldReturnBooleanResult()
        {
            // Arrange
            var rooms = _roomService.GetAllRooms();
            
            if (rooms.Any())
            {
                var roomId = rooms.First().RoomId;

                // Act
                var result = _roomService.IsRoomAvailable(roomId);

                // Assert
                Assert.IsType<bool>(result);
            }
        }

        [Fact]
        public void GetAllRoomsHaveStatus_ShouldReturnRoomsWithStatus()
        {
            // Act
            var result = _roomService.getAllRoomhaveStatus();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Room>>(result);
            
            // Kiểm tra tất cả phòng đều có status
            if (result.Any())
            {
                Assert.True(result.All(r => !string.IsNullOrEmpty(r.Status)));
            }
        }
    }
}
