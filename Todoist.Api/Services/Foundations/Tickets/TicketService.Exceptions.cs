//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Threading.Tasks;
using Todoist.Api.Models.Tickets;
using Todoist.Api.Models.Tickets.Exceptions;
using Xeptions;

namespace Todoist.Api.Services.Foundations.Tickets
{
    public partial class TicketService
    {
        private delegate ValueTask<Ticket> ReturningTicketFunction();

        private async ValueTask<Ticket> TryCatch(ReturningTicketFunction returningTicketFunction) 
        {
            try
            {
                return await returningTicketFunction();
            }
            catch (NullTicketException nullTicketException)
            {
                throw CreateAndLogValidationException(nullTicketException);
            }
        }

        private TicketValidationException CreateAndLogValidationException(Xeption exception)
        {
            var ticketValidationException =
                new TicketValidationException(exception);

            this.loggingBroker.LogError(ticketValidationException);
            return ticketValidationException;
        }
    }
}
  