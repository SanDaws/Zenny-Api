using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Zenny_Api.Models;
using Zenny_Api.Seeders;

namespace Zenny_Api.Data;

public partial class MovementDbContext : DbContext
{
    public MovementDbContext()
    {
    }

    public MovementDbContext(DbContextOptions<MovementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Movement> Movements { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.HasIndex(e => e.Category1, "category_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Category1).HasColumnName("category");
        });

        modelBuilder.Entity<Movement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("movements");

            entity.HasIndex(e => e.CategoriesId, "categories_id");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.TransactionTypesId, "transaction_types_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CategoriesId)
                .HasDefaultValueSql("'9'")
                .HasColumnType("int(11)")
                .HasColumnName("categories_id");
            entity.Property(e => e.MovementDate)
                .HasColumnName("movement_date");
            entity.Property(e => e.TransactionTypesId)
                .HasColumnType("int(11)")
                .HasColumnName("transaction_types_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("transaction_types");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.TransactionType1, "transaction_type_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TransactionType1)
                .HasMaxLength(100)
                .HasColumnName("transaction_type");
        });

        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
        MovementSeeder.Seed(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
