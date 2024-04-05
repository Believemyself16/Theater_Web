namespace Movie_Web.Entities {
    public class SeatType {
        public int Id { get; set; }
        public string NameType { get; set; }
        public IEnumerable<Seat> lstSeat { get; set; }

    }
}
