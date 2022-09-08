using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Application.Services.AuthenticationService;

public interface IAuthenticationservice
{
    public void AuthenticateLogin(string username, byte[] password);

    public void AuthenticateRegister(string username, byte[] password);


}
