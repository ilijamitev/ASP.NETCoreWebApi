using Microsoft.EntityFrameworkCore;
using Notes.DataModels.Models;
using System.Security.Cryptography;
using System.Text;

namespace Notes.DataAccess.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(nameof(User)).HasKey(p => p.Id);

            modelBuilder.Entity<User>()
                .Property(p => p.Username)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(500);



            modelBuilder.Entity<Note>()
                .ToTable(nameof(Note))
                .HasKey(p => p.Id);

            modelBuilder.Entity<Note>()
                .HasOne(p => p.User)
                .WithMany(p => p.NoteList)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Note>()
                .Property(p => p.Text)
                .IsRequired()
                .HasMaxLength(1000);

            modelBuilder.Entity<Note>()
                .Property(p => p.Color)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Note>()
              .Property(p => p.Tag)
              .IsRequired()
              .HasDefaultValue(5);


            // SALT & PEPPER => stavanje na hash code sto ke go znaeme samo nie za da vo databaza ne moze da se procitaat senzitivni podatoci
            // SALT =password= PEPPER
            // ex. thisissalt.password123.thisispapper
            // koga ke se hashira ke bide
            // 34hnigiu34n34ngij.gj34ui34hg.jg349hg439ghj943

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("password1234"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Username = "bob007",
                    Password = hashedPassword
                });

            modelBuilder.Entity<Note>()
               .HasData(
               new Note
               {
                   Id = 1,
                   Text = "Buy juice",
                   Color = "blue",
                   Tag = 4,
                   UserId = 1,
               },
               new Note
               {
                   Id = 2,
                   Text = "Buy something",
                   Color = "orange",
                   Tag = 3,
                   UserId = 1,
               });


            base.OnModelCreating(modelBuilder);

        }
    }
}
