namespace Movie_Web.Entities {
    public class Seat {
        public int Id { get; set; }
        public int Number { get; set; }
        public int SeatStatusId { get; set; }
        public SeatStatus SeatStatus { get; set; }
        public string Line { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public bool IsActive { get; set; }
        public int SeatTypeId { get; set; }
        public SeatType SeatType { get; set; }
        public IEnumerable<Ticket> lstTicket { get; set; }
    }
}
