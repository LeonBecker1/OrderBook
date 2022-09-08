using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Application.Services.AuthenticationService;
using OrderBook.Infrastructure.Persistence;
using OrderBook.Application.Exceptions;

namespace OrderBook.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationservice
{
    private readonly UnitofWork _unitofWork;

    private readonly IPasswordverifyer _passwordverifyer;

    public AuthenticationService(IPasswordverifyer passwordverifyer, UnitofWork unitofWork)
    {
        _passwordverifyer = passwordverifyer;
        _unitofWork       = unitofWork;
    }

    public void AuthenticateLogin(string username, byte[] password)
    {

        byte[] pw = _unitofWork.Users.GetUserPassword(username);

        if (pw is not null)
        {
            throw new AuthenticateException();
        }

        else if(!Enumerable.SequenceEqual(pw!, password)){
            throw new AuthenticateException();
        }
    }

    public void AuthenticateRegister(string username, byte[] password)
    {
        if (_unitofWork.Users.HasUser(username))
        {
            throw new AuthenticateException();
        }
        if (!_passwordverifyer.passWordIsValid(password))
        {
            throw new AuthenticateException();
        }
    }
}
