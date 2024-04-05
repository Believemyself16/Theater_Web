namespace Movie_Web.Entities {
    public class BillStatus {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Bill> lstBill { get; set; }
    }
}
