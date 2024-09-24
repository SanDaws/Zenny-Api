namespace Zenny_Api.Requests;

public class LoginRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
