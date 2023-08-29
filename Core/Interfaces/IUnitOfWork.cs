using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces;

public interface IUnitOfWork 
{
    ICountry Countries { get; }
   // ITypePerson TypePersons{ get; }
   // IRegion Regions {get; }

    Task<int> SaveAsync();
}