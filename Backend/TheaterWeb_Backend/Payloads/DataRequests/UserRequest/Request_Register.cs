﻿namespace TheaterWeb.Payloads.DataRequests.UserRequest
{
    public class Request_Register
    {
        //các dữ liệu đăng ký tài khoản
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
