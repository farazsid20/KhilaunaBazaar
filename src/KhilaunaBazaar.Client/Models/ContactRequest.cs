using System.ComponentModel.DataAnnotations;

namespace KhilaunaBazaar.Client.Models;

public class ContactRequest
{
    [Required(ErrorMessage = "Full name is required")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    [Required(ErrorMessage = "Subject is required")]
    public string Subject { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}
