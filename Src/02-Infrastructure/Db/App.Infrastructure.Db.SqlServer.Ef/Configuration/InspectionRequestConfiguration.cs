using App.Domain.Core.Request.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Db.SqlServer.Ef.Configuration
{
    public class InspectionRequestConfiguration : IEntityTypeConfiguration<InspectionRequest>
    {
        public void Configure(EntityTypeBuilder<InspectionRequest> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NationalId)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.Address)
                .HasMaxLength(200);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.HasOne(x => x.Car)
                .WithMany()
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
