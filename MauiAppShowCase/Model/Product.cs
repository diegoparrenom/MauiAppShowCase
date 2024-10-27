using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace MauiAppShowCase.Model;
[Table("product")]

public class Product
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(150), Unique]
    public string Name { get; set; }

    [MaxLength(150)]
    public string Description { get; set; }
}

