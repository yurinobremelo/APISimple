﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class AppDbContext : DbContext,IDisposable
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {
        
        }
        public DbSet<User> Users { get; set; }

    }
}
