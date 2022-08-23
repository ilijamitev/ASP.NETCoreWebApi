using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Class06.EF.CodeFirst.Domain.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                //.ToTable(nameof(User))  // vaka ke se imenuva User tabela
                .ToTable("Users")
                .HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);

            builder.Property(x => x.Phone).ValueGeneratedOnAdd();
        }
    }
}
