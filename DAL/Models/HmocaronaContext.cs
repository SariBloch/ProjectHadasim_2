using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class HmocaronaContext : DbContext
{
    public HmocaronaContext()
    {
    }

    public HmocaronaContext(DbContextOptions<HmocaronaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sick> Sicks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vaccination> Vaccinations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=HMOCarona;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sick>(entity =>
        {
            entity.ToTable("Sick");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.DateBegin).HasColumnType("datetime");
            entity.Property(e => e.DateEnd).HasColumnType("datetime");

            entity.HasOne(p=>p.IdNavigation)
                .WithMany(p => p.Sicks)
                .HasConstraintName("FK_Sick_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.BornDate).HasColumnType("datetime");
            entity.Property(e => e.CityName).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.Tell).HasMaxLength(11);

            entity.HasMany(p => p.Sicks).WithOne(p => p.IdNavigation);
            entity.HasMany(p => p.Vaccinations).WithOne(p => p.IdNavigation);
        });

        modelBuilder.Entity<Vaccination>(entity =>
        {
            entity.ToTable("Vaccination");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Vaccinations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vaccination_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
