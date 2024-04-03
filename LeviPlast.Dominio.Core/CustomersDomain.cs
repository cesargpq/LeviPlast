using LeviPlast.Dominio.Entity;
using LeviPlast.Dominio.Interface;
using LeviPlast.Infraestructura.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LeviPlast.Dominio.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersDomain(ICustomersRepository customersRepository)
        {
            this._customersRepository = customersRepository;
        }
        public bool Delete(string customerId)
        {
            return _customersRepository.Delete(customerId);
        }

        public async Task<bool> DeleteAsyn(string customerId)
        {
            return await _customersRepository.DeleteAsyn(customerId);
        }

        public Customers Get(string customerId)
        {
            return _customersRepository.Get(customerId);
        }

        public IEnumerable<Customers> GetAll()
        {
            return _customersRepository.GetAll();
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _customersRepository.GetAllAsync();
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            return await _customersRepository.GetAsync(customerId);
        }

        public bool Insert(Customers customers)
        {
            return _customersRepository.Insert(customers);
        }

        public async Task<bool> InsertAsync(Customers customers)
        {
            return await _customersRepository.InsertAsync(customers);
        }

        public bool Update(Customers customers)
        {
            return _customersRepository.Update(customers);
        }

        public async Task<bool> UpdateAsync(Customers customers)
        {
            return await _customersRepository.UpdateAsync(customers);
        }
    }
}
