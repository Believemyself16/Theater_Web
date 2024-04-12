﻿using TheaterWeb.Entities;

namespace Movie_Web.Entities {
    public class User : BaseEntity {
        public int Id { get; set; }
        public int Point { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int RankCustomerId { get; set; }
        public RankCustomer RankCustomer { get; set; }
        public int UserStatusId { get; set; }
        public UserStatus UserStatus { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public IEnumerable<Bill> lstBill { get; set; }
        public IEnumerable<ConfirmEmail> lstConfirmEmail { get; set; }
        public IEnumerable<RefreshToken> lstRefreshToken { get; set; }
    }
}
