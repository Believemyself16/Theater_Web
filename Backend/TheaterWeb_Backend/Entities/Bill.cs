using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Web.Entities {
    public class Bill {
        public int Id { get; set; }
        public double TotalMoney { get; set; }
        public string TradingCode { get; set; }
        public DateTime CreateTime { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public DateTime UpdateTime { get; set; }
        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }
        public int BillStatusId { get; set; }
        public BillStatus BillStatus { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BillFood> lstBillFood { get; set; }
        public IEnumerable<BillTicket> lstBillTicket { get; set; }
    }
}
