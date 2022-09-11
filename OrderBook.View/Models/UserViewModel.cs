using System.ComponentModel.DataAnnotations;

namespace OrderBook.View.Models;

public class UserViewModel
{
    [Required]
    public string UserName { get; set; }

    public string Password { get; set; }
}
