using CodeFirstMigrationUpdates.Models;
using System;
using System.Linq;

namespace CodeFirstMigrationUpdates
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputShelf, inputShelfMaterial;
            Console.Write("Please enter a shelf name to add: ");
            inputShelf = Console.ReadLine().Trim();


            using (ShelfContext context = new ShelfContext())
            {
                if (!context.Shelves.Any(shelf => shelf.Name.ToLower() == inputShelf.ToLower()))
                {
                    Console.Write("Please enter a shelf's material: ");
                    inputShelfMaterial = Console.ReadLine().Trim();
                    int shelfMaterialID = context.ShelfMaterials.Where(e => e.MaterialName.ToLower() == inputShelfMaterial.ToLower()).Select(d => d.ID).SingleOrDefault();
                    if (shelfMaterialID != 0)
                    {
                        addShelf(inputShelf, shelfMaterialID, context);
                        Console.WriteLine("Shelf successully added.");
                    }
                    else
                    {
                        Console.WriteLine("Shelf Material does not exist.Please add it in ShelfMaterial and then try adding this shelf;");
                    }
                }
                else
                {
                    Console.WriteLine("Shelf Name already exists. Please try a new name.");
                }
            }
        }
        public static void addShelf(string shelfName, int shelfMaterialID, ShelfContext context)
        {
            var newShelf = new Shelf(shelfName, shelfMaterialID);
            context.Shelves.Add(newShelf);
            context.SaveChanges();
        }
    }
}
