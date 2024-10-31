
using MauiAppShowCase.Services;
using MauiAppShowCase.View;
using static System.Net.Mime.MediaTypeNames;

namespace MauiAppShowCase.ViewModel;

[QueryProperty("Productos", "ProductsItems")]
[QueryProperty("NuevosProductos", "NewProductsItems")]
[QueryProperty("ProductosMujer", "WomanProducts")]

public partial class ProductsViewModel : BaseViewModel
{

    ProductRepository productRepository;

    [ObservableProperty]
    List<Product> productos;

    [ObservableProperty]
    List<Product> nuevosProductos;

    [ObservableProperty]
    List<Product> productosMujer;
    

    IConnectivity connectivity;
    IGeolocation geolocation;

    public ProductsViewModel(IConnectivity connectivity, 
        IGeolocation geolocation, ProductRepository productRepository)
    {
        Title = "Clothes ShowCase";
        this.connectivity = connectivity;
        this.geolocation = geolocation;
        this.productRepository = productRepository;

        FillInitProducts();
    }


    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    async Task GetLoginPage()
    {
        await Shell.Current.GoToAsync($"{nameof(LoginPage)}", true);
    }

    void FillInitProducts()
    {
        List<Product> productos;
        List<Product> nuevosProductos;
        List<Product> productosMujer;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            //Si no hay conectividad
            productos = productRepository.GetAllProducts();
            nuevosProductos = productRepository.GetNewProducts();
            productosMujer = productRepository.GetWomanProducts();
        }
        else { 
            //si hay llamar a api
            productos = productRepository.GetAllProducts();
            nuevosProductos = productRepository.GetNewProducts();
            productosMujer = productRepository.GetWomanProducts();
        }

        Shell.Current.GoToAsync("//MainPage", false,
            new Dictionary<string, object>
            {
                {"ProductsItems",productos },
                {"NewProductsItems",nuevosProductos },
                {"WomanProducts",productosMujer }

            });
    }

}
