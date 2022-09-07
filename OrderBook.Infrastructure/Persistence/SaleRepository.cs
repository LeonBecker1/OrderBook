using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Domain.Entities;
using OrderBook.Application.Persistence;
using OrderBook.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence;

public class SaleRepository : Repository<Sale>, ISaleRepository
{
    private readonly DbContext _context = null!;

    public SaleRepository(DbContext context) : base(context)
    {
    }

    public async Task<Sale> AddSale(Sale sale)
    {

        User buyer  = sale.Buyer;
        User seller = sale.Seller;

        PortfolioModel buyerPortfolio  = null!;
        PortfolioModel sellerPortfolio = null!;

        List<PositionModel> buyerPositions = new List<PositionModel>();
        List<PositionModel> sellerPositions = new List<PositionModel>();

        if(buyer.Portfolio.Positions is not null)
        {
            foreach(Position position in buyer.Portfolio.Positions)
            {
                StockModel s = new StockModel(position.Stock.StockId, position.Stock.Abreviation);

                buyerPositions.Add(new PositionModel(position.PositionId, position.Quantity,  s, 
                                   buyerPortfolio, position.Portfolio.PortfolioId));
            }
        }


        if (seller.Portfolio.Positions is not null)
        {
            foreach (Position position in seller.Portfolio.Positions)
            {
                StockModel s = new StockModel(position.Stock.StockId, position.Stock.Abreviation);

                buyerPositions.Add(new PositionModel(position.PositionId, position.Quantity, s,
                                    sellerPortfolio, position.Portfolio.PortfolioId));
            }
        }

        buyerPortfolio  = new PortfolioModel(buyer.Portfolio.PortfolioId, buyerPositions);
        sellerPortfolio = new PortfolioModel(seller.Portfolio.PortfolioId, sellerPositions);

    
        List<OrderModel>? buyerOrders = new List<OrderModel>();
        List<OrderModel>? sellerOrders = new List<OrderModel>();

        UserModel buyerModel  = null!;
        UserModel sellerModel = null!;

        if(buyer.Orders is not null)
        {
            foreach (Order order in buyer.Orders)
            {
                StockModel s = new StockModel(order.Underlying.StockId, order.Underlying.Abreviation);
                buyerOrders.Add(new OrderModel(order.OrderId, order.IsBuyOrder, order.Price,
                                order.Quantity, s, buyerModel));
            }
        }

        if (seller.Orders is not null)
        {
            foreach (Order order in seller.Orders)
            {
                StockModel s = new StockModel(order.Underlying.StockId, order.Underlying.Abreviation);
                buyerOrders.Add(new OrderModel(order.OrderId, order.IsBuyOrder, order.Price,
                                order.Quantity, s, sellerModel));
            }
        }

        buyerModel  = new UserModel(buyer.UserId, buyer.UserName, buyer.Balance, buyer.Password, buyerOrders,
                                   buyerPortfolio, buyerPortfolio.PortfolioId);

        sellerModel = new UserModel(seller.UserId, seller.UserName, seller.Balance, seller.Password, sellerOrders,
                                    sellerPortfolio, sellerPortfolio.PortfolioId);


        Stock stock           = sale.Underlying;
        StockModel stockModel = new StockModel(stock.StockId, stock.Abreviation);


        SaleModel saleModel = new SaleModel(sale.SaleId, sale.ExecutionTime, stockModel, buyerModel, 
                                            buyerModel.UserId, sellerModel, sellerModel.UserId);

        await _context.Set<SaleModel>().AddAsync(saleModel);

        return sale;
    }
}
