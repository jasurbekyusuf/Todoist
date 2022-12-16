//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using Xeptions;

namespace Todoist.Api.Models.Tickets.Exceptions
{
    public class TicketDependencyException : Xeption
    {
        public TicketDependencyException(Xeption innerException)
            : base(message: "Ticket dependency error occured, contect support.", innerException)
        {}
    }
}
