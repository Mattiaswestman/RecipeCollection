using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    public partial class RecipeConfigPageViewModel : ObservableObject
    {
        public RecipeConfigPageViewModel()
        {
        }

        [RelayCommand]
        private async Task TapReturn()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
