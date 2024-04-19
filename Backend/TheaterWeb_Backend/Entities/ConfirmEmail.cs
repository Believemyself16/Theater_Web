using TheaterWeb.Entities;

namespace Movie_Web.Entities {
    //confirm email chứa các email người dùng chưa được kích hoạt
    public class ConfirmEmail : BaseEntity {
        public int UserId { get; set; } //người dùng sử dụng email
        public User? User { get; set; }
        public DateTime RequiredTime { get; set; } //thời gian hệ thống yêu cầu để gửi mail cho người dùng, sau khi đăng ký tk hoặc đổi mk
        public DateTime ExpiredTime { get; set; } //thời gian việc xác nhận email hết hạn
        public string ConfirmCode { get; set; }
        public bool IsConfirm { get; set; }
    }
}
