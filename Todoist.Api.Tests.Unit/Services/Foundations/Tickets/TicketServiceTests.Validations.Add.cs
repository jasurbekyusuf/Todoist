//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Threading.Tasks;
using Todoist.Api.Models.Tickets;
using Xunit;

namespace Todoist.Api.Tests.Unit.Services.Foundations.Tickets
{
    public partial class TicketServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidatoinExceptionOnAddIfInputIsNullAndLogItAsync()
        {
            //given
            Ticket noTicket = null;



            //when
            ValueTask<Ticket> actualTicket =
                this.ticketService.AddTicketAsync(noTicket);


            //then
        }
    }
}
