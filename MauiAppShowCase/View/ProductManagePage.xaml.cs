namespace MauiAppShowCase.View;

public partial class ProductManagePage : ContentPage
{
	public ProductManagePage(ProductManageViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}