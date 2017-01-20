using Test.DataGeneral;
using Test.Models;

namespace Test.Client
{
    public class CustomersImporter
    {
        private IRepository<Customer> customersRepository;
        private IFactory<Customer> repositoryFacotry;
        private IUnitOfWork unitOfWork;

        public CustomersImporter(IFactory<Customer> repositoryFacotry)
        {
            this.repositoryFacotry = repositoryFacotry;
            this.unitOfWork = this.repositoryFacotry.CreateUnitOfWork();
            this.customersRepository = this.repositoryFacotry.CreateRepository();
            this.repositoryFacotry.Reset();
        }

        public void Import()
        {
            for (int i = 0; i < 100; i++)
            {
                using (this.unitOfWork)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        this.customersRepository.Add(new Customer() { Name = "name", Number = "Number"});
                    }

                    this.unitOfWork.Commit();
                }
                System.Console.Write(".");
                this.unitOfWork = this.repositoryFacotry.CreateUnitOfWork();
                this.customersRepository = this.repositoryFacotry.CreateRepository();
                this.repositoryFacotry.Reset();
            }
        }
    }
}
