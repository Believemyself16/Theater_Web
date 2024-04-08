using TheaterWeb.Entities;

namespace Movie_Web.Entities {
    public class RefreshToken : BaseEntity {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiredTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
