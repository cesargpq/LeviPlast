using LeviPlast.Dominio.Entity;
using LeviPlast.Infraestructura.Interface;
using LeviPlast.Transversal.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace LeviPlast.Infraestructura.Repository
{
    public class CustomerRepository : ICustomersRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CustomerRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public bool Delete(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Task<bool> DeleteAsyn(string customerId)
        {
            throw new NotImplementedException();
        }

        public Customers Get(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var customer = connection.QuerySingle<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<Customers> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";
                var customer = connection.Query<Customers>(query, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";
                var customer = await connection.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var customer = await connection.QuerySingleAsync<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public bool Insert(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customers.CustomerId);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Fax", customers.Fax);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> InsertAsync(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customers.CustomerId);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Fax", customers.Fax);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customers.CustomerId);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Fax", customers.Fax);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customers.CustomerId);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Fax", customers.Fax);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
