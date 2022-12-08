//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System;
using Moq;
using Todoist.Api.Brokers.Loggings;
using Todoist.Api.Brokers.Storages;
using Todoist.Api.Models.Tickets;
using Todoist.Api.Services.Foundations.Tickets;
using Tynamix.ObjectFiller;

namespace Todoist.Api.Tests.Unit.Services.Foundations.Tickets
{
    public partial class TicketServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ITicketService ticketService;

        public TicketServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.ticketService = new TicketService(
               storageBroker: this.storageBrokerMock.Object,
               loggingBroker: this.loggingBrokerMock.Object);
        }

        private static DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();

        private static Ticket CreateRandomTicket() =>
            CreateTicketFiller().Create();

        private static Filler<Ticket> CreateTicketFiller() 
        {
            var filler = new Filler<Ticket>();
            DateTimeOffset dates = GetRandomDateTime();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates);

            return filler;
        }
    }
}
