namespace Florage.Authentication.Responses
{
    public class UserTokenResponse: BaseResponse
    {
        public string? Token { get; set; } = string.Empty;
    }
}
