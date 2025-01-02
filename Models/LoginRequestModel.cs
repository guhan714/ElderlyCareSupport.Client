namespace ElderlyCareSupport.Client.Models;

public class LoginRequestModel
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public UserType UserType { get; set; }
}