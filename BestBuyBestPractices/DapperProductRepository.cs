using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        
       public void CreateProduct(string newname, double newprice, int newcategoryID)
        {
            _connection.Execute("INSERT INTO products (name, price, categoryID) VALUES (@name, @price, @categoryID);",
                new { name = newname, price = newprice, categoryID = newcategoryID });
        }

       public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM PRODUCTS");
        }

    }
}
