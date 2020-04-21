﻿using Microsoft.EntityFrameworkCore;
using WithYou.Web.Data.Entities;

namespace WithYou.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Gender> Genders { get; set; }
        public DbSet<ProyectType> ProyectTypes { get; set; }
        public DbSet<Investigation> Investigations { get; set; }
        public DbSet<Researcher> Researchers { get; set; }
        public DbSet<RepublicState> RepublicStates { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
    }
}