namespace Florage.Authentication.Dtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string UserName { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
    }
}
