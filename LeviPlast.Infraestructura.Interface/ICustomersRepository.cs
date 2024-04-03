using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeviPlast.Dominio.Entity;
namespace LeviPlast.Infraestructura.Interface
{
    public interface ICustomersRepository
    {
        #region Syncronos
        bool Insert(Customers customers);
        bool Update(Customers customers);
        bool Delete(string customerId);
        Customers Get(string customerId);
        IEnumerable<Customers> GetAll();

        #endregion

        #region Asyncronos
        Task<bool> InsertAsync(Customers customers);
        Task<bool> UpdateAsync(Customers customers);
        Task<bool> DeleteAsyn(string customerId);
        Task<Customers> GetAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();
        #endregion

    }
}
