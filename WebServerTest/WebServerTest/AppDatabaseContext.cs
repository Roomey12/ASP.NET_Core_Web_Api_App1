using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServerTest.Models;

namespace WebServerTest
{
    public class AppDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options)
            : base(options) { }

    }
}
