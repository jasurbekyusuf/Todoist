//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todoist.Api.Models.Tickets;

namespace Todoist.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet <Ticket> Tickets { get; set; }

        public async ValueTask<Ticket> InsertTicketAsync(Ticket ticket) =>
            await InsertAsync(ticket);

        public IQueryable<Ticket> SelectAllTickets() =>
            SelectAll<Ticket>();

        public async ValueTask<Ticket> UpdateTicketAsync(Ticket ticket) =>
            await UpdateAsync(ticket);

        public async ValueTask<Ticket> DeleteTicketAsync(Ticket ticket) =>
           await DeleteAsync(ticket);
    }
}
