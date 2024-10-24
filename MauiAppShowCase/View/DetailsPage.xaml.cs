namespace MauiAppShowCase;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(UserDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
		base.OnNavigatedTo(args);
    }
}