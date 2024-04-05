namespace Movie_Web.Entities {
    public class Ticket {
        public int Id { get; set; }
        public string Code { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int SeatId { get; set;}
        public Seat Seat { get; set; }
        public double PriceTicket { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BillTicket> lstBillTicket { get; set; }
    }
}
