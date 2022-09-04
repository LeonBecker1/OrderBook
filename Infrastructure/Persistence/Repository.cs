using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Application.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence;

public class Repository<Tentity> : IRepository<Tentity> where Tentity : class
{

    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public async Task<Tentity?> Add(Tentity entity)
    {
        _context.Set<Tentity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Tentity?>> Find(Expression<Func<Tentity, bool>> predicate)
    {
        return await _context.Set<Tentity>().Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<Tentity?>> GetAll()
    {
        var results = await _context.Set<Tentity>().ToListAsync();
        return results;
    }

    public async Task<Tentity?> GetById(int id)
    {
        return await _context.Set<Tentity>().FindAsync(id);
       
    }

    public async Task<Tentity?> Remove(Tentity entity)
    {
        _context.Set<Tentity>().Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
