using TheaterWeb.Payloads.DataRequests;
using TheaterWeb.Payloads.DataResponses;
using TheaterWeb.Payloads.Responses;

namespace TheaterWeb.Services.Interfaces {
    public interface IUserService {
        //request là dữ liệu nhập vào
        ResponseObject<DataResponseUser> Register(RequestRegister request);
    }
}
