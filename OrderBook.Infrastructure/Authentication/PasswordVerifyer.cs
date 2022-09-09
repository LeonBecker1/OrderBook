using OrderBook.Infrastructure.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace OrderBook.Infrastructure.Authentication;

public class PasswordVerifyer : IPasswordverifyer
{

    private readonly PasswordOptions _passwordOptions;

    public PasswordVerifyer( IOptions<PasswordOptions> passwordOptions)
    {
        _passwordOptions = passwordOptions.Value;
    }

    public bool passWordIsValid(byte[] password)
    {
        String pw = Encoding.UTF8.GetString(password);
        bool isValid = true;

        foreach(string pattern in _passwordOptions.PasswordPatterns)
        {
            Regex regex = new Regex(pattern);
            isValid &= regex.IsMatch(pw);
        }

        return isValid;
    }
}
