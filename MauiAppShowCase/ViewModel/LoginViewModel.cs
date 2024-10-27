using MauiAppShowCase.Services;
using MauiAppShowCase.View;

namespace MauiAppShowCase.ViewModel;

public partial class LoginViewModel : BaseViewModel
{

    [ObservableProperty]
    public string login_name = "Diego";
    [ObservableProperty]
    public string login_pass = "123";

    ProductRepository productRepository;

    public LoginViewModel(ProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    [RelayCommand]
    async Task SubmitEntries()
    {

        if(productRepository.LoginValidation(Login_name, Login_pass)) { 

            await Shell.Current.GoToAsync($"{nameof(ProductManagePage)}", true);
        }
        else
            await Shell.Current.DisplayAlert("Internet Issue!", "Login Failed!!", "OK");

    }
}