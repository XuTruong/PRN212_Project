🔧 A. Công cụ CI/CD dự kiến sử dụng
Công cụ chính: GitHub Actions

Lý do: Vì dự án đã được lưu trữ trên GitHub, sử dụng GitHub Actions là lựa chọn tích hợp và liền mạch nhất. Nó cho phép tạo các luồng công việc mạnh mẽ dựa trên sự kiện trực tiếp trong repository. Hỗ trợ tốt cho .NET và C#, và có các runner chạy trên Windows – điều cần thiết để build ứng dụng WPF.

Công cụ đóng gói (không bắt buộc nhưng nên dùng): MSIX Packaging

Lý do: Để tạo một bộ cài đặt hiện đại và đáng tin cậy cho ứng dụng Windows, công cụ dotnet msix có thể được tích hợp vào pipeline. Nó tạo ra một gói cài đặt dễ sử dụng, dễ phân phối và cập nhật mượt mà.

🚀 B. Các pipeline CI/CD
Quy trình sẽ được chia thành hai pipeline chính: Tích hợp liên tục (CI) và Triển khai liên tục (CD).

1. Pipeline CI (Continuous Integration – Tích hợp liên tục)
Pipeline này nhằm đảm bảo chất lượng và tính ổn định của mã nguồn.

Kích hoạt khi:

Có push lên nhánh main.

Có pull request nhắm tới nhánh main.

Các bước trong quy trình làm việc:

Lấy mã nguồn: Tải mã mới nhất từ nhánh đã kích hoạt hành động.

Thiết lập môi trường .NET: Cài đặt phiên bản .NET SDK yêu cầu cho dự án.

Khôi phục thư viện: Chạy dotnet restore để tải về các gói NuGet cho các project (DataAccess, Repositories, Services, WPF, UnitTests).

Build giải pháp: Chạy dotnet build --configuration Release để biên dịch toàn bộ. Giúp phát hiện lỗi biên dịch sớm.

Chạy Unit Test: Chạy dotnet test để kiểm tra toàn bộ các bài kiểm thử. Nếu có test thất bại, pipeline sẽ dừng và từ chối hợp nhất mã lỗi vào main.

📄 Ví dụ file CI (.github/workflows/ci.yml):

yaml
Sao chép
Chỉnh sửa
name: .NET CI

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: windows-latest  # WPF cần runner chạy Windows

    steps:
    - name: Checkout code
      uses: actions/checkout@v3

    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: '6.0.x' # Chọn đúng phiên bản .NET

    - name: Restore dependencies
      run: dotnet restore

    - name: Build
      run: dotnet build --configuration Release --no-restore

    - name: Test
      run: dotnet test --no-build --verbosity normal
2. Pipeline CD (Continuous Deployment – Triển khai liên tục)
Pipeline này tập trung vào đóng gói và phát hành ứng dụng.

Kích hoạt khi:

Có push lên nhánh main thành công (sau khi pipeline CI chạy qua).

Hoặc khi tạo một Git tag mới (ví dụ v1.0.1).

Các bước trong quy trình làm việc:

Build & Publish: Chạy dotnet publish với file WPF.csproj, tạo ra thư mục chứa .exe, DLL, và các file cần thiết.

Đóng gói ứng dụng: Tạo file .zip hoặc .msix từ thư mục xuất bản, tên file sẽ chứa phiên bản (ví dụ RoomManager-v1.0.1.zip).

Tạo bản phát hành trên GitHub:

Tự động tạo một bản phát hành mới trong tab Releases của GitHub.

Tệp .zip hoặc .msix được đính kèm làm file tải về.

Ghi chú phát hành có thể tạo tự động từ commit gần nhất.

🛠️ C. Quy trình tích hợp và triển khai
Tích hợp với Git: Toàn bộ CI/CD được định nghĩa bằng YAML trong thư mục .github/workflows, nằm trong repo của bạn — đảm bảo quy trình luôn nằm cùng với mã nguồn.

Chiến lược nhánh:

main: là nhánh chuẩn để phát hành. Chỉ mã đã kiểm tra, ổn định mới được merge vào đây.

feature/*: dùng để phát triển tính năng mới, sửa lỗi riêng biệt. Khi xong, tạo Pull Request vào main.

Pull Request Review: CI pipeline sẽ tự chạy khi có PR, nếu build hoặc test thất bại thì không thể merge được.

Triển khai đến người dùng:

Khi có merge vào main, pipeline CD sẽ tự động chạy và xuất bản bản mới.

Người dùng (quản lý phòng trọ) truy cập vào mục Releases trên GitHub.

Họ tải bản cài đặt .msix hoặc .zip mới nhất về và cài đặt hoặc cập nhật trên máy Windows của họ.
