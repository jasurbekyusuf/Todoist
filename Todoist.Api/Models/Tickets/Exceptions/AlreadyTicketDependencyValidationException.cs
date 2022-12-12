//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System;
using Xeptions;

namespace Todoist.Api.Models.Tickets.Exceptions
{
    public class AlreadyTicketDependencyValidationException : Xeption
    {
        public AlreadyTicketDependencyValidationException(Exception innerException)
            : base(message: "Ticket already exists.",
                  innerException) 
        { }
    }
}
