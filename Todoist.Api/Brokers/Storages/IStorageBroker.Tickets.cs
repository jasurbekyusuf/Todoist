﻿//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Threading.Tasks;
using Todoist.Api.Models.Tickets;

namespace Todoist.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask <Task> InsertTaskAsync(Ticket ticket);
    }
}
