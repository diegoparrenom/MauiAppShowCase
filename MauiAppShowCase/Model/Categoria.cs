using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiAppShowCase.Model;
[Table("Categoria")]

public class Categoria
{
    [PrimaryKey, AutoIncrement]
    public int Id_Categoria { get; set; }
    [MaxLength(100)]
    public string Desc_Categoria { get; set; }
}

