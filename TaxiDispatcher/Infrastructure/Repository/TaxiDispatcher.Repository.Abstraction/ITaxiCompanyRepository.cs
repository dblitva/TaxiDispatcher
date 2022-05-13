using TaxiDispatcher.Repository.Model;

namespace TaxiDispatcher.Repository.Abstraction
{
    public interface ITaxiCompanyRepository
    {
        TaxiCompany GetByName(string name);

        string Insert(TaxiCompany taxiCompany);
    }
}
