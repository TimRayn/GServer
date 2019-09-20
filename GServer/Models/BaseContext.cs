using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GServer.Models
{
    public class BaseContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Service> Services { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }
    }
}
