using MauiAppShowCase.Services;
using MauiAppShowCase.View;

namespace MauiAppShowCase.ViewModel;

public partial class ProductManageViewModel : BaseViewModel
{

    [ObservableProperty]
    public Product product = new Product();

    ProductRepository productRepository;

    public ProductManageViewModel(ProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    [RelayCommand]
    async Task AddProduct()
    {
        productRepository.AddNewProduct(Product.Name, Product.Description);


        //productRepository.GetAllProducts();
        //await Shell.Current.Navigation.PopAsync();

        await Shell.Current.GoToAsync("//MainPage", false);
        
    }
}