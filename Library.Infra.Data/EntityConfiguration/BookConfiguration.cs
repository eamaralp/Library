using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infra.Data.EntityConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.Id);

            //Property(e => e.Nome).IsRequired();

            //Property(e => e.Autor).IsRequired();

            //Property(e => e.Editora).HasMaxLength(100).IsRequired();
        }
    }
}
