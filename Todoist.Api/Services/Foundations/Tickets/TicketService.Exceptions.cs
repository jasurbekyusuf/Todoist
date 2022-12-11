//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
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
            catch (InvalidTicketException invalidTicketException)
            {
                throw CreateAndLogValidationException(invalidTicketException);
            }
            catch (SqlException sqlException)
            {
                var failedTicketStorageException = new FailedTicketStorageException(sqlException);
                throw CreatedAndLogCriticalDependencyException(failedTicketStorageException);
            }
            catch (DuplicateKeyException dublicateKeyException)
            {
                var failedTicketDependencyValidationException =
                    new AlreadyTicketDependencyValidationException(dublicateKeyException);

                throw CreateAndDependencyValidationException(failedTicketDependencyValidationException); 
            }
        }

        private TicketValidationException CreateAndLogValidationException(Xeption exception)
        {
            var ticketValidationException =
                new TicketValidationException(exception);

            this.loggingBroker.LogError(ticketValidationException);
            return ticketValidationException;
        }
        private TicketDependencyException CreatedAndLogCriticalDependencyException(Xeption exception)
        {
            var ticketDependencyException = new TicketDependencyException(exception);
            this.loggingBroker.LogCritical(ticketDependencyException);

            return ticketDependencyException;
        }
        private TicketDependencyValidationException CreateAndDependencyValidationException(Xeption exception)
        {
            var ticketDependencyValidationException = new TicketDependencyValidationException(exception);
            this.loggingBroker.LogError(ticketDependencyValidationException);

            return ticketDependencyValidationException;
        }
    }
}
