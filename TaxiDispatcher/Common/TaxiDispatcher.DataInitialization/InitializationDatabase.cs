using TaxiDispatcher.Repository.Abstraction;

namespace TaxiDispatcher.DataInitialization
{
    public interface IInitializationDatabase
    {
        void InitData();
    }
    public class InitializationDatabase : IInitializationDatabase
    {
        private readonly ITaxiRepository _taxiRepository;
        private readonly ITaxiCompanyRepository _taxiCompanyRepository;
        public InitializationDatabase(ITaxiRepository taxiRepository, ITaxiCompanyRepository taxiCompanyRepository)
        {
            _taxiRepository = taxiRepository;
            _taxiCompanyRepository = taxiCompanyRepository;
        }

        public void InitData()
        {
            InitTaxiCompanyData();
            InitTaxiData();
        }

        private void InitTaxiCompanyData()
        {
            Repository.Model.TaxiCompany taxiCompany1 = new Repository.Model.TaxiCompany { Id = Guid.NewGuid().ToString(), Name = "Naxi", Rate = 10 };
            Repository.Model.TaxiCompany taxiCompany2 = new Repository.Model.TaxiCompany { Id = Guid.NewGuid().ToString(), Name = "Alfa", Rate = 15 };
            Repository.Model.TaxiCompany taxiCompany3 = new Repository.Model.TaxiCompany { Id = Guid.NewGuid().ToString(), Name = "Gold", Rate = 13 };

            _taxiCompanyRepository.Insert(taxiCompany1);
            _taxiCompanyRepository.Insert(taxiCompany2);
            _taxiCompanyRepository.Insert(taxiCompany3);
        }

        private void InitTaxiData()
        {


            Repository.Model.Taxi taxi1 = new Repository.Model.Taxi { Id = Guid.NewGuid().ToString(), Name = "Predrag", Location = 50, Company = _taxiCompanyRepository.GetByName("Naxi") };
            Repository.Model.Taxi taxi2 = new Repository.Model.Taxi { Id = Guid.NewGuid().ToString(), Name = "Nenad", Location = 20, Company = _taxiCompanyRepository.GetByName("Naxi") };
            Repository.Model.Taxi taxi3 = new Repository.Model.Taxi { Id = Guid.NewGuid().ToString(), Name = "Dragan", Location = 80, Company = _taxiCompanyRepository.GetByName("Alfa") };
            Repository.Model.Taxi taxi4 = new Repository.Model.Taxi { Id = Guid.NewGuid().ToString(), Name = "Goran", Location = 5, Company = _taxiCompanyRepository.GetByName("Gold") };

            _taxiRepository.Insert(taxi1);
            _taxiRepository.Insert(taxi2);
            _taxiRepository.Insert(taxi3);
            _taxiRepository.Insert(taxi4);
        }
       
    }
}
