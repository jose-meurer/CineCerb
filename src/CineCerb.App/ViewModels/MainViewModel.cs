using CommunityToolkit.Mvvm.ComponentModel;

namespace CineCerb.App.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "Welcome to CineCerb!";
}
