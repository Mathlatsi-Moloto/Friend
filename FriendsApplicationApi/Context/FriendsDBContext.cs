using FriendsApplicationApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsApplicationApi.Context
{
    public class FriendsDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public FriendsDBContext(DbContextOptions<FriendsDBContext> options) : base(options) { }

        public Microsoft.EntityFrameworkCore.DbSet<Users> users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Friends> Friends { get; set; }

       
    }
}
