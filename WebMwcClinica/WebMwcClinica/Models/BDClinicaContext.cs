using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebMwcClinica.Models
{
    public partial class BDClinicaContext : DbContext
    {
        public BDClinicaContext()
        {
        }

        public BDClinicaContext(DbContextOptions<BDClinicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditorium> Auditoria { get; set; } = null!;
        public virtual DbSet<Especialidad> Especialidads { get; set; } = null!;
        public virtual DbSet<PersonSpecialty> PersonSpecialties { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Clinica");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.HasKey(e => e.AudiId);

                entity.Property(e => e.AudiId).HasColumnName("Audi_Id");

                entity.Property(e => e.AudiCodigoRegistro).HasColumnName("Audi_CodigoRegistro");

                entity.Property(e => e.AudiEstado)
                    .HasMaxLength(1)
                    .HasColumnName("Audi_Estado")
                    .IsFixedLength();

                entity.Property(e => e.AudiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Audi_Fecha");

                entity.Property(e => e.AudiTipo)
                    .HasMaxLength(1)
                    .HasColumnName("Audi_Tipo")
                    .IsFixedLength();

                entity.Property(e => e.AudiUsuario)
                    .HasMaxLength(100)
                    .HasColumnName("Audi_Usuario")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.EspId);

                entity.ToTable("Especialidad");

                entity.Property(e => e.EspId).HasColumnName("esp_id");

                entity.Property(e => e.EspAdd)
                    .HasColumnType("datetime")
                    .HasColumnName("esp_add");

                entity.Property(e => e.EspDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("esp_delete");

                entity.Property(e => e.EspDescripcion)
                    .HasMaxLength(100)
                    .HasColumnName("esp_descripcion")
                    .IsFixedLength();

                entity.Property(e => e.EspEstado)
                    .HasMaxLength(1)
                    .HasColumnName("esp_estado")
                    .IsFixedLength();

                entity.Property(e => e.EspUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("esp_update");

                entity.Property(e => e.EspObservacion)
                              .HasMaxLength(100)
                              .HasColumnName("esp_observacion")
                              .IsFixedLength();

                entity.Property(e => e.EspImag)
                   .HasColumnType("binary")
                   .HasColumnName("esp_imag");
            });

            modelBuilder.Entity<PersonSpecialty>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Person_Specialty");

                entity.Property(e => e.EspId).HasColumnName("esp_id");

                entity.Property(e => e.PerId).HasColumnName("per_id");

                entity.HasOne(d => d.Esp)
                    .WithMany()
                    .HasForeignKey(d => d.EspId)
                    .HasConstraintName("FK_Person_Specialty_Especialidad");

                entity.HasOne(d => d.Per)
                    .WithMany()
                    .HasForeignKey(d => d.PerId)
                    .HasConstraintName("FK_Person_Specialty_Persona");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.PerId);

                entity.ToTable("Persona");

                entity.Property(e => e.PerId).HasColumnName("per_id");

                entity.Property(e => e.PerApellido)
                    .HasMaxLength(100)
                    .HasColumnName("per_apellido")
                    .IsFixedLength();

                entity.Property(e => e.PerCedula)
                    .HasMaxLength(10)
                    .HasColumnName("per_cedula")
                    .IsFixedLength();

                entity.Property(e => e.PerCorreo)
                    .HasMaxLength(100)
                    .HasColumnName("per_correo")
                    .IsFixedLength();

                entity.Property(e => e.PerDireccion)
                    .HasMaxLength(200)
                    .HasColumnName("per_direccion")
                    .IsFixedLength();

                entity.Property(e => e.PerEstado)
                    .HasMaxLength(1)
                    .HasColumnName("per_estado")
                    .IsFixedLength();

                entity.Property(e => e.PerFechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("per_fechaCreacion");

                entity.Property(e => e.PerFechaEliminar)
                    .HasColumnType("datetime")
                    .HasColumnName("per_fechaEliminar");

                entity.Property(e => e.PerFechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("per_fechaModificacion");

                entity.Property(e => e.PerFechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("per_fechaNacimiento");

                entity.Property(e => e.PerGenero)
                    .HasMaxLength(1)
                    .HasColumnName("per_genero")
                    .IsFixedLength();

                entity.Property(e => e.PerNombre)
                    .HasMaxLength(100)
                    .HasColumnName("per_nombre")
                    .IsFixedLength();

                entity.Property(e => e.PerTelefono)
                    .HasMaxLength(10)
                    .HasColumnName("per_telefono")
                    .IsFixedLength();

                entity.Property(e => e.PerTiposangre)
                    .HasMaxLength(5)
                    .HasColumnName("per_tiposangre")
                    .IsFixedLength();


                entity.Property(e => e.PerPhoto)
                    .HasMaxLength(6)
                    .HasColumnName("per_photo")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.RolDescription)
                    .HasMaxLength(50)
                    .HasColumnName("rol_description")
                    .IsFixedLength();

                entity.Property(e => e.RolStatus)
                    .HasMaxLength(1)
                    .HasColumnName("rol_status")
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsuId);

                entity.ToTable("User");

                entity.Property(e => e.UsuId).HasColumnName("usu_id");

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.UsuAdd)
                    .HasColumnType("datetime")
                    .HasColumnName("usu_add");

                entity.Property(e => e.UsuDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("usu_delete");

                entity.Property(e => e.UsuEmail)
                    .HasMaxLength(100)
                    .HasColumnName("usu_email")
                    .IsFixedLength();

                entity.Property(e => e.UsuIntentos).HasColumnName("usu_intentos");

                entity.Property(e => e.UsuLastname)
                    .HasMaxLength(100)
                    .HasColumnName("usu_lastname")
                    .IsFixedLength();

                entity.Property(e => e.UsuName)
                    .HasMaxLength(100)
                    .HasColumnName("usu_name")
                    .IsFixedLength();

                entity.Property(e => e.UsuPassword)
                    .HasMaxLength(100)
                    .HasColumnName("usu_password")
                    .IsFixedLength();

                entity.Property(e => e.UsuStatus)
                    .HasMaxLength(1)
                    .HasColumnName("usu_status")
                    .IsFixedLength();

                entity.Property(e => e.UsuSueldo)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("usu_sueldo");

                entity.Property(e => e.UsuUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("usu_update");

                entity.Property(e => e.UsuUsername)
                    .HasMaxLength(100)
                    .HasColumnName("usu_username")
                    .IsFixedLength();

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
