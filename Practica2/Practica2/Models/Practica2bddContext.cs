using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practica2.Models;

public partial class Practica2bddContext : DbContext
{
    public Practica2bddContext()
    {
    }

    public Practica2bddContext(DbContextOptions<Practica2bddContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:practica2bdd");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("personas");

            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.Domicilio).HasMaxLength(50);
            entity.Property(e => e.Edad).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Oficio).HasMaxLength(50);
            entity.Property(e => e.PersonaId).HasColumnName("PersonaID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
