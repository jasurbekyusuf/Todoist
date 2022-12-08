//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Threading.Tasks;
using Todoist.Api.Brokers.Storages;
using Todoist.Api.Models.Tickets;

namespace Todoist.Api.Services.Foundations.Tickets
{
    public class TicketService : ITicketService
    {
        private readonly IStorageBroker storageBroker;

        public TicketService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public  ValueTask<Ticket> AddTicketAsync(Ticket ticket) =>
            throw new System.NotImplementedException();
          
    }
}
