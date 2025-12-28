 namespace HelpDesk.User;
  public class UserLoginDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Password { get; set; } = string.Empty;
    }