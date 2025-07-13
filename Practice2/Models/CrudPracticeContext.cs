using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practice2.Models;

public partial class CrudPracticeContext : DbContext
{
    public CrudPracticeContext()
    {
    }

    public CrudPracticeContext(DbContextOptions<CrudPracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserList> UserLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=Conn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserList>(entity =>
        {
            entity.HasKey(e => e.userId).HasName("PK__UserList__CB9A1CFF9253BD32");

            entity.ToTable("UserList");

            entity.Property(e => e.userId).HasColumnName("userId").ValueGeneratedNever(); 
            entity.Property(e => e.EmailAddress).HasMaxLength(50);
            entity.Property(e => e.UserAddress).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(40);
            entity.Property(e => e.UserRole).HasMaxLength(50);
            entity.Property(e => e.UserStatus).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<UserList>()
            .Property(e => e.userId)
            .ValueGeneratedOnAdd();
    }
   

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
