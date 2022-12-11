//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System;
using Xeptions;

namespace Todoist.Api.Models.Tickets.Exceptions
{
    public class FailedTicketStorageException : Xeption
    {
        public FailedTicketStorageException(Exception innerException)
            : base(message: "Failed ticket storage error occured, contact suppott.", innerException)
        {}
    }
}
