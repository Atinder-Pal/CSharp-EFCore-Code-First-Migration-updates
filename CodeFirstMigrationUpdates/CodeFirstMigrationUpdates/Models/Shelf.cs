using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstMigrationUpdates.Models
{
    [Table("Shelf")]
    class Shelf
    {
        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName ="int(10)")]
        public int ShelfMaterialID { get; set; }

        [ForeignKey(nameof(ShelfMaterialID))]
        [InverseProperty(nameof(Models.ShelfMaterial.Shelves))]
        public virtual ShelfMaterial ShelfMaterial { get; set; }
        public Shelf()
        {
            Name = "Default_Shelf";
        }

        public Shelf(string shelfName)
        {
            Name = shelfName;
        }
    }
}
