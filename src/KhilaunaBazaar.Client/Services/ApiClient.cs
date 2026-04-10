using System.Net.Http.Json;
using KhilaunaBazaar.Client.Models;

namespace KhilaunaBazaar.Client.Services;

public class ApiClient
{
    private readonly HttpClient _http;

    public ApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken ct = default) =>
        await _http.GetFromJsonAsync<List<Product>>("api/products", ct) ?? new List<Product>();

    public async Task<IEnumerable<Product>> GetFeaturedProductsAsync(int count = 4, CancellationToken ct = default) =>
        await _http.GetFromJsonAsync<List<Product>>($"api/products/featured?count={count}", ct) ?? new List<Product>();

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string categorySlug, CancellationToken ct = default) =>
        await _http.GetFromJsonAsync<List<Product>>($"api/products/category/{Uri.EscapeDataString(categorySlug)}", ct) ?? new List<Product>();

    public async Task<Product?> GetProductByIdAsync(int id, CancellationToken ct = default) =>
        await _http.GetFromJsonAsync<Product>($"api/products/{id}", ct);

    public async Task<IEnumerable<Category>> GetCategoriesAsync(CancellationToken ct = default) =>
        await _http.GetFromJsonAsync<List<Category>>("api/categories", ct) ?? new List<Category>();

    public async Task<Category?> GetCategoryBySlugAsync(string slug, CancellationToken ct = default) =>
        await _http.GetFromJsonAsync<Category>($"api/categories/{Uri.EscapeDataString(slug)}", ct);

    public async Task<bool> SubmitContactAsync(ContactRequest request, CancellationToken ct = default)
    {
        var response = await _http.PostAsJsonAsync("api/contact", request, ct);
        return response.IsSuccessStatusCode;
    }
}
