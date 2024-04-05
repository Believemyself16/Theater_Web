namespace Movie_Web.Entities {
    public class Role {
        public int Id { get; set; }
        public string Code { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<Role> lstRole { get; set;}
    }
}
