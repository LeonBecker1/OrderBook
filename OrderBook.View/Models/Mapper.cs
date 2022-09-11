using OrderBook.Domain.Entities;

namespace OrderBook.View.Models;

public class Mapper : IMapper
{

    public static List<OrderViewModel> map(List<Order> orders)
    {
        List<OrderViewModel> result = new List<OrderViewModel>();
        foreach(var order in orders)
        {
            result.Add(new OrderViewModel(order.Underlying.Abreviation, order.Price, order.Quantity, order.IsBuyOrder));
        }

        return result;
    }

    public static List<PositionViewModel> map(List<Position> positions)
    {
        List<PositionViewModel> result = new List<PositionViewModel>();
        foreach (var position in positions)
        {
            result.Add(new PositionViewModel(position.Stock.Abreviation, (int)position.Quantity));
        }

        return result;
    }
}
