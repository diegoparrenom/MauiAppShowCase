using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiAppShowCase.Model;
[Table("Genero")]

public class Genero
{
    [PrimaryKey, AutoIncrement]
    public int Id_Genero { get; set; }
    [MaxLength(100)]
    public string Desc_Genero { get; set; }
}

