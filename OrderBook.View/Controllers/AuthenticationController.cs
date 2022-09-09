using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrderBook.View.Models;
using OrderBook.Application.Services.AuthenticationService;

namespace OrderBook.View.Controllers;

public class AuthenticationController : Controller
{

    private readonly IAuthenticationservice _authenticationService;

    public AuthenticationController(IAuthenticationservice authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel user)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel user)
    {
        throw new NotImplementedException();
    }
}
