//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todoist.Api.Models.Tickets;

namespace Todoist.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet <Ticket> Tickets { get; set; }

        public async ValueTask<Ticket> InsertTaskAsync(Ticket ticket) 
        {
            var broker = new StorageBroker(this.configuration);
            await broker.Tickets.AddAsync(ticket);
            await broker.SaveChangesAsync();

            return ticket;
        }
    }
}
