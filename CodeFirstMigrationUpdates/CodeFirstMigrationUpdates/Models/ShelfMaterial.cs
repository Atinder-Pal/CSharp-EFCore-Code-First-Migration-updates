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

        [Column( TypeName ="varchar(25)" )]
        public string MMaterialName { get; set; }
    }
}
