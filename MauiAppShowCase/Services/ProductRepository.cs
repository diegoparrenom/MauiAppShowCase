using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using Microsoft.Maui.Controls;

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
            BuildDefaultBD();

        }
        private void BuildDefaultBD()
        {
            try
            {
                conn.Execute("DROP TABLE IF EXISTS Product");
                conn.Execute("DROP TABLE IF EXISTS Talla");
                conn.Execute("DROP TABLE IF EXISTS Genero");
                conn.Execute("DROP TABLE IF EXISTS Categoria");

                conn.CreateTable<Product>();
            conn.CreateTable<Talla>();
            conn.CreateTable<Genero>();
            conn.CreateTable<Categoria>();

            conn.Execute("INSERT INTO Talla (Desc_Talla) VALUES('XL'),('L'),('M'),('S')");

            conn.Execute("INSERT INTO Genero (Desc_Genero) VALUES('Masculino'),('Femenino')");

            conn.Execute("INSERT INTO Categoria (Desc_Categoria) VALUES('Vestidos'),('Camisas'),('Pantalones')");

            conn.Insert(new Product(1, 1, 1, "Pantalon Sport", "pantalon para pasear", 
                float.Parse("20.0"), float.Parse("20.0"), DateTime.Parse("2024-10-2"),
                "https://img.freepik.com/fotos-premium/hacer-jogging_1056055-915.jpg?w=740"));

            conn.Insert(new Product(1, 1, 2, "Camisa Larga Blanca", "Camisa Blanca elegante para de algodon", 
                float.Parse("23.0"),float.Parse("74.0"), DateTime.Parse("2024-6-1"),
                "https://img.freepik.com/fotos-premium/camisa-blanca-maniqui-maniqui_662214-730730.jpg?w=740"));

            conn.Insert(new Product(1, 1, 2, "Camisa Corta", "Camisa Blanca elegante para de algodon",
                float.Parse("25.0"), float.Parse("75.0"), DateTime.Parse("2024-6-1"),
                "https://img.freepik.com/psd-premium/camiseta-gris-formato-psd-sobre-fondo-blanco_889056-102706.jpg?w=740"));

            conn.Insert(new Product(2, 2, 2, "Blusa Celeste", "Blusa de primavera edicion limitada",
                float.Parse("55.0"), float.Parse("175.0"), DateTime.Parse("2024-10-1"),
                "https://img.freepik.com/foto-gratis/mujer-camisa-pantalon-azul-espacio-diseno-moda-casual_53876-104303.jpg?t=st=1730390322~exp=1730393922~hmac=765d7ed164f8694578eec57bc09d04ad6ab9ba306652273fcab7e84d3b139aa3&w=360"));

            conn.Insert(new Product(2, 2, 1, "Vestido Verano", "Vestido ligero de caida natural",
                float.Parse("40.0"), float.Parse("110.0"), DateTime.Parse("2024-10-1"),
                "https://img.freepik.com/foto-gratis/mujer-llevando-sundress_23-2150388738.jpg?ga=GA1.1.1812143323.1730241464&semt=ais_hybrid"));

            conn.Insert(new Product(2, 2, 1, "Vestido Verde", "Vestido Cocktail de Temporada",
                float.Parse("70.0"), float.Parse("150.0"), DateTime.Parse("2024-5-1"),
                "https://media.istockphoto.com/id/492462644/es/foto/vestido-verde-con-cinta.jpg?s=1024x1024&w=is&k=20&c=ulMQflxiLEcXHT_tRtgRXmAnZE52gFgevbqCFtVfNWM="));

            }

            catch (Exception ex)
            {

                StatusMessage = string.Format("Failed BD:  {0} ",  ex.Message);
            }
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

                Product product = new() {Nombre = name,Descripcion = description};
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

        public List<Product> GetNewProducts()
        {
            try
            {
                Init();
                DateTime MinimumDate = new(2024, 8, 1);
                DateTime MaximumDate = new(2024, 12, 1);

                return conn.Table<Product>().Where(i => i.FechaIngreso >= MinimumDate && i.FechaIngreso <= MaximumDate).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<Product>();
        }

        public List<Product> GetWomanProducts()
        {
            try
            {
                Init();

                int id = conn.Table<Genero>().Where(i => i.Desc_Genero == "Femenino").First().Id_Genero;

                return conn.Table<Product>().Where(i => i.Id_Genero == id).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
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
            //var list = conn.Table<Product>().Where(x => x.Nombre != "DefaultProduct").ToList();
            var list = conn.Table<Product>().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                conn.Delete(list[i]);
            }
        }
    }
}
