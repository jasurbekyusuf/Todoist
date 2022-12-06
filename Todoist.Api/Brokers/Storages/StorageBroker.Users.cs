//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Todoist.Api.Models.Users;

namespace Todoist.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }

        public async ValueTask<User> InsertUserAsync(User user) =>
            await InsertAsync(user);
    }
}
