using KhilaunaBazaar.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhilaunaBazaar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    [HttpPost]
    public IActionResult Submit([FromBody] ContactRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.FullName) || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Subject))
            return BadRequest(new { message = "Full name, email, and subject are required." });

        // In a real app: save to DB, send email, etc.
        return Ok(new { message = "Thank you! Your message has been sent successfully. We will get back to you soon." });
    }
}
