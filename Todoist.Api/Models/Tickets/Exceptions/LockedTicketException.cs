//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System;
using Xeptions;

namespace Todoist.Api.Models.Tickets.Exceptions
{
    public class LockedTicketException : Xeption
    {
        public LockedTicketException(Exception innerException)
            : base(message: "Ticket is loced, please try again.", innerException)
        { }
    }
}
