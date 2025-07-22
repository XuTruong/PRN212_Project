# Unit Tests cho Room Manager Project

## Mô tả
Project này chứa Unit Tests cho `RoomService` trong ứng dụng quản lý nhà trọ.

## Cấu trúc
```
UnitTests/
├── UnitTests.csproj          # Project file
├── RoomServiceTests.cs       # Unit tests cho RoomService
└── README.md                # File hướng dẫn này
```

## Các Test Cases

### RoomServiceTests
1. **CreateRoom_ValidRoom_ShouldCreateSuccessfully**
   - Kiểm tra tạo phòng mới với dữ liệu hợp lệ

2. **GetAllRooms_ShouldReturnListOfRooms**
   - Kiểm tra lấy danh sách tất cả phòng

3. **SearchRooms_WithDifferentKeywords_ShouldReturnMatchingRooms**
   - Kiểm tra tìm kiếm phòng với các từ khóa khác nhau
   - Test với: "A101", "phòng", ""

4. **UpdateRoom_ValidRoom_ShouldUpdateSuccessfully**
   - Kiểm tra cập nhật thông tin phòng

5. **DeleteRoom_ValidRoomId_ShouldDeleteSuccessfully**
   - Kiểm tra xóa phòng

6. **IsRoomAvailable_ExistingRoom_ShouldReturnBooleanResult**
   - Kiểm tra trạng thái phòng có sẵn hay không

7. **GetAllRoomsHaveStatus_ShouldReturnRoomsWithStatus**
   - Kiểm tra lấy danh sách phòng có trạng thái

## Cách chạy Unit Tests

### 1. Chạy tất cả tests
```bash
dotnet test UnitTests/UnitTests.csproj
```

### 2. Chạy với thông tin chi tiết
```bash
dotnet test UnitTests/UnitTests.csproj --verbosity normal
```

### 3. Chạy tests cụ thể
```bash
dotnet test UnitTests/UnitTests.csproj --filter "RoomServiceTests"
```

### 4. Chạy một test method cụ thể
```bash
dotnet test UnitTests/UnitTests.csproj --filter "CreateRoom_ValidRoom_ShouldCreateSuccessfully"
```

## Kết quả mong đợi
```
Test summary: total: 7, failed: 0, succeeded: 7, skipped: 0
```

## Lưu ý
- Unit Tests này sử dụng database thật, không phải mock
- Trước khi chạy test, đảm bảo database đã được thiết lập
- Một số test có thể tạo/xóa dữ liệu trong database

## Framework sử dụng
- **xUnit**: Framework Unit Testing chính
- **Moq**: Thư viện Mock (hiện tại chưa sử dụng do RoomService không inject dependencies)

## Cải tiến trong tương lai
- Refactor RoomService để inject RoomRepo dependency
- Sử dụng In-Memory Database để test
- Thêm Unit Tests cho các Service khác (TenantService, ContractService...)
