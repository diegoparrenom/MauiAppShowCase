using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;
using System.Xml.Linq;

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

            //Shell.Current.DisplayAlert("Mssg:", "Iniatialized !!", "OK");

            //add default product

            //var list = conn.Table<Product>().Where(x => x.Name != "DefaultProduct").ToList();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    conn.Delete(list[i]);
            //}

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

            conn.Execute("INSERT INTO Talla (Desc_Talla) VALUES('XL');" +
                         "INSERT INTO Talla (Desc_Talla) VALUES('L');" +
                         "INSERT INTO Talla (Desc_Talla) VALUES('M');" +
                         "INSERT INTO Talla (Desc_Talla) VALUES('S')");

            conn.Execute("INSERT INTO Genero (Desc_Genero) VALUES('Masculino');" +
                         "INSERT INTO Genero (Desc_Genero) VALUES('Femenino')");

            conn.Execute("INSERT INTO Categoria (Desc_Categoria) VALUES('Vestidos');" +
                         "INSERT INTO Categoria (Desc_Categoria) VALUES('Camisas');" +
                         "INSERT INTO Categoria (Desc_Categoria) VALUES('Pantalones')");

            conn.Execute(
                "INSERT INTO Product (Id_Talla,Id_Genero,Id_Categoria,Nombre,Descripcion,Imagen,PrecioAlquiler,PrecioVenta) " +
                "VALUES(1,1,3,'Pantalon Sport','pantalon para pasear'," +
                "'https://img.freepik.com/fotos-premium/hacer-jogging_1056055-915.jpg?w=740',20.0,60.0);");
            conn.Execute(
                "INSERT INTO Product (Id_Talla,Id_Genero,Id_Categoria,Nombre,Descripcion,Imagen,PrecioAlquiler,PrecioVenta) " +
                "VALUES(1,2,1,'Vestido Verano','Vestido ligero de caida natural'," +
                "'https://img.freepik.com/foto-gratis/mujer-llevando-sundress_23-2150388738.jpg?ga=GA1.1.1812143323.1730241464&semt=ais_hybrid',40.0,110.0);");
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
