using ShirtAPI.Models;

namespace ShirtAPI.Data
{
    public static class ShirtStore
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt{Id=1,Brand="nixe",Color="blue",Gender="men",Size=10,Price=20},
            new Shirt{Id=2,Brand="babibas",Color="green",Gender="men",Size=12,Price=25},
            new Shirt{Id=3,Brand="reeeebook",Color="yellow",Gender="women",Size=9,Price=30},
            new Shirt{Id=4,Brand="kinetik",Color="black",Gender="women",Size=8,Price=40}

        };
        public static List<Shirt> GetShirts()
        {
            return shirts;
        }
        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.Id == id);
        }
        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.Id == id);
        }
        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(
                x => !string.IsNullOrEmpty(brand) &&
                !string.IsNullOrEmpty(x.Brand) &&
                x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrEmpty(gender) &&
                !string.IsNullOrEmpty(x.Gender) &&
                x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)&&
                 !string.IsNullOrEmpty(color) &&
                !string.IsNullOrEmpty(x.Color) &&
                x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
                size.HasValue&&
                x.Size.HasValue&&
                size.Value==x.Size.Value);
        }
        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(x => x.Id);
            shirt.Id = maxId + 1;


            shirts.Add(shirt);
        }
        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUpdate=shirts.FirstOrDefault(x=>x.Id==shirt.Id);
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Gender = shirt.Gender;

        }
        public static void DeleteShirt(int id)
        {
            var shirt=GetShirtById(id);
            if (shirt!=null)
            {
                shirts.Remove(shirt);
            }
        }

    }
}
