using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;
namespace Infrastructure.Data;
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options): base(options){

        }
        public DbSet<Country> Countries { get; set;}
        public DbSet<State> States { get; set;}
        public DbSet<Region> Regions { get; set;}
        public DbSet<Person> Persons { get; set;}
        public DbSet<PersonType> PersonTypes { get; set;}
        public DbSet<Product> Products { get; set;}
        public DbSet<ProductPerson> ProductPeople { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ProductPerson>().HasKey(p => new{p.IdProductFK, p.IdPersonFK});
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
