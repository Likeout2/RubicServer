using Microsoft.EntityFrameworkCore;
using RubicServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubicServer.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<RubicServer.Models.SMS> SMS { get; set; }
    }
}
