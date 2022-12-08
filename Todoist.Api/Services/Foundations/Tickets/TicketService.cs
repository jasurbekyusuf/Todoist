//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Threading.Tasks;
using Todoist.Api.Brokers.Loggings;
using Todoist.Api.Brokers.Storages;
using Todoist.Api.Models.Tickets;

namespace Todoist.Api.Services.Foundations.Tickets
{
    public class TicketService : ITicketService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public TicketService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public  async ValueTask<Ticket> AddTicketAsync(Ticket ticket) =>
            await this.storageBroker.InsertTicketAsync(ticket);
          
    }
}
