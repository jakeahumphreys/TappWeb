using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TappWeb.Authentication;
using TappWeb.Common.Security;
using TappWeb.Services.Users;

namespace TappWeb.Pages.Users;

public partial class Login
{
    [Inject] private IUserService _userService { get; set; }
    [Inject] private AuthenticationStateProvider _authenticationStateProvider { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }
    
    public LoginModel LoginModel = new LoginModel();
    public bool IsLoggedIn;

    protected override void OnInitialized()
    {
    }

    public async Task OnValidSubmit()
    {
        var user = await _userService.GetByUsername(LoginModel.Username);

        if (PasswordHelper.VerifyPassword(LoginModel.Password, user.PasswordSalt, user.PasswordHash))
        {
            var authStateProvider = (CustomAuthenticationStateProvider) _authenticationStateProvider;
            await authStateProvider.UpdateAuthenticationState(new UserSession
            {
                Email = user.Email,
                Name = $"{user.Firstname} {user.Lastname}"
            });
            _navigationManager.NavigateTo("/", true);
        }
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}