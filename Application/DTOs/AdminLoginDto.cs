

namespace Application.DTOs;

public class AdminLoginDto
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; } = false;
}
