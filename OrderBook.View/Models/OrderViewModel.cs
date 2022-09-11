
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace OrderBook.View.Models;

public class OrderViewModel
{

    public OrderViewModel(string underlying, decimal price, uint quantity, bool isBuy)
    {
        Underlying  = underlying;
        Price       = price;
        Quantity    = (int)quantity;
        IsBuy       = isBuy;
    }

    [Required(ErrorMessage = "Chosing a stock is required")]
    public string Underlying { get; set; }

    [Required(ErrorMessage = "Chosing a price is required")]
    [Range(1, 10000000, ErrorMessage = "Price must be between 1 and 10000000")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Chosing a  quantity is required")]
    [Range(1, 10000000, ErrorMessage = "Quantity must be between 1 and 10000000")]
    public int Quantity { get; set; }


    public bool IsBuy { get; set; }
}
