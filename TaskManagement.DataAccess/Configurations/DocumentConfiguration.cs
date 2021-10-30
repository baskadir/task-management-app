using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(200).IsRequired();
            builder.Property(x => x.DocumentPath).HasMaxLength(500).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.Duty).WithMany(x => x.Documents).HasForeignKey(x => x.DutyId);
        }
    }
}
