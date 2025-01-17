using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Core.Cars.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Db.SqlServer.Ef.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car>builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.LicensePlatePart1)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(x => x.LicensePlateLetter)
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(x => x.LicensePlatePart2)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(x => x.LicensePlatePart3)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(x => x.Model)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Manufacturers)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(c => new { c.LicensePlatePart1, c.LicensePlateLetter, c.LicensePlatePart2, c.LicensePlatePart3 })
                   .IsUnique();

            builder.Ignore(x => x.LicensePlate);
        }
    }
}
