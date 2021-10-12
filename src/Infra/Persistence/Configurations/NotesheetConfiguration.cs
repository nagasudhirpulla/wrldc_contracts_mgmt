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
            builder.Property(b => b.IndentingDept)
               .IsRequired();


            builder.Property(b => b.ReferenceNo)
                .IsRequired()
                .HasMaxLength(250);
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

            builder.Property(b => b.EstimatedCost)
               .IsRequired();

            builder.Property(b => b.BudgetOfferAddress)
                .HasMaxLength(250);

            builder.Property(b => b.BillOfQuantity)
               .IsRequired();

            builder.Property(b => b.Guarantee_Warranty)
               .IsRequired();

            builder.Property(b => b.Payment_Terms_CPG)
               .IsRequired();

            builder.Property(b => b.ModeOfTerm)
               .IsRequired();


            builder.Property(b => b.WorkCompletionSchedule)
               .IsRequired();

            builder.Property(b => b.BudgetProvision)
               .IsRequired();

            builder.Property(b => b.BPSerialNo)
               .IsRequired();

            builder.Property(b => b.BPUnderHead)
               .IsRequired();

            builder.Property(b => b.DopClause)
               .IsRequired();

            builder.Property(b => b.DopSection)
               .IsRequired();

            //builder.Property(b => b.ProposalForApproval)
            //   .IsRequired();

            builder.Property(b => b.ApprovingAuthority)
               .IsRequired();

        }
    }
}
