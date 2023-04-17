using Microsoft.AspNetCore.Components;
using TappWeb.Users;

namespace TappWeb.Pages.Users;

public partial class Add
{
    [Inject] protected IUserService _userService { get; set; }
    
    public List<String> Errors { get; set; }
    
    public Guid Reference { get; set; }
    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email{ get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public bool IsActive { get; set; }

    protected override void OnInitialized()
    {
        Errors = new List<string>();
        Reference = Guid.NewGuid();
    }

    public void AddUser()
    {
        if (ConfirmPassword != Password)
        {
            Errors.Add("Passwords must match");
            StateHasChanged();
        }
    }
}