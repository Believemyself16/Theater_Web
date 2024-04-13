﻿using Movie_Web.Entities;
using TheaterWeb.Payloads.DataRequests;
using TheaterWeb.Payloads.DataResponses;
using TheaterWeb.Payloads.Responses;

namespace TheaterWeb.Services.Interfaces {
    public interface IUserService {
        //request là dữ liệu nhập vào
        ResponseObject<DataResponseUser> Register(Request_Register request);
        DataResponseToken GenerateAccessToken(User user); //tạo token cho user
        DataResponseToken RenewAccessToken(User user); //làm mới lại access token
    }
}
