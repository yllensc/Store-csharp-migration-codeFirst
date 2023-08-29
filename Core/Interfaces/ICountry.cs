using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICountry : IGenericDemo<Country>
    {
        Task ToListAsync();
    }
    
}