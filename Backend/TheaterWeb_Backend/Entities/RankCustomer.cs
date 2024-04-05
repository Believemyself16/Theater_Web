namespace Movie_Web.Entities {
    public class RankCustomer {
        public int Id { get; set; }
        public int Point { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Promotion> lstPromotion { get; set; }
        public IEnumerable<User> lstUser { get; set; }
    }
}
