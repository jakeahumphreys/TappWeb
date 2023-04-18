using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components;
using TappWeb.Common.Helpers;
using TappWeb.Common.Security;
using TappWeb.Services.Users;

namespace TappWeb.Pages.Users;

public partial class Add
{
    [Inject] protected IUserService? UserService { get; set; }
    [Inject] protected NavigationManager? NavigationManager { get; set; }
    
    public List<String>? Errors { get; set; }

    public readonly AddUserModel AddUserModel = new AddUserModel();
    private bool _success;
    
    protected override void OnInitialized()
    {
        Errors = new List<string>();
    }

    public async void OnValidSubmit()
    {
        var passwordSalt = PasswordHelper.GenerateSalt();
        var user = new UserBuilder()
            .WithReference(Guid.NewGuid())
            .WithUsername(AddUserModel.Username)
            .WithFirstname(AddUserModel.Firstname)
            .WithLastname(AddUserModel.Lastname)
            .WithEmail(AddUserModel.Email)
            .WithPasswordSalt(passwordSalt)
            .WithPasswordHash(PasswordHelper.HashPassword(AddUserModel.Password, passwordSalt))
            .WithActiveStatus(AddUserModel.IsActive)
            .CreateUser();

        await UserService.AddUser(user);
        _success = true;
        NavigationManager.NavigateTo("/users/list");
    }
}

public class AddUserModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
    [Required]
    public bool IsActive { get; set; }
}