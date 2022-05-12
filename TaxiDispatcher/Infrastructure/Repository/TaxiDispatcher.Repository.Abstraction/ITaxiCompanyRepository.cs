using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDispatcher.Repository.Model;

namespace TaxiDispatcher.Repository.Abstraction
{
    public interface ITaxiCompanyRepository
    {
        List<TaxiCompany> GetAll();
        TaxiCompany GetById(string Id);
        TaxiCompany GetByName(string name);

        string Insert(TaxiCompany taxiCompany);
    }
}
