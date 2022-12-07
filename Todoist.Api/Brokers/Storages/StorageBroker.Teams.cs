//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todoist.Api.Models.Teams;

namespace Todoist.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Team> Teams { get; set; }

        public async ValueTask<Team> InsertTicketAsync(Team team) =>
            await InsertAsync(team);

        public IQueryable<Team> SelectAllTeams() =>
            SelectAll<Team>();

        public async ValueTask<Team> UpdateTeamAsync(Team team) =>
            await UpdateAsync(team);
    }
}
