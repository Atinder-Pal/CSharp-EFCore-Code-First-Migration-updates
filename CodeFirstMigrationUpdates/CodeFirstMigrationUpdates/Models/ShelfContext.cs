using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace CodeFirstMigrationUpdates.Models
{
    class ShelfContext : DbContext
    {
        public virtual DbSet<Shelf> Shelves { get; set; }

        public virtual DbSet<ShelfMaterial> ShelfMaterials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection =
                    "server=localhost;" +
                    "port = 3306;" +
                    "user = root;" +
                    "database = codefirst_practice;";

                string version = "10.4.14-MariaDB";

                optionsBuilder.UseMySql(connection, x => x.ServerVersion(version));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShelfMaterial>(entity =>
            {
                entity.Property(e => e.MaterialName)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Shelf>(entity =>
            {
                string keyName = "FK_" + nameof(Shelf) +
                    "_" + nameof(ShelfMaterial);

                entity.Property(e => e.Name)
                 .HasCharSet("utf8mb4")
                 .HasCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.ShelfMaterialID)
                    .HasName(keyName);

                entity.HasOne(thisEntity => thisEntity.ShelfMaterial)
                    .WithMany(parent => parent.Shelves)
                    .HasForeignKey(thisEntity => thisEntity.ShelfMaterialID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName(keyName);

                //entity.HasData(
                //     new Shelf()
                //     {
                //         ID = -1,
                //         Name = "Work",
                        
                //     },
                //     new Shelf()
                //     {
                //         ID = -2,
                //         Name = "Computer"
                //     },
                //     new Shelf()
                //     {
                //         ID = -3,
                //         Name = "Kitchen"
                //     },
                //     new Shelf()
                //     {
                //         ID = -4,
                //         Name = "DiningRoom"
                //     },
                //     new Shelf()
                //     {
                //         ID = -5,
                //         Name = "BedRoom"
                //     }
                //);
            });
        }
    }
}
