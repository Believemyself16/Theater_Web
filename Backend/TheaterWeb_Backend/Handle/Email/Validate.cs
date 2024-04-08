using System.ComponentModel.DataAnnotations;

namespace TheaterWeb.Handle.Email {
    public class Validate {
        //kiểm tra chuỗi truyền vào có đúng định dạng không
        public static bool IsValidEmail(string email) {
            var checkEmail = new EmailAddressAttribute();
            return checkEmail.IsValid(email);
        }
    }
}
