using TheaterWeb.Entities;

namespace Movie_Web.Entities {
    public class RefreshToken : BaseEntity {
        public string Token { get; set; }
        public DateTime ExpiredTime { get; set; } //thời gian hết hạn
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
