using TheaterWeb.Entities;

namespace Movie_Web.Entities {
    public class ConfirmEmail : BaseEntity {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string ConfirmCode { get; set; }
        public bool IsConfirm { get; set; }
    }
}
