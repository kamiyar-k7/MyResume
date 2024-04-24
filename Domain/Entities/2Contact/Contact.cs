
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities._3Contact;

public class Contact
{
    [Key]
    public int SenderId { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime DateTime { get; set; } = DateTime.UtcNow;

}
