using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistence.Configurations
{
    public class NotesheetConfiguration : IEntityTypeConfiguration<Notesheet>
    {
        public void Configure(EntityTypeBuilder<Notesheet> builder)
        {

            builder.Property(b => b.ReferenceNo)
                .IsRequired()
                .HasMaxLength(250);

            // Name is unique
            builder
            .HasIndex(b => b.ReferenceNo)
            .IsUnique();

            builder.Property(b => b.PackageName)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.Type)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.ScopeOfWork)
               .IsRequired();

        }
    }
}
