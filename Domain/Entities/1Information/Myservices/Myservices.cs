
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities._1Information.Myservices;

public class Myservices
{
    [Key]
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public string ServiceDescription { get; set; }
    public string? ServicePicture { get; set; }


}
