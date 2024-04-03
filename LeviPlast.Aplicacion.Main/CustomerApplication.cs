using LeviPlast.Transversal.Common;
using LeviPlast.Aplicacion.DTO;
using LeviPlast.Aplicacion.Interface;
using LeviPlast.Dominio.Entity;
using LeviPlast.Dominio.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
namespace LeviPlast.Aplicacion.Main
{
    public class CustomerApplication : ICustomersApplication
    {
        private readonly IMapper _mapper;
        private readonly ICustomersDomain _customersDomain;

        public CustomerApplication(IMapper mapper, ICustomersDomain customersDomain)
        {
            this._mapper = mapper;
            this._customersDomain = customersDomain;
        }
        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customersDomain.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa !!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsyn(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customersDomain.DeleteAsyn(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa !!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }

        public Response<CustomersDTO> Get(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = _customersDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }

        public Response<IEnumerable<CustomersDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customer = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa !!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customer = await _customersDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa !!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }

        public async Task<Response<CustomersDTO>> GetAsync(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = await _customersDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro encontrado Exitoso !!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }

        public Response<bool> Insert(CustomersDTO customers)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customers);
                response.Data = _customersDomain.Insert(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                
            }
            return response;
        }

        public async Task<Response<bool>> InsertAsync(CustomersDTO customers)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customers);
                response.Data = await _customersDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa !!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }

        public Response<bool> Update(CustomersDTO customers)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customers);
                response.Data = _customersDomain.Update(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa !!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomersDTO customers)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customers);
                response.Data = await _customersDomain.UpdateAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa !!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }
    }
}
