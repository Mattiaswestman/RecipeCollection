using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel() 
        {
        }

        [RelayCommand]
        private async Task TapCategory(string text)
        {
            await Shell.Current.GoToAsync(nameof(CategoryPage));
        }
    }
}
