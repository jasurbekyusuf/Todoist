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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnAddIfTicketIsInvalidAndLogItAysnc(
            string invalidString)
        {
            // given
            var invalidTicket = new Ticket
            {
                Title = invalidString,
            };

            var invalidTicketException = new InvalidTicketException();

            invalidTicketException.AddData(
                key: nameof(Ticket.Id),
                values: "Id is required");

            invalidTicketException.AddData(
                key: nameof(Ticket.Title),
                values: "Text is required");

            invalidTicketException.AddData(
                key: nameof(Ticket.Deadline),
                values: "Value is required");

            invalidTicketException.AddData(
                key: nameof(Ticket.CreatedDate),
                values: "Text is required");

            invalidTicketException.AddData(
                key: nameof(Ticket.UpdatedDate),
                values: "Text is required");

            invalidTicketException.AddData(
                key: nameof(Ticket.CreatedUserId),
                values: "Text is required");

            invalidTicketException.AddData(
                key: nameof(Ticket.UpdatedUserId),
                values: "Text is required");

            var expectedTicketValidationException =
                new TicketValidationException(invalidTicketException);

            // when
            ValueTask<Ticket> addTicketTask = this.ticketService.AddTicketAsync(invalidTicket);

            TicketValidationException actualValidationException =
                await Assert.ThrowsAsync<TicketValidationException>(addTicketTask.AsTask);

            //then
            actualValidationException.Should().BeEquivalentTo(expectedTicketValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedTicketValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertTicketAsync(It.IsAny<Ticket>()), Times.Once());

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
