//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System;
using System.Threading.Tasks;
using Todoist.Api.Brokers.Loggings;
using Todoist.Api.Brokers.Storages;
using Todoist.Api.Models.Users;

namespace Todoist.Api.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public UsersService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<User> AddUserAsync(User user) =>
            await this.storageBroker.InsertUserAsync(user);
    }
}
