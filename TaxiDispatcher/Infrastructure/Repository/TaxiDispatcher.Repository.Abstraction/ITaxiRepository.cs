using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDispatcher.Repository.Model;

namespace TaxiDispatcher.Repository.Abstraction
{
    public interface ITaxiRepository
    {
        List<Taxi> GetAll();
        Taxi GetById(string Id);

        string Insert(Taxi taxi);
    }
}
