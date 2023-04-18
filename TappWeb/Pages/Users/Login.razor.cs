using Microsoft.AspNetCore.Components;
using TappWeb.Common.Security;
using TappWeb.Services.Users;

namespace TappWeb.Pages.Users;

public partial class Login
{
    [Inject] private IUserService _userService { get; set; }
    
    public LoginModel LoginModel = new LoginModel();
    public bool IsLoggedIn;

    protected override void OnInitialized()
    {
    }

    public async void OnValidSubmit()
    {
        var user = await _userService.GetByUsername(LoginModel.Username);

        if (PasswordHelper.VerifyPassword(LoginModel.Password, user.PasswordSalt, user.PasswordHash))
        {
        }
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}