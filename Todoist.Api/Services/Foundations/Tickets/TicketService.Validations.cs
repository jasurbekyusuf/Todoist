//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using Todoist.Api.Models.Tickets.Exceptions;
using Todoist.Api.Models.Tickets;

namespace Todoist.Api.Services.Foundations.Tickets
{
    public partial class TicketService
    {
        private static void ValidateTicketNotNull(Ticket ticket)
        {
            if (ticket is null)
            {
                throw new NullTicketException();
            }
        }
    }
}
