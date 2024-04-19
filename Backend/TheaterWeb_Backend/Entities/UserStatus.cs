namespace Movie_Web.Entities {
    public class UserStatus {
        public int Id { get; set; } //1 là tài khoản chưa kích hoạt, 2 là đã kích hoạt
        public string Code { get; set; } 
        public string Name { get; set; }
        public IEnumerable<User> lstUsser { get; set; }
    }
}
