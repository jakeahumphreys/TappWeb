using Microsoft.AspNetCore.Components;
using TappWeb.Users;
using TappWeb.Users.Types;

namespace TappWeb.Pages.Users;

public partial class List
{
    [Inject] protected IUserService _userService { get; set; }
    
    private List<UserRecord> _users { get;set; }

    protected override Task OnInitializedAsync()
    {
        _users = _userService.GetAllUsers();
        return base.OnInitializedAsync();
    }
}