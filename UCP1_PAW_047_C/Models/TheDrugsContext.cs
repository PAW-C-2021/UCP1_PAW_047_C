using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_047_C.Models
{
    public partial class TheDrugsContext : DbContext
    {
        public TheDrugsContext()
        {
        }

        public TheDrugsContext(DbContextOptions<TheDrugsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Costumer> Costumers { get; set; }
        public virtual DbSet<DataObat> DataObats { get; set; }
        public virtual DbSet<Produk> Produks { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("id_admin");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama");
            });

            modelBuilder.Entity<Costumer>(entity =>
            {
                entity.HasKey(e => e.IdCostumer);

                entity.ToTable("Costumer");

                entity.Property(e => e.IdCostumer)
                    .ValueGeneratedNever()
                    .HasColumnName("id_costumer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alamat");

                entity.Property(e => e.NamaCostumer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_costumer");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("no_hp");
            });

            modelBuilder.Entity<DataObat>(entity =>
            {
                entity.HasKey(e => e.IdObat);

                entity.ToTable("Data_Obat");

                entity.Property(e => e.IdObat)
                    .ValueGeneratedNever()
                    .HasColumnName("id_obat");

                entity.Property(e => e.Harga)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("harga");

                entity.Property(e => e.Komposisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("komposisi");

                entity.Property(e => e.NamaObat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_obat");

                entity.Property(e => e.TanggalKadaluarsa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tanggal_kadaluarsa");
            });

            modelBuilder.Entity<Produk>(entity =>
            {
                entity.HasKey(e => e.IdProduk);

                entity.ToTable("Produk");

                entity.Property(e => e.IdProduk)
                    .ValueGeneratedNever()
                    .HasColumnName("id_produk");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
