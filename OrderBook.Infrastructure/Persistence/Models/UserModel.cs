using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence.Models;

public partial class UserModel
{
    

    /* public UserModel(int userId, string userName, decimal balance, byte[] password, ICollection<OrderModel> orders, PortfolioModel portfolio)
    {
        UserId = userId;
        UserName = userName;
        Balance = balance;
        Password = password;
        Orders = orders;
        Portfolio = portfolio;
    } */

    [Key]
    [Column("User_Id")]
    public int UserId { get; set; }

    [Required]
    [Column("User_Name", TypeName = "Varchar(32)")]
    public string UserName { get; set; } = null!;

    [Column("Balance", TypeName = "Decimal(6,2)")]
    public decimal Balance { get; set; }

    [Required]
    [Column("Password", TypeName = "Binary(64)")]
    public byte[] Password { get; set; } = null!;

    public ICollection<OrderModel>? Orders { get; set; }

    [Required]
    [Column("Portfolio")]
    public PortfolioModel Portfolio { get; set; } = null!;

    
}
