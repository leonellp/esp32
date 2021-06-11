using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using esp32.DA.Abstraction.Models;

#nullable disable

namespace esp32.DA
{
    public partial class esp32Context : DbContext
    {
        public esp32Context()
        {
        }

        public esp32Context(DbContextOptions<esp32Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Balanca> Balanca { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host = localhost; Database = esp32; Username = postgres; Password = 1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Balanca>(entity =>
            {
                entity.HasKey(e => e.Idbalanca)
                    .HasName("Peso_pkey");

                entity.Property(e => e.Idbalanca).ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnType("date");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Balanca)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProdutoId");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.Idproduto)
                    .HasName("produto_pkey");

                entity.Property(e => e.Idproduto).ValueGeneratedNever();

                entity.Property(e => e.Marca).HasMaxLength(200);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
