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

                entity.HasData(
                     new ShelfMaterial()
                     {
                         ID = -1,
                         MaterialName = "Concrete",

                     },
                     new ShelfMaterial()
                     {
                         ID = -2,
                         MaterialName = "Marble"
                     },
                     new ShelfMaterial()
                     {
                         ID = -3,
                         MaterialName = "Rock"
                     },
                     new ShelfMaterial()
                     {
                         ID = -4,
                         MaterialName = "Ceramic"
                     },
                     new ShelfMaterial()
                     {
                         ID = -5,
                         MaterialName = "Plastic"
                     }
                );

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
            });
        }
    }
}
