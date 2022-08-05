namespace IYarles.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class ContactEmail
{
    [Required]
    [DisplayName("Your Name")]
    public string Name { get; set; }

    [Required]
    [DisplayName("Your Email")]
    public string Email { get; set; }

    [Required]
    [DisplayName("Message: Please include your orgnization name if applicable")]
    public string Message { get; set; }

    public ContactEmail(string name, string email, string message)
    {
        Name = name;
        Email = email;
        Message = message;
    }

    public string GenerateBody()
    {
        return $"Name: {Name}\nEmail: {Email}\n\nMessage: \n{Message}";
    }
}