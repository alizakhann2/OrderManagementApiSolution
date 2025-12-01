namespace OrderManagementApi.Models;

public class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalAmount { get; set; }
    public string UserId { get; set; } = string.Empty;

    public ApplicationUser? User { get; set; }
}
