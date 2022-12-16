//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using Xeptions;

namespace Todoist.Api.Models.Tickets.Exceptions
{
    public class TicketDependencyValidationException : Xeption
    {
        public TicketDependencyValidationException(Xeption innerException)
            : base(message: "Ticket dependancy validation error occured, fix the errors and try again",
                  innerException)
        { }
    }
}
