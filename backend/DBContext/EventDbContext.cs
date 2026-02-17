using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using Microsoft.EntityFrameworkCore;

namespace backend.DBContext
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options) { }

        public DbSet<EventItems> EventManagement { get; set; }
    }
}
