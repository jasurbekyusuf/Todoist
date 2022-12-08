//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Todoist.Api.Models.Tickets;
using Xunit;

namespace Todoist.Api.Tests.Unit.Services.Foundations.Tickets
{
    public partial class TicketServiceTests
    {
        [Fact]
        public async Task ShoudAddTicketAsync()
        {
            // given
            Ticket randomTicket = CreateRandomTicket();
            Ticket inputTicket = randomTicket;
            Ticket persistedTicket = inputTicket;
            Ticket expectedTicket = persistedTicket.DeepClone();
 
            this.storageBrokerMock.Setup(broker =>
                broker.InsertTicketAsync(inputTicket))
                    .ReturnsAsync(persistedTicket);

            // Wen
            Ticket actualTicket = await this.ticketService.AddTicketAsync(inputTicket);



            // then
            actualTicket.Should().BeEquivalentTo(expectedTicket);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertTicketAsync(inputTicket), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
