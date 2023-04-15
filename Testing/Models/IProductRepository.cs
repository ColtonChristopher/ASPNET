using System;
using System.Collections.Generic;

namespace Testing.Models
{
	public interface IProductRepository
	{

		public IEnumerable<Products> GetAllProducts();
		 public Products GetProduct(int id);
		public void UpdateProduct(Products product);
		public void InsertProduct(Products productToInsert);
		public IEnumerable<Category> GetCategories();
		public Products AssignCategory();
		public void DeleteProduct(Products product);
	}
}

