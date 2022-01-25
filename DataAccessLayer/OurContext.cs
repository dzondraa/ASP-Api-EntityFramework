using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class OurContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<UserGroup> userGroup { get; set; }


        public OurContext(DbContextOptions options) : base(options)
        {
        }


    }
}
