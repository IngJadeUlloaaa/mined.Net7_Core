using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinalEnt.Models;

public partial class NaeBsdContext : DbContext
{
    public NaeBsdContext()
    {
    }

    public NaeBsdContext(DbContextOptions<NaeBsdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Camion> Camions { get; set; }

    public virtual DbSet<Camionero> Camioneros { get; set; }

    public virtual DbSet<Conducir> Conducirs { get; set; }

    public virtual DbSet<Destino> Destinos { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Paquete> Paquetes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


        /* #warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
        You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see 
        https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see 
        http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Alfred_Perez; DataBase=NaeBSD; Trusted_Connection=True; TrustServerCertificate=True;"); */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Camion>(entity =>
        {
            entity.HasKey(e => e.MatriculaCn).HasName("PK__camion__EE2695A0D79EF52B");

            entity.ToTable("camion");

            entity.Property(e => e.MatriculaCn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("matricula_Cn");
            entity.Property(e => e.ModeloCn)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("modelo_Cn");
            entity.Property(e => e.TipoCn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_Cn");
        });

        modelBuilder.Entity<Camionero>(entity =>
        {
            entity.HasKey(e => e.IdC).HasName("PK__camioner__9DB7D2D650CAA484");

            entity.ToTable("camionero");

            entity.Property(e => e.IdC).HasColumnName("id_C");
            entity.Property(e => e.ApellidoC)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellido_C");
            entity.Property(e => e.CedulaC)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cedula_C");
            entity.Property(e => e.ClaveC)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave_C");
            entity.Property(e => e.CodigoPpk)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo_Ppk");
            entity.Property(e => e.CorreoC)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Correo_C");
            entity.Property(e => e.IdDpk).HasColumnName("id_Dpk");
            entity.Property(e => e.LicenciaC)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("licencia_C");
            entity.Property(e => e.NombreC)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre_C");

            entity.HasOne(d => d.CodigoPpkNavigation).WithMany(p => p.Camioneros)
                .HasForeignKey(d => d.CodigoPpk)
                .HasConstraintName("FK__camionero__codig__3F466844");

            entity.HasOne(d => d.IdDpkNavigation).WithMany(p => p.Camioneros)
                .HasForeignKey(d => d.IdDpk)
                .HasConstraintName("FK__camionero__id_Dp__403A8C7D");
        });

        modelBuilder.Entity<Conducir>(entity =>
        {
            entity.HasKey(e => e.IdCd).HasName("PK__conducir__0148D52F998112C8");

            entity.ToTable("conducir");

            entity.Property(e => e.IdCd)
                .ValueGeneratedNever()
                .HasColumnName("id_Cd");
            entity.Property(e => e.IdCnpk)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("id_Cnpk");
            entity.Property(e => e.IdCpk).HasColumnName("id_Cpk");

            entity.HasOne(d => d.IdCnpkNavigation).WithMany(p => p.Conducirs)
                .HasForeignKey(d => d.IdCnpk)
                .HasConstraintName("FK__conducir__id_Cnp__47DBAE45");

            entity.HasOne(d => d.IdCpkNavigation).WithMany(p => p.Conducirs)
                .HasForeignKey(d => d.IdCpk)
                .HasConstraintName("FK__conducir__id_Cpk__46E78A0C");
        });

        modelBuilder.Entity<Destino>(entity =>
        {
            entity.HasKey(e => e.IdD).HasName("PK__destino__9DB7D2D9D8CB13A4");

            entity.ToTable("destino");

            entity.Property(e => e.IdD).HasColumnName("id_D");
            entity.Property(e => e.CodigoD)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigo_D");
            entity.Property(e => e.CodigoPpk)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo_Ppk");
            entity.Property(e => e.IdDpk2).HasColumnName("id_Dpk2");
            entity.Property(e => e.NombreD)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nombre_D");

            entity.HasOne(d => d.CodigoPpkNavigation).WithMany(p => p.Destinos)
                .HasForeignKey(d => d.CodigoPpk)
                .HasConstraintName("FK__destino__codigo___4316F928");

            entity.HasOne(d => d.IdDpk2Navigation).WithMany(p => p.Destinos)
                .HasForeignKey(d => d.IdDpk2)
                .HasConstraintName("FK__destino__id_Dpk2__440B1D61");
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.IdD).HasName("PK__director__9DB7D2D9BFCCE85B");

            entity.ToTable("director");

            entity.Property(e => e.IdD).HasColumnName("id_D");
            entity.Property(e => e.ApellidoD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_D");
            entity.Property(e => e.CedulaD)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("cedula_D");
            entity.Property(e => e.ClaveD)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave_D");
            entity.Property(e => e.CorreoD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_D");
            entity.Property(e => e.NombreD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_D");
            entity.Property(e => e.NombreInstD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_Inst_D");
        });

        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.HasKey(e => e.CodigoP).HasName("PK__Paquete__2610F85E1EBB1FEF");

            entity.ToTable("Paquete");

            entity.Property(e => e.CodigoP)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo_P");
            entity.Property(e => e.DescripP)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descrip_P");
            entity.Property(e => e.DirecInstP)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direc_Inst_P");
            entity.Property(e => e.NombreInstP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_Inst_P");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
