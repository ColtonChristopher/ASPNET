
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Testing.Models
{
	public class ProductRepository : IProductRepository
	{

        private readonly IDbConnection _conn;


        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Products AssignCategory()
        {
            var CategoryList = GetCategories();
            var product = new Products();
            product.Categories = CategoryList;
            return product;
        }

        public void DeleteProduct(Products product)
        {
            _conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;",
                                       new { id = product.ProductID });
            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;",
                                       new { id = product.ProductID });
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;",
                                       new { id = product.ProductID });

        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _conn.Query<Products>("SELECT * FROM products;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM CATEGORIES");
        }

        public Products GetProduct(int id)
        {
            return _conn.QuerySingle<Products>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
               new { id = id });
        }

        public void InsertProduct(Products productToInsert)
        {
            _conn.Execute("INSERT INTO PRODUCTS (NAME, PRICE, CATEGORYID) VALUES(@name, @price, @categoryid);",
                new {name = productToInsert.Name, price = productToInsert.Price, categoryid = productToInsert.CategoryID});
        }

        public void UpdateProduct(Products product)
        {
            _conn.Execute("UPDATE PRODUCTS SET NAME = @name, PRICE = @price WHERE PRODUCTID = @id",
                new { name = product.Name, price = product.Price, id = product.ProductID });
        }
    }
}

