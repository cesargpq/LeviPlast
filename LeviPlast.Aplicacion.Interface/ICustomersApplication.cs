using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeviPlast.Aplicacion.DTO;
using LeviPlast.Transversal.Common;

namespace LeviPlast.Aplicacion.Interface
{
    public interface ICustomersApplication
    {
        #region Syncronos
        Response<bool> Insert(CustomersDTO customers);
        Response<bool> Update(CustomersDTO customers);
        Response<bool> Delete(string customerId);
        Response<CustomersDTO> Get(string customerId);
        Response<IEnumerable<CustomersDTO>> GetAll();
        #endregion

        #region Asyncronos
        Task<Response<bool>> InsertAsync(CustomersDTO customers);
        Task<Response<bool>> UpdateAsync(CustomersDTO customers);
        Task<Response<bool>> DeleteAsyn(string customerId);
        Task<Response<CustomersDTO>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();
        #endregion
    }
}
