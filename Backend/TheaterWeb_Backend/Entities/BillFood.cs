namespace Movie_Web.Entities {
    public class BillFood {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BillId { get; set; }
        public Bill Bill { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}
