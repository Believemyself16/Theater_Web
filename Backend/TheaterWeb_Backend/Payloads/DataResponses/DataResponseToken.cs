namespace TheaterWeb.Payloads.DataResponses {
    public class DataResponseToken {
        public string AccessToken { get; set; } //sau khi đăng nhập sẽ trả về access token
        public string RefreshToken { get; set; } //để làm mới access token
    }
}
