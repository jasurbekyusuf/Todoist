//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Threading.Tasks;
using Todoist.Api.Models.Users;

namespace Todoist.Api.Services.Users
{
    public interface IUsersService
    {
        ValueTask<User> AddUserAsync(User user);
    }
}
