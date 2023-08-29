using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountry
    {
        private readonly StoreContext _context;

        public CountryRepository(StoreContext context): base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Country>> GetAllAsync(){
        return await _context.Countries
        .Include(p => p.States)
        .ToListAsync();
    }
    public override async Task<Country> GetByIdAsync(int id){
        return await _context.Countries
        .Include(p => p.States)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

        
    }
}