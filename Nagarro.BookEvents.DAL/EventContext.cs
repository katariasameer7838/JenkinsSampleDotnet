using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Nagarro.BookEvents.DAL;
using System.Data.Entity.Infrastructure;

namespace Nagarro.BookEvents.DAL
{
    class EventContext : DbContext
    {
        public EventContext() : base("EventContext")
        {
        }

        public DbSet<BookEvent> BookEvents { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<InvitedUser> InvitedUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        }
    }
}
