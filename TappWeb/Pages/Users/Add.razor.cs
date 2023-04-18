using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using TappWeb.Common.Helpers;
using TappWeb.Services.Users;

namespace TappWeb.Pages.Users;

public partial class Add
{
    [Inject] protected IUserService _userService { get; set; }
    
    public List<String> Errors { get; set; }

    public AddUserModel AddUserModel = new AddUserModel();
    private bool success;
    
    protected override void OnInitialized()
    {
        Errors = new List<string>();
    }

    public void OnValidSubmit()
    {
        var user = new UserBuilder()
            .WithReference(Guid.NewGuid())
            .WithUsername(AddUserModel.Username)
            .WithFirstname(AddUserModel.Firstname)
            .WithLastname(AddUserModel.Lastname)
            .WithEmail(AddUserModel.Email)
            .WithPassword(AddUserModel.Password)
            .WithActiveStatus(AddUserModel.IsActive)
            .CreateUser();

        _userService.AddUser(user);
        success = true;
        StateHasChanged();
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