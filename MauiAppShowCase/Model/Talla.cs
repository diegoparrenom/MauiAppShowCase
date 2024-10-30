using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace MauiAppShowCase.Model;
[Table("Talla")]

public class Talla
{
    [PrimaryKey, AutoIncrement]
    public int Id_Talla { get; set; }
    [MaxLength(100)] 
    public string Desc_Talla { get; set; }

}

