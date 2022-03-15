using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;



namespace BestBuyBestPractices
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperProductRepository(conn);

            repo.CreateProduct("DVD", 12.99, 10);

            var products = repo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine(product.OnSale);
            }

            
            
        }
    } 
 }

