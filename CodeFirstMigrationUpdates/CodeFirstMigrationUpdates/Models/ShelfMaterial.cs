using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstMigrationUpdates.Models
{
    [Table("Shelf_Material")]
    class ShelfMaterial
    {
        [Key]
        [Column( TypeName ="int(10)" )]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column( TypeName ="varchar(25)" )]
        public string MaterialName { get; set; }

        [InverseProperty(nameof(Models.Shelf.ShelfMaterial))]
        public virtual ICollection<Shelf> Shelves { get; set; }

        public ShelfMaterial()
        {
            MaterialName = "Default_Shelf";            
        }

        public ShelfMaterial(string shelfName)
        {
            MaterialName = shelfName;            
        }
    }
}
