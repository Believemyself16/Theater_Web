BACKEND
1. Tạo các bảng và mối quan hệ giữa các bảng
2. Folder DataContext chứa AppDbContext
3. Folder Payloads chứa các folder con
   - Folder Converter để chuyển đổi thông tin từ DB sang thông tin chuẩn, chỉ hiển thị thông tin cần thiết
   - Folder DataRequest chứa dữ liệu đăng ký tài khoản
   - Folder DataResponse chứa dữ liệu hiển thị
   - Folder ResponseObject chuyển đổi dữ liệu sang mã lỗi
4. Tạo các folder IService và Service
5. Chức năng đăng ký tài khoản
   - Mã hóa mật khẩu bằng package BCrypt.Net-Next
   - Xác nhận thông tin nhập vào
   - Dùng phương thức post để chạy chức năng đăng ký
   - Sau khi đăng kí, gửi mail về mail của user để xác thực
6. Chức năng xác thực và phân quyền
   - Xây dựng bằng jwt
7. Chức năng đăng nhập
   - Xác thực mật khẩu, username nhập vào
8. Chức năng đổi mật khẩu
9. Chức năng quên mật khẩu
------------------------------------------------------------------------------------------------------------
FRONTEND
1. Xây dựng Navbar, Footer
2. Xây Home page
3. Xây Page Nhượng quyền
4. Xây Page Thành viên (Đăng kí và đăng nhập)
5. 
