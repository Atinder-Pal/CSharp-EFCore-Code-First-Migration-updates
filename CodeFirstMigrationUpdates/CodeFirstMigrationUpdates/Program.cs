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
                    Console.Write("Please enter shelf's material: ");
                    inputShelfMaterial = Console.ReadLine().Trim();
                    addShelf(inputShelf, inputShelfMaterial, context);
                }
                else
                {
                    Console.WriteLine("Shelf Name already exists. Please try a new name.");
                }
            }
        }
        public static void addShelf(string shelfName, string shelfMaterial, ShelfContext context)
        {
            int shelfMaterialID = context.ShelfMaterials.Where(e => e.MaterialName.ToLower() == shelfMaterial.ToLower()).Select(d => d.ID).SingleOrDefault();
            if (shelfMaterialID != 0)
            {
                var newShelf = new Shelf(shelfName, shelfMaterialID);
                context.Shelves.Add(newShelf);
                context.SaveChanges();
                Console.WriteLine("Shelf successully added.");
            }
            else
            {
                Console.WriteLine("Shelf Material does not exist.Do you want to add this material first? \nType yes or y to proceed or any other key to exit.");
                if (Console.ReadLine().Trim().ToLower() == "y" || Console.ReadLine().Trim().ToLower() == "yes")
                {
                    addShelfMaterial(shelfMaterial, context);
                    Console.WriteLine("Shelf Material added in the database!");
                    addShelf(shelfName, shelfMaterial, context);
                }
            }            
        }
        public static void addShelfMaterial(string shelfMaterialName, ShelfContext context)
        {
            var newShelfMaterial = new ShelfMaterial(shelfMaterialName);
            context.ShelfMaterials.Add(newShelfMaterial);
            context.SaveChanges();
        }
    }
}
