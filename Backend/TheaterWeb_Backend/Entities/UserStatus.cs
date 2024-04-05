namespace Movie_Web.Entities {
    public class UserStatus {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> lstUsser { get; set; }
    }
}
