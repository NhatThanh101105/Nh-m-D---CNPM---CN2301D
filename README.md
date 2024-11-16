
README: Koi Breeding Game

Giới thiệu
Koi Breeding Game là một trò chơi mô phỏng quá trình nuôi và lai tạo cá koi, cho phép người chơi quản lý hồ cá của mình, khám phá các giống cá koi mới, và nâng cao kỹ năng quản lý qua các thử thách. Trò chơi không chỉ mang tính giải trí mà còn giúp bạn hiểu rõ hơn về di truyền học, cách phối giống, và quản lý tài nguyên.

---

Các tính năng chính
- Lai giống cá koi:
  Người chơi có thể lai tạo cá koi dựa trên màu sắc, hoa văn và các thuộc tính di truyền để tạo ra các giống mới.
- Quản lý hồ cá:
  Tùy chỉnh hồ cá, thêm/xóa cá, và chăm sóc để giữ hồ luôn đẹp và đầy sức sống.
- Bộ sưu tập cá koi:
  Thu thập các loại cá koi hiếm với hoa văn độc đáo và giá trị cao.
- Thị trường giao dịch:
  Mua, bán, hoặc trao đổi cá koi với những người chơi khác để mở rộng bộ sưu tập.
- Hệ thống điểm thưởng:
  Nhận điểm và phần thưởng khi đạt được các thành tựu, chẳng hạn như tạo ra giống cá mới hoặc đạt doanh thu cao từ việc bán cá.

---

Hướng dẫn cài đặt

Yêu cầu hệ thống
- Hệ điều hành: Windows, macOS hoặc Linux
- Ngôn ngữ lập trình:
  - Backend: ASP.NET Core (C#)
  - Frontend: Razor Pages, HTML, CSS, JavaScript
- Cơ sở dữ liệu: SQL Server hoặc SQLite
- Trình duyệt: Hỗ trợ Chrome, Firefox, Edge

Các bước cài đặt
1. Clone repository:
   git clone https://github.com/your-repo/koi-breeding-game.git
   cd koi-breeding-game
2. Cài đặt các package yêu cầu:
   dotnet restore
3. Cấu hình cơ sở dữ liệu:
   - Mở file appsettings.json và cấu hình chuỗi kết nối phù hợp:
     "ConnectionStrings": {
       "DefaultConnection": "Your_Connection_String_Here"
     }
   - Chạy lệnh migration:
     dotnet ef database update
4. Khởi chạy ứng dụng:
   dotnet run
5. Truy cập ứng dụng:
   Mở trình duyệt và truy cập: http://localhost:5000

---

Hướng dẫn sử dụng

Bắt đầu trò chơi
1. Đăng nhập hoặc đăng ký tài khoản.
2. Khởi tạo hồ cá của bạn.
3. Lai giống cá koi bằng cách chọn hai cá bố mẹ từ danh sách của bạn.

Lai giống cá koi
- Chọn hai cá koi bố mẹ từ danh sách.
- Hệ thống sẽ hiển thị xác suất các giống cá con có thể xuất hiện dựa trên các quy tắc di truyền.
- Nhận cá con vào hồ hoặc bán trực tiếp để kiếm điểm.

Thị trường giao dịch
- Đăng bán cá koi bạn không cần hoặc tìm mua cá koi hiếm từ những người chơi khác.

---

Đóng góp

Cách đóng góp
1. Fork repository.
2. Tạo nhánh mới từ main:
   git checkout -b feature/your-feature
3. Commit và push code:
   git commit -m "Thêm tính năng XYZ"
   git push origin feature/your-feature
4. Tạo Pull Request và mô tả thay đổi của bạn.

Quy tắc đóng góp
- Viết code rõ ràng, tuân thủ theo chuẩn C# Coding Guidelines.
- Viết Unit Test cho các tính năng mới.
- Đảm bảo code không có lỗi bằng cách chạy:
   dotnet test

---

Thông tin liên hệ
Nếu bạn có thắc mắc hoặc cần hỗ trợ, vui lòng liên hệ:
- Email: support@koibreedinggame.com
- Website: Koi Breeding Game
- Facebook: Koi Breeding Community

Cảm ơn bạn đã tham gia vào thế giới của Koi Breeding Game! 🎏
