using KhilaunaBazaar.Api.Models;

namespace KhilaunaBazaar.Api.Services;

public class ProductStore
{
    private readonly List<Product> _products;
    private static readonly object _lock = new();

    public ProductStore()
    {
        _products = SeedProducts();
    }

    public IReadOnlyList<Product> GetAll() => _products.AsReadOnly();

    public IReadOnlyList<Product> GetByCategory(string categorySlug) =>
        _products.Where(p => string.Equals(p.CategorySlug, categorySlug, StringComparison.OrdinalIgnoreCase)).ToList();

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public IReadOnlyList<Product> GetFeatured(int count = 4) =>
        _products
            .GroupBy(p => p.CategorySlug)
            .Select(g => g.First())
            .Take(count)
            .ToList();

    private static List<Product> SeedProducts()
    {
        return new List<Product>
        {
            new() { Id = 1, Name = "Space Explorer Robot", CategorySlug = "action-figures", Price = 29.99m, Rating = 4.5, Description = "Advanced robot with LED lights and sound effects", ImageUrl = "https://via.placeholder.com/400x300/667eea/ffffff?text=Space+Robot" },
            new() { Id = 2, Name = "Superhero Action Set", CategorySlug = "action-figures", Price = 39.99m, Rating = 4.8, Description = "Set of 5 superhero figures with accessories", ImageUrl = "https://via.placeholder.com/400x300/FF6B6B/ffffff?text=Superhero+Set" },
            new() { Id = 3, Name = "Dinosaur T-Rex", CategorySlug = "action-figures", Price = 24.99m, Rating = 4.3, Description = "Realistic dinosaur figure with movable joints", ImageUrl = "https://via.placeholder.com/400x300/8B4513/ffffff?text=Dinosaur" },
            new() { Id = 4, Name = "Knight with Horse", CategorySlug = "action-figures", Price = 34.99m, Rating = 4.6, Description = "Medieval knight figure with armor and horse", ImageUrl = "https://via.placeholder.com/400x300/696969/ffffff?text=Knight" },
            new() { Id = 5, Name = "Ninja Warrior Set", CategorySlug = "action-figures", Price = 27.99m, Rating = 4.4, Description = "Set of ninja warriors with weapons", ImageUrl = "https://via.placeholder.com/400x300/1C1C1C/ffffff?text=Ninja+Set" },
            new() { Id = 6, Name = "Pirate Captain", CategorySlug = "action-figures", Price = 26.99m, Rating = 4.5, Description = "Pirate figurine with pirate ship accessories", ImageUrl = "https://via.placeholder.com/400x300/8B4513/ffffff?text=Pirate" },
            new() { Id = 7, Name = "Princess Doll Set", CategorySlug = "dolls", Price = 34.99m, Rating = 4.8, Description = "Beautiful princess doll with royal outfit", ImageUrl = "https://via.placeholder.com/400x300/FFD700/ffffff?text=Princess" },
            new() { Id = 8, Name = "Baby Doll with Accessories", CategorySlug = "dolls", Price = 32.99m, Rating = 4.7, Description = "Soft baby doll with clothing and accessories", ImageUrl = "https://via.placeholder.com/400x300/FFB6C1/ffffff?text=Baby+Doll" },
            new() { Id = 9, Name = "Fashion Model Doll", CategorySlug = "dolls", Price = 28.99m, Rating = 4.5, Description = "Fashion doll with trendy outfits", ImageUrl = "https://via.placeholder.com/400x300/FF69B4/ffffff?text=Fashion+Doll" },
            new() { Id = 10, Name = "Ballerina Doll", CategorySlug = "dolls", Price = 31.99m, Rating = 4.6, Description = "Graceful ballerina doll in pink tutu", ImageUrl = "https://via.placeholder.com/400x300/FF1493/ffffff?text=Ballerina" },
            new() { Id = 11, Name = "Mermaid Doll", CategorySlug = "dolls", Price = 29.99m, Rating = 4.7, Description = "Fantasy mermaid doll with tail and crown", ImageUrl = "https://via.placeholder.com/400x300/00CED1/ffffff?text=Mermaid" },
            new() { Id = 12, Name = "Doctor Doll Set", CategorySlug = "dolls", Price = 33.99m, Rating = 4.4, Description = "Career doll set with medical accessories", ImageUrl = "https://via.placeholder.com/400x300/4169E1/ffffff?text=Doctor" },
            new() { Id = 13, Name = "Mega Building Blocks", CategorySlug = "building-blocks", Price = 49.99m, Rating = 4.6, Description = "500-piece building block set", ImageUrl = "https://via.placeholder.com/400x300/FFD700/000000?text=Building+Blocks" },
            new() { Id = 14, Name = "Castle Construction Kit", CategorySlug = "building-blocks", Price = 44.99m, Rating = 4.7, Description = "Build your own medieval castle", ImageUrl = "https://via.placeholder.com/400x300/696969/ffffff?text=Castle" },
            new() { Id = 15, Name = "City Builder Set", CategorySlug = "building-blocks", Price = 39.99m, Rating = 4.5, Description = "Create a complete city with houses and roads", ImageUrl = "https://via.placeholder.com/400x300/C0C0C0/000000?text=City+Builder" },
            new() { Id = 16, Name = "Space Station Kit", CategorySlug = "building-blocks", Price = 54.99m, Rating = 4.8, Description = "Build an intergalactic space station", ImageUrl = "https://via.placeholder.com/400x300/4B0082/ffffff?text=Space+Station" },
            new() { Id = 17, Name = "Bridge Construction Set", CategorySlug = "building-blocks", Price = 35.99m, Rating = 4.4, Description = "Engineering building set", ImageUrl = "https://via.placeholder.com/400x300/8B4513/ffffff?text=Bridge" },
            new() { Id = 18, Name = "Dinosaur World Blocks", CategorySlug = "building-blocks", Price = 42.99m, Rating = 4.6, Description = "Build dinosaur habitats", ImageUrl = "https://via.placeholder.com/400x300/228B22/ffffff?text=Dino+World" },
            new() { Id = 19, Name = "Outdoor Sports Kit", CategorySlug = "outdoor-toys", Price = 39.99m, Rating = 4.7, Description = "Complete set with badminton, frisbee, and more", ImageUrl = "https://via.placeholder.com/400x300/228B22/ffffff?text=Sports+Kit" },
            new() { Id = 20, Name = "Roller Skates", CategorySlug = "outdoor-toys", Price = 44.99m, Rating = 4.5, Description = "Adjustable roller skates for kids", ImageUrl = "https://via.placeholder.com/400x300/FF4500/ffffff?text=Roller+Skates" },
            new() { Id = 21, Name = "Skateboard", CategorySlug = "outdoor-toys", Price = 49.99m, Rating = 4.6, Description = "Professional small skateboard", ImageUrl = "https://via.placeholder.com/400x300/8B4513/ffffff?text=Skateboard" },
            new() { Id = 22, Name = "Jump Rope Set", CategorySlug = "outdoor-toys", Price = 19.99m, Rating = 4.8, Description = "Colorful jump rope with counter", ImageUrl = "https://via.placeholder.com/400x300/FF69B4/000000?text=Jump+Rope" },
            new() { Id = 23, Name = "Lawn Bowling Set", CategorySlug = "outdoor-toys", Price = 34.99m, Rating = 4.4, Description = "Bowling pins and balls for lawn", ImageUrl = "https://via.placeholder.com/400x300/228B22/ffffff?text=Bowling" },
            new() { Id = 24, Name = "Kite Flying Kit", CategorySlug = "outdoor-toys", Price = 24.99m, Rating = 4.7, Description = "Colorful kite with flying string", ImageUrl = "https://via.placeholder.com/400x300/FFD700/000000?text=Kite" },
            new() { Id = 25, Name = "Chess Master Board", CategorySlug = "board-games", Price = 29.99m, Rating = 4.6, Description = "Elegant chess set for kids", ImageUrl = "https://via.placeholder.com/400x300/696969/ffffff?text=Chess" },
            new() { Id = 26, Name = "Monopoly Junior", CategorySlug = "board-games", Price = 24.99m, Rating = 4.7, Description = "Kid-friendly version of Monopoly", ImageUrl = "https://via.placeholder.com/400x300/FF0000/ffffff?text=Monopoly" },
            new() { Id = 27, Name = "Candy Land Adventure", CategorySlug = "board-games", Price = 19.99m, Rating = 4.8, Description = "Classic candy-themed board game", ImageUrl = "https://via.placeholder.com/400x300/FFD700/000000?text=Candy+Land" },
            new() { Id = 28, Name = "Snake and Ladders Deluxe", CategorySlug = "board-games", Price = 22.99m, Rating = 4.5, Description = "Wooden board game set", ImageUrl = "https://via.placeholder.com/400x300/8B4513/ffffff?text=Snake+Ladders" },
            new() { Id = 29, Name = "Memory Card Game", CategorySlug = "board-games", Price = 17.99m, Rating = 4.9, Description = "Classic memory matching game", ImageUrl = "https://via.placeholder.com/400x300/4169E1/ffffff?text=Memory" },
            new() { Id = 30, Name = "Puzzle Adventure Game", CategorySlug = "board-games", Price = 26.99m, Rating = 4.6, Description = "Strategy and puzzle combined", ImageUrl = "https://via.placeholder.com/400x300/9370DB/ffffff?text=Puzzle" },
            new() { Id = 31, Name = "Teddy Bear", CategorySlug = "stuffed-animals", Price = 22.99m, Rating = 4.9, Description = "Soft cuddly teddy bear", ImageUrl = "https://via.placeholder.com/400x300/8B4513/ffffff?text=Teddy+Bear" },
            new() { Id = 32, Name = "Unicorn Plush", CategorySlug = "stuffed-animals", Price = 26.99m, Rating = 4.8, Description = "Magical rainbow unicorn", ImageUrl = "https://via.placeholder.com/400x300/FF69B4/ffffff?text=Unicorn" },
            new() { Id = 33, Name = "Dinosaur Plush Toy", CategorySlug = "stuffed-animals", Price = 24.99m, Rating = 4.7, Description = "Soft dinosaur friend", ImageUrl = "https://via.placeholder.com/400x300/90EE90/000000?text=Dino+Plush" },
            new() { Id = 34, Name = "Cat Kitten Plush", CategorySlug = "stuffed-animals", Price = 21.99m, Rating = 4.8, Description = "Adorable kitten plush toy", ImageUrl = "https://via.placeholder.com/400x300/FFB347/000000?text=Kitten" },
            new() { Id = 35, Name = "Lion King Plush", CategorySlug = "stuffed-animals", Price = 28.99m, Rating = 4.9, Description = "Roaring lion plush", ImageUrl = "https://via.placeholder.com/400x300/FFD700/000000?text=Lion" },
            new() { Id = 36, Name = "Panda Bear Plush", CategorySlug = "stuffed-animals", Price = 23.99m, Rating = 4.8, Description = "Cute bamboo-loving panda", ImageUrl = "https://via.placeholder.com/400x300/000000/ffffff?text=Panda" }
        };
    }
}
