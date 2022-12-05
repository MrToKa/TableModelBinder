using System.ComponentModel.DataAnnotations;

namespace Models;

public class EnclosurePart
{
    [Key]
    public int Id { get; set; }

    public int PartId { get; set; }

    public int EnclosureId { get; set; }
    
    public string Tag { get; set; }

    public double Quantity { get; set; }

    public int PartOrderId { get; set; }
    
    public OrderDelivery Delivery { get; set; }   
}