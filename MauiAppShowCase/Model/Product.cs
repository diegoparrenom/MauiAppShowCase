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



}

