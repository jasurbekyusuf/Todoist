//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System;
using Xeptions;

namespace Todoist.Api.Models.Tickets.Exceptions
{
    public class TicketServiceException : Xeption
    {
        public TicketServiceException(Exception innerException)
            : base(message: "Ticket service error occurred, contact support.", innerException)
        { }
    }
}
