using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrderBook.View.Models;

namespace OrderBook.View.Controllers;

public class OrderController : Controller
{
    public IActionResult Exchange() { return View(); }
}
