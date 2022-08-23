using Class06.EF.CodeFirst.Domain.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Class06.EF.CodeFirst.Domain
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext()
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaType> PizzasTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PizzaDb_CodeFirst;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);
            modelBuilder.Entity<Pizza>().Property(x => x.Name).IsRequired(false).HasMaxLength(100);
            modelBuilder.Entity<Pizza>()
                .HasOne(x => x.PizzaType)
                .WithMany(x => x.Pizzas)
                .HasForeignKey(x => x.PizzaTypeId);

            modelBuilder.Entity<PizzaType>().HasKey(x => x.Id);

            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Name = "Trajan",
                    Address = "Temnica",
                    City = "Skopje",
                    Email = "blabla@bla"
                });


            //base.OnModelCreating(modelBuilder);  //funkcionira i bez ova
        }


    }
}
