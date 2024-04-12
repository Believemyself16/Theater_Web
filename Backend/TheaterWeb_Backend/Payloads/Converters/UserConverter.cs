using Movie_Web.Entities;
using TheaterWeb.DataContext;
using TheaterWeb.Payloads.DataResponses;

namespace TheaterWeb.Payloads.Converters
{
    public class UserConverter {
        //truy cập, thao tác dữ liệu trong csdl
        private readonly AppDbContext _context;
        public UserConverter() {
            _context = new AppDbContext(); 
        }
        //chuyển thông tin từ user ở DB, sang responseUser, dùng DTO với mục đích chỉ hiển thị những thông tin cần thiết
        public DataResponseUser EntityToDTO(User user) {
            return new DataResponseUser {
                Username = user.Username,
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                RoleName = _context.Role.FirstOrDefault(x => x.Id == user.RoleId).RoleName, //lấy ra role trùng với role của user
                RankName = _context.RankCustomer.FirstOrDefault(x => x.Id == user.RankCustomerId).Name, //lẩy ra rank của customer
                UserStatusName = _context.UserStatus.FirstOrDefault(x => x.Id == user.UserStatusId).Name
            };
        }
    }
}