namespace MauiAppShowCase.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    public BaseViewModel()
    {
    }
    [ObservableProperty]
    //[AlsoNotifyChangeFor(nameof(IsNotBusy))]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title;

    public bool IsNotBusy => !IsBusy;

}
