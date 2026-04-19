using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    [QueryProperty("RecipeTitle", "RecipeTitle")]
    public partial class RecipePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string recipeTitle;

        public RecipePageViewModel()
        {
        }

        [RelayCommand]
        private async Task TapReturn()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
