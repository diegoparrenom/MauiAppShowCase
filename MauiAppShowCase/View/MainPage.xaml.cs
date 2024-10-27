namespace MauiAppShowCase.View;

public partial class MainPage : ContentPage
{
	public MainPage(ProductsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;

    }
}

