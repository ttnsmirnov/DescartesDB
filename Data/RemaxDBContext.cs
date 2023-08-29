using System;
using System.Collections.Generic;
using DescartesDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DescartesDB.Data
{
    public partial class RemaxDBContext : DbContext
    {
        public RemaxDBContext()
        {
        }

        public RemaxDBContext(DbContextOptions<RemaxDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Employer> Employers { get; set; } = null!;
        public virtual DbSet<Maison> Maisons { get; set; } = null!;
        public virtual DbSet<ListMaisonFromFunction> ListMaisonFromFunction { get; set; }
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //                optionsBuilder.UseSqlServer("Server=DESKTOP-KCFKKSQ; Database=RemaxDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.RefClients);

                entity.Property(e => e.RefClients)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Adresse).HasMaxLength(250);

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Prenom).HasMaxLength(50);

                entity.Property(e => e.RefEmployer)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("refEmployer");

                entity.Property(e => e.TypeCleint).HasMaxLength(50);

                entity.HasOne(d => d.RefEmployerNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.RefEmployer)
                    .HasConstraintName("FK_Clients_Employers");
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.HasKey(e => e.RefEmployer);

                entity.Property(e => e.RefEmployer)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Adresse).HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Numero).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Prenom).HasMaxLength(50);

                entity.Property(e => e.Salaire).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .HasColumnName("telephone");

                entity.Property(e => e.TypeEmployer).HasMaxLength(50);
            });

            modelBuilder.Entity<Maison>(entity =>
            {
                entity.HasKey(e => e.RefMaison);

                entity.Property(e => e.RefMaison)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Adresse).HasMaxLength(250);

                entity.Property(e => e.DateConstruction)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.NumeroPieces).HasMaxLength(50);

                entity.Property(e => e.Prix).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RefCleint)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("refCleint");

                entity.Property(e => e.Statut).HasMaxLength(50);

                entity.Property(e => e.TypeMaison).HasMaxLength(50);

                entity.HasOne(d => d.RefCleintNavigation)
                    .WithMany(p => p.Maisons)
                    .HasForeignKey(d => d.RefCleint)
                    .HasConstraintName("FK_Maisons_Clients");
            });
            modelBuilder.Entity<ListMaisonFromFunction>(entity =>
            {
                entity.HasNoKey();
            });
            
			OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
