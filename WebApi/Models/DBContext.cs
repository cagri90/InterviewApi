using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Model;

namespace WebApi.Models
{
    public class DB: DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { Database.Migrate(); }

        public DbSet<User> Users { get; set; }

        public DbSet<Message> Messages { get; set; }

    }
}
