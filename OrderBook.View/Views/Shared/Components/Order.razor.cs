using Microsoft.AspNetCore.Components;
using OrderBook.View.Models;

namespace OrderBook.View.Views.Shared.Components;

public partial class Order : ComponentBase
{
    private int x = 1;

    private List<OrderViewModel> orders;
    
    private List<PositionViewModel> positions;

    private List<OrderViewModel> activeOrders;

    private List<String> stocks;

    private String activeStock;

    private UserViewModel activeUser;

    protected override async Task OnInitializedAsync()
    {
        stocks       = _unitofWork.Stocks.GetAllAbreviations();
        activeStock  = stocks[0];
        activeOrders = Mapper.map(_unitofWork.Orders.FindByUnderlying(activeStock));
        positions    = Mapper.map(_unitofWork.Positions.FindByUser(activeUser.UserName).Result);

        base.OnInitializedAsync();
    }
}
