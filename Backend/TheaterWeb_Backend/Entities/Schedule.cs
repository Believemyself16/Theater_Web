namespace Movie_Web.Entities {
    public class Schedule {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Code { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Ticket> lstTicket { get; set; }
    }
}
