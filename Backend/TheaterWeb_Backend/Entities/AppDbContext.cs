using Microsoft.EntityFrameworkCore;
using Movie_Web.Entities;

namespace TheaterWeb.Entities {
    public class AppDbContext : DbContext {
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<BillFood> BillFood { get; set; }
        public virtual DbSet<BillStatus> BillStatus { get; set; }
        public virtual DbSet<BillTicket> BillTicket { get; set; }
        public virtual DbSet<Cinema> Cinema { get; set; }
        public virtual DbSet<ConfirmEmail> ConfirmEmail { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<GeneralSetting> GeneralSetting { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieType> MovieType { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<RankCustomer> RankCustomer { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }
        public virtual DbSet<SeatStatus> SeatStatus { get; set; }
        public virtual DbSet<SeatType> SeatType { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserStatus> UserStatus { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server = LAPTOP-K9FVICF6\\SQLEXPRESS; Database = Theater_Web; Trusted_Connection = true; TrustServerCertificate = true");
        }
    }
}
