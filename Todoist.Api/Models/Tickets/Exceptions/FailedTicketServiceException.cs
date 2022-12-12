//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System;
using Xeptions;

namespace Todoist.Api.Models.Tickets.Exceptions
{
    public class FailedTicketServiceException : Xeption
    {
        public FailedTicketServiceException(Exception innerException)
            : base(message: "Failed ticket service occurred, please contact support",
                  innerException)
        { }
    }
}
