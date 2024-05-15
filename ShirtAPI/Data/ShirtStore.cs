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
        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.Id == id);
        }
        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.Id == id);
        }
    }
}
