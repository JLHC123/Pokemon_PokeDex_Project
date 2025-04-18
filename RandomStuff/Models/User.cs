namespace RandomStuff.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
