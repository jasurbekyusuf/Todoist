//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System;
using Todoist.Api.Models.Tickets;
using Todoist.Api.Models.Tickets.Exceptions;

namespace Todoist.Api.Services.Foundations.Tickets
{
    public partial class TicketService
    {
        private static void ValidateTicket(Ticket ticket)
        {
            ValidateTicketNotNull(ticket);

            Validate(
                (Rule: IsInvalid(ticket.Id), Parameter: nameof(Ticket.Id)),
                (Rule: IsInvalid(ticket.Title), Parameter: nameof(Ticket.Title)),
                (Rule: IsInvalid(ticket.Deadline), Parameter: nameof(Ticket.Deadline)),
                (Rule: IsInvalid(ticket.CreatedDate), Parameter: nameof(Ticket.CreatedDate)),
                (Rule: IsInvalid(ticket.UpdatedDate), Parameter: nameof(Ticket.UpdatedDate)),
                (Rule: IsInvalid(ticket.CreatedUserId), Parameter: nameof(Ticket.CreatedUserId)),
                (Rule: IsInvalid(ticket.CreatedUserId), Parameter: nameof(Ticket.UpdatedUserId))
                );
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Value is required"
        };

        private static void ValidateTicketNotNull(Ticket ticket)
        {
            if (ticket is null)
            {
                throw new NullTicketException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parametr)[] validations)
        {
            var invalidTicketException = new InvalidTicketException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidTicketException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidTicketException.ThrowIfContainsErrors();
        }
    }
}
