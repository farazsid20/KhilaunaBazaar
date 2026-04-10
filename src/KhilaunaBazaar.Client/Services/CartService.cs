using System.Text.Json;
using KhilaunaBazaar.Client.Models;
using Microsoft.JSInterop;

namespace KhilaunaBazaar.Client.Services;

public class CartItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class CartService
{
    private const string StorageKey = "khilaunaBazaarCart";
    private readonly IJSRuntime _js;
    private List<CartItem> _items = new();

    public event Action? OnChange;

    public CartService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task LoadAsync()
    {
        try
        {
            var json = await _js.InvokeAsync<string?>("localStorage.getItem", StorageKey);
            _items = string.IsNullOrEmpty(json) ? new List<CartItem>() : JsonSerializer.Deserialize<List<CartItem>>(json) ?? new List<CartItem>();
        }
        catch
        {
            _items = new List<CartItem>();
        }
    }

    public async Task SaveAsync()
    {
        await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, JsonSerializer.Serialize(_items));
        OnChange?.Invoke();
    }

    public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

    public int Count => _items.Sum(i => i.Quantity);
    public decimal Total => _items.Sum(i => i.Price * i.Quantity);

    public async Task AddAsync(int productId, string name, decimal price, int quantity = 1)
    {
        await LoadAsync();
        var existing = _items.FirstOrDefault(i => i.Id == productId);
        if (existing != null)
            existing.Quantity += quantity;
        else
            _items.Add(new CartItem { Id = productId, Name = name, Price = price, Quantity = quantity });
        await SaveAsync();
    }

    public async Task RemoveAsync(int productId)
    {
        await LoadAsync();
        _items = _items.Where(i => i.Id != productId).ToList();
        await SaveAsync();
    }

    public async Task UpdateQuantityAsync(int productId, int quantity)
    {
        await LoadAsync();
        var item = _items.FirstOrDefault(i => i.Id == productId);
        if (item == null) return;
        if (quantity <= 0)
        {
            _items = _items.Where(i => i.Id != productId).ToList();
        }
        else
        {
            item.Quantity = quantity;
        }
        await SaveAsync();
    }

    public async Task ClearAsync()
    {
        _items.Clear();
        await SaveAsync();
    }
}
