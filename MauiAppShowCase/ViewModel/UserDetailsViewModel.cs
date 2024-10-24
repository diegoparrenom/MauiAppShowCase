namespace MauiAppShowCase.ViewModel;

[QueryProperty("User", "MachineUser")]
public partial class UserDetailsViewModel : BaseViewModel
{

    public UserDetailsViewModel(IMap map)
    {

    }

    [ObservableProperty]
    User user;

}
