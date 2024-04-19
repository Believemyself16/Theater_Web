using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TheaterWeb.Handle.Email {
    public class Validate {
        //kiểm tra chuỗi truyền vào có đúng định dạng không
        public static bool IsValidEmail(string email) {
            var checkEmail = new EmailAddressAttribute();
            return checkEmail.IsValid(email);
        }
        //kiểm tra số điện thoại
        public static bool IsValidPhoneNumber(string phoneNumber) {
            string pattern = @"^(84|0[35789])[0-9]{8}$"; //bắt đầu là 0 hoặc 84, theo sau là 1 số thuộc 3,5,7,8,9 - sau đó là 8 số
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
