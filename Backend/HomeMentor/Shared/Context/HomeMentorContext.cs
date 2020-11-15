using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Context
{
    public class HomeMentorContext : DbContext
    {
        public HomeMentorContext(DbContextOptions<HomeMentorContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
