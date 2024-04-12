using TheaterWeb.Entities;

namespace Movie_Web.Entities {
    public class Role : BaseEntity {
        public int Id { get; set; }
        public string Code { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<User> lstUser { get; set;}
    }
}
