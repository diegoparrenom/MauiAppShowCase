using System.Text.Json.Serialization;

namespace MauiAppShowCase.Model;

public class User
{
    public int id { get; set; }
    public string email {  get; set; }
    public string first_name { get; set; }
    public string last_name {  get; set; }
    public string FullName => $"{first_name} {last_name}";
    public string avatar { get; set; }

}
