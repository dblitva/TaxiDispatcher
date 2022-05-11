using TaxiDispatcher.Common.Extensions;
using TaxiDispatcher.Repository.Model;

namespace TaxiDispatcher.InMemoryDatabase
{
    public class TaxiCompanyList : List<TaxiCompany>
    {
        private readonly Dictionary<string, List<TaxiCompany>> taxiCompanyIdIndex = new Dictionary<string, List<TaxiCompany>>();

        public new void Add(TaxiCompany taxiCompany)
        {
            if (taxiCompany == null) return;

            taxiCompanyIdIndex.AddOrUpdate(taxiCompany.Id,
                index =>
                {
                    index.Add(taxiCompany);
                    return index;
                },
                () => new List<TaxiCompany> { taxiCompany });


            base.Add(taxiCompany);
        }

        public List<TaxiCompany> GetByTaxiId(string taxiCompanyId)
        {
            List<TaxiCompany> taxiCompany = new List<TaxiCompany>();
            var success = taxiCompanyIdIndex.TryGetValue(taxiCompanyId, out var taxiCompanies);

            if (success)
            {
                return taxiCompanies;
            }
            else
            {
                taxiCompany = FindAll(x => x.Id.Equals(taxiCompanyId));
                if (taxiCompany != null && taxiCompany.Any())
                {
                    taxiCompanyIdIndex.AddOrUpdate(taxiCompany.First().Id,
                    index => { },
                    () => taxiCompany);
                }
            }
            return taxiCompany;
        }
    }
}
