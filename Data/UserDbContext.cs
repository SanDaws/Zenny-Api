using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Zenny_Api.Models;

namespace Zenny_Api.Data;

public partial class UserDbContext : DbContext
{
    public UserDbContext()
    {
    }

    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SubscriptionType> SubscriptionTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<SubscriptionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subscription_types");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.SubscriptionType1, "subscription_type_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.SubscriptionType1)
                .HasMaxLength(100)
                .HasColumnName("subscription_type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Users).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.SubscriptionTypesId, "subscription_types_id");

            entity.HasIndex(e => e.Users, "users_UNIQUE").IsUnique();

            entity.Property(e => e.Users)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("users");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.SubscriptionTypesId)
                .HasColumnType("int(11)")
                .HasColumnName("subscription_types_id");

            entity.HasOne(d => d.SubscriptionTypes).WithMany(p => p.Users)
                .HasForeignKey(d => d.SubscriptionTypesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
