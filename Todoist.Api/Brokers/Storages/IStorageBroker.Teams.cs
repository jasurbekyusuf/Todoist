//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Todoist.Api.Models.Teams;

namespace Todoist.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Team> InsertTicketAsync(Team team);
        IQueryable<Team> SelectAllTeams();
        ValueTask<Team> SelectTeamByIdAsync(Guid id);
        ValueTask<Team> UpdateTeamAsync(Team team);
        ValueTask<Team> DeleteTeamAsync(Team team);
    }
}
