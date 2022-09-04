using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence.Models;

public partial class User
{
    public User()
    {
        Orders = new HashSet<Order>();
        Portfolios = new HashSet<Portfolio>();
    }

    [Key]
    [Column("User_ID")]
    public int UserId { get; set; }
    [Column("User_Name")]
    [StringLength(64)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;
    [Column(TypeName = "money")]
    public decimal Balance { get; set; }
    [MaxLength(64)]
    public byte[] Password { get; set; } = null!;

    [InverseProperty("IssuerNavigation")]
    public virtual ICollection<Order> Orders { get; set; }
    [InverseProperty("UserNavigation")]
    public virtual ICollection<Portfolio> Portfolios { get; set; }
}
