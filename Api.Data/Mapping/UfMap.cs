using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Mapping
{
    public class UfMap : IEntityTypeConfiguration<UFEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UFEntity> builder)
        {
            builder.ToTable("Uf");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Sigla)
                    .IsUnique();
        }
    }
}
