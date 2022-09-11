namespace OrderBook.View.Models;

public class PositionViewModel
{
    public PositionViewModel(string abreviation, int quantity)
    {
        Abreviation = abreviation;
        Quantity    = quantity;
    }

    public string Abreviation { get; set; } = null!;

    public int Quantity { get; set; }


}
