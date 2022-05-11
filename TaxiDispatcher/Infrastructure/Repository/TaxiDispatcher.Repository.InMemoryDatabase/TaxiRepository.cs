using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDispatcher.Repository.Abstraction;
using TaxiDispatcher.Repository.Model;

namespace TaxiDispatcher.Repository.InMemoryDatabase
{
    public class TaxiRepository : ITaxiRepository
    {
        public List<Taxi> GetAll()
        {
            return new List<Taxi>
            {
                new Taxi { Id = Guid.NewGuid().ToString(), Name = "Pera"},
                new Taxi { Id = Guid.NewGuid().ToString(), Name = "Mika"}
            };
        }

        public Taxi GetById(string Id)
        {
            return new Taxi { Id = Guid.NewGuid().ToString(), Name = "Pera" };
        }
    }
}
