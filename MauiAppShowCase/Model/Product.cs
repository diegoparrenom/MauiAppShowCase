using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace MauiAppShowCase.Model;
[Table("Product")]

public class Product
{
    [PrimaryKey, AutoIncrement]
    public int Id_Producto {  get; set; }
    public int Id_Talla {  get; set; }
    public int Id_Genero {  get; set; }
    public int Id_Categoria { get; set; }
    [MaxLength(150)]
    public string Nombre { get; set; }
    [MaxLength(150)]
    public string Descripcion { get; set; }
    [MaxLength(150)]
    public string Imagen {  get; set; }
    public float PrecioAlquiler {  get; set; }
    public float PrecioVenta {  get; set; }
    public DateTime FechaIngreso { get; set; }

    public Product()
    {

    }
    public Product(int id_Talla, int id_Genero, int id_Categoria,
        string nombre, string descripcion, float precioAlquiler, 
        float precioVenta,DateTime fechaIngreso, string imagen)
    {
        this.Id_Talla = id_Talla;
        this.Id_Genero = id_Genero;
        this.Id_Categoria = id_Categoria;   
        this.Nombre = nombre;
        this.Descripcion = descripcion; 
        this.Imagen = imagen;   
        this.PrecioAlquiler = precioAlquiler;
        this.PrecioVenta = precioVenta;
        this.FechaIngreso = fechaIngreso;   
    }


}

