using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApiDemo.Models;
using WebApiDemo.Controllers;


namespace WebApiDemo.Models.Repositories {

    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
    {
        new Shirt() { ShirtId = 1, Brand = "Brand1", Color = "Red", Gender = "Male", Price = 200, Size = 8 },
        new Shirt() { ShirtId = 2, Brand = "Brand2", Color = "Blue", Gender = "Female", Price = 300, Size = 10 },
        new Shirt() { ShirtId = 3, Brand = "Brand3", Color = "Green", Gender = "Unisex", Price = 1000, Size = 12 }
    };

        public static List<Shirt> GetAllShirts()
        {
            return shirts;
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }


        public static Shirt? GetShirtByProperty(string? brand, string? gender, string? color, int? size)
        {
            return (shirts.FirstOrDefault(
                x => !string.IsNullOrWhiteSpace(brand)
                && !string.IsNullOrWhiteSpace(x.Brand)
                && x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(gender) &&
                !string.IsNullOrWhiteSpace(x.Gender) &&
                x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(color) &&
                !string.IsNullOrWhiteSpace(x.Color) &&
                x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
                size.HasValue && x.Size.HasValue &&
                size.Value == x.Size.Value));

        }


        public static bool ShirtExits(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }
        public static void AddShirt(Shirt shirt)
        {
            shirt.ShirtId = shirts.Max(s => s.ShirtId) + 1;

            shirts.Add(shirt);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUpdate =shirts.First(x=>x.ShirtId == shirt.ShirtId); 

            shirtToUpdate.ShirtId= shirt.ShirtId;
            shirtToUpdate.Brand = shirt.Brand;

            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Color = shirt.Color;

      
        }

        public static void DeleteShirt(int id)
        {
            var shirt = shirts.FirstOrDefault(x => x.ShirtId == id);
            if (shirt != null)
            {
                shirts.Remove(shirt); // Remove the shirt from the list
            }
        }


    }
}
