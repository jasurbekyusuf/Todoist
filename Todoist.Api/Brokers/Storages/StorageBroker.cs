//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//==================================================

using System.Threading.Tasks;
using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Todoist.Api.Models.Tickets;

namespace Todoist.Api.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext , IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = 
                this.configuration.GetConnectionString(name:"DefaultConnection");
            
            optionsBuilder.UseSqlServer(connectionString);
        }

        ValueTask<Task> IStorageBroker.InsertTaskAsync(Ticket ticket)
        {
            throw new System.NotImplementedException();
        }
    }
}
