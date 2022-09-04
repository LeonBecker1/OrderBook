using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace OrderBook.Application.Persistence;

public interface IRepository<Tentity> where Tentity : class
{
    Task<Tentity?> GetById(int id);

    Task<IEnumerable<Tentity?>> GetAll();

    Task<IEnumerable<Tentity?>> Find(Expression<Func<Tentity, bool>> predicate);

    Task<Tentity?> Add(Tentity entity);

    Task<Tentity?> Remove(Tentity entity);

}
