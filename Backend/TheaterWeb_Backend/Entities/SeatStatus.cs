namespace Movie_Web.Entities {
    public class SeatStatus {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameStatus { get; set; }
        public IEnumerable<Seat> lstSeat { get; set; }
    }
}
