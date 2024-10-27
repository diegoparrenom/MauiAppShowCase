
using MauiAppShowCase.Services;
using MauiAppShowCase.View;
using static System.Net.Mime.MediaTypeNames;

namespace MauiAppShowCase.ViewModel;

[QueryProperty("Productos", "ProductsItems")]
public partial class ProductsViewModel : BaseViewModel
{

    UserService userService;

    ProductRepository productRepository;
    public ObservableCollection<User> Users { get; } = new();

    public ObservableCollection<Product> Products { get; } = new();

    [ObservableProperty]
    List<Product> productos;

    IConnectivity connectivity;
    IGeolocation geolocation;

    public ProductsViewModel(UserService userService, IConnectivity connectivity, 
        IGeolocation geolocation, ProductRepository productRepository)
    {
        Title = "User Finder";
        this.userService = userService;
        this.connectivity = connectivity;
        this.geolocation = geolocation;
        this.productRepository = productRepository;

        FillInitProducts();
    }


    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    async Task GetClosestUser()
    {
        if(IsBusy || Users.Count  == 0) 
            return;

        try
        {
            

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("!Error",
                $"Unable to get closest user: {ex.Message}", "OK");
        }
    }
    [RelayCommand]
    async Task GoToDetailsAsync(User user)
    {
        if (user is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}",true,
            new Dictionary<string, object>
            {
                {"MachineUser",user }
            });
    }

    //[ICommand]
    [RelayCommand]
    async Task GetUsersAsync()
    {
        if (IsBusy)
            return;

        try
        {
            if(connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Internet Issue!",
                     $"Check your internet and try again!", "OK");
                return;
            }
            IsBusy = true;
            var users = await userService.GetUsers();

            if (Users.Count != 0)
                Users.Clear();

            foreach (var user in users)
                Users.Add(user);
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", 
                $"Unable to get Users: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    async Task GetLoginPage()
    {
        await Shell.Current.GoToAsync($"{nameof(LoginPage)}", true);
    }

    void FillInitProducts()
    {
        List<Product> productos = productRepository.GetAllProducts();

        Shell.Current.GoToAsync("//MainPage", false,
            new Dictionary<string, object>
            {
                {"ProductsItems",productos }
            });
    }

}
