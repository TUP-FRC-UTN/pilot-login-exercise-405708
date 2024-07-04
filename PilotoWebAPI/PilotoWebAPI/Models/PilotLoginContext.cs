using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PilotoWebAPI.Models;

public partial class PilotLoginContext : DbContext
{
    public PilotLoginContext()
    {
    }

    public PilotLoginContext(DbContextOptions<PilotLoginContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Piloto> Pilotos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=pilotoDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("pk_pais");

            entity.Property(e => e.IdPais).HasColumnName("idPais");
            entity.Property(e => e.Pais)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("pais");
        });

        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.HasKey(e => e.IdPiloto).HasName("pk_piloto");

            entity.Property(e => e.IdPiloto).HasColumnName("idPiloto");
            entity.Property(e => e.CantHrVuelo).HasColumnName("cant_hr_vuelo");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Pais).HasColumnName("pais");

            entity.HasOne(d => d.PaisNavigation).WithMany(p => p.Pilotos)
                .HasForeignKey(d => d.Pais)
                .HasConstraintName("fk_pais");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userEmail");
            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("userId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
