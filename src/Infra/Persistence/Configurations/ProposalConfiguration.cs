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
    public class ProposalForApprovalConfiguration : IEntityTypeConfiguration<ProposalForApproval>
    {
        public void Configure(EntityTypeBuilder<ProposalForApproval> builder)
        {

            builder.Property(b => b.ProposalOption)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .HasIndex(sp => new { sp.NotesheetId, sp.ProposalOption })
                .IsUnique();
        }
    }
}
