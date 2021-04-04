namespace Services.Users.Models
{
    public class AuthModel
    {
        public string Token { get; set; }
        public long TokenExpirationTime { get; set; }
        public string Id { get; set; }
    }
}
