using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppShowCase.Services
{
    public class ProductRepository
    {
        string _dbPath;
        public string StatusMessage { get; set; }

        private SQLiteConnection conn;

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Product>();

            //Shell.Current.DisplayAlert("Mssg:", "Iniatialized !!", "OK");

            //add default product
            AddNewProduct("DefaultProduct", "Default Description");

            //var list = conn.Table<Product>().Where(x => x.Name != "DefaultProduct").ToList();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    conn.Delete(list[i]);
            //}

        }
        public ProductRepository(string dbPath)
        {
            _dbPath = dbPath;

        }
        public void AddNewProduct(string name,string description)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid Name required");

                Product product = new() {Name = name,Description = description};
                result = conn.Insert(product);

                StatusMessage = string.Format("{0} records added (Name: {1}", result, name);
            }
            catch(Exception ex) {
            
                StatusMessage = string.Format("Failed to add {0} .Error: {1}", name, ex.Message);
            }
        }
        public List<Product> GetAllProducts()
        {
            try
            {
                Init();
                return conn.Table<Product>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}",ex.Message);
            }
            return new List<Product>();
        }

        public bool LoginValidation(string name,string pass)
        {
            if (name == "Diego" && pass == "123")
                return true;
            else
                return false;
        }
        public void DeleteProducts()
        {
            var list = conn.Table<Product>().Where(x => x.Name != "DefaultProduct").ToList();
            for (int i = 0; i < list.Count; i++)
            {
                conn.Delete(list[i]);
            }
        }
    }
}
