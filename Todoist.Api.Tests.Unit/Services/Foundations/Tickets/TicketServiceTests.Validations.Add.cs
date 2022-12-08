//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Todoist.Api.Models.Tickets;
using Todoist.Api.Models.Tickets.Exceptions;
using Xunit;
using Xunit.Sdk;

namespace Todoist.Api.Tests.Unit.Services.Foundations.Tickets
{
    public partial class TicketServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidatoinExceptionOnAddIfInputIsNullAndLogItAsync()
        {
            //given
            Ticket noTicket = null;
            var nullTicketException = new NullTicketException();

            var ecpectedTicketValidationException =
                new TicketValidationException(nullTicketException);


            //when
            ValueTask<Ticket> addTicketTask =
                this.ticketService.AddTicketAsync(noTicket);

            TicketValidationException actualTicketValidationException =
                await Assert.ThrowsAsync<TicketValidationException>(addTicketTask.AsTask);


            //then
            actualTicketValidationException.Should().BeEquivalentTo(
                ecpectedTicketValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    ecpectedTicketValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertTicketAsync(It.IsAny<Ticket>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
