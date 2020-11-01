using CodeFirstMigrationUpdates.Models;
using System;
using System.Globalization;
using System.Threading;
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
            //Citation: https://stackoverflow.com/questions/1206019/converting-string-to-title-case
            //The below code borrowed fromabove source dint work.
            //TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            //Citation
            //https://www.c-sharpcorner.com/blogs/convert-a-string-to-title-case-in-c-sharp1
            //Borrowed code from above source on how to ocnvert string to TitleCase
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            var newShelfMaterial = new ShelfMaterial(textInfo.ToTitleCase(shelfMaterialName.ToLower()));
            //End Citation
            context.ShelfMaterials.Add(newShelfMaterial);
            context.SaveChanges();
        }
    }
}
