using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeCollection.Views;
using System.Collections.ObjectModel;

namespace RecipeCollection.ViewModels
{
    public partial class CategoryPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> recipes;

        public CategoryPageViewModel()
        {
            Recipes = new ObservableCollection<string>();
            Recipes.Add("Ost- & Skinkpaj");
            Recipes.Add("Pannkakor");
            Recipes.Add("Hamburgare");
        }

        [RelayCommand]
        private async Task TapRecipe()
        {
            await Shell.Current.GoToAsync(nameof(RecipePage));
        }

        [RelayCommand]
        private async Task TapReturn()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
