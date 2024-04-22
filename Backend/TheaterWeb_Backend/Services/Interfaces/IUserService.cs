using Movie_Web.Entities;
using TheaterWeb.Payloads.DataRequests.UserRequest;
using TheaterWeb.Payloads.DataResponses;
using TheaterWeb.Payloads.Responses;

namespace TheaterWeb.Services.Interfaces
{
    public interface IUserService {
        //request là dữ liệu nhập vào
        ResponseObject<DataResponseUser> Register(Request_Register request);
        DataResponseToken GenerateAccessToken(User user); //tạo token cho user
        DataResponseToken RenewAccessToken(User user); //làm mới lại access token
        ResponseObject<DataResponseToken> Login(Request_Login request);
        ResponseObject<DataResponseUser> ConfirmCreateAccount(Request_ConfirmCreateAccount request);
        ResponseObject<DataResponseUser> ChangePasswword(int UserId, Request_ChangePassword request);
        string ForgotPassword(Request_ForgotPassword request);
        string ConfirmCreateNewPassword(Request_ConfirmCreateNewPassword request);
        IQueryable<DataResponseUser> GetAllUser();
    }
}
