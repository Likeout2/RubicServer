using Microsoft.EntityFrameworkCore;
using RubicServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubicServer.Contexts
{
    public class SMSContext : DbContext
    {
        public SMSContext(DbContextOptions<SMSContext> options) : base(options)
        {

        }

        public DbSet<SMS> SMSs { get; set; }
    }
}
