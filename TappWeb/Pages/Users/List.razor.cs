using Microsoft.AspNetCore.Components;
using TappWeb.Data.Users.Types;
using TappWeb.Services.Users;
using TappWeb.Users;

namespace TappWeb.Pages.Users;

public partial class List
{
    [Inject] protected IUserService _userService { get; set; }
    
    private List<UserRecord> _users { get;set; }
    private bool _loading;

    protected override async Task OnInitializedAsync()
    {
        _users = new List<UserRecord>();
        
        var users = await _userService.GetAllUsers();
        _users = users;
    }
}