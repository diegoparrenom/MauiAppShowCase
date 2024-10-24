using System.Net.Http.Json;

namespace MauiAppShowCase.Services;

public class UserService
{
    HttpClient httpClient;

    public UserService()
    {
        httpClient = new HttpClient();
    }

    List<User> userList = new ();

    Info userInfo = new();

    public async Task<List<User>> GetUsers()
    {
        if (userList?.Count > 0)
            return userList;

        var url = "https://reqres.in/api/users?page=2";

        var response = await httpClient.GetAsync(url);

        if(response.IsSuccessStatusCode)
        {
            userInfo = await response.Content.ReadFromJsonAsync<Info>();
            userList = userInfo.data.OfType<User>().ToList(); ;
        }

        return userList;
    }
}
