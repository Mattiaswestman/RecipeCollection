using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeCollection.Views;
using System.Collections.ObjectModel;

namespace RecipeCollection.ViewModels
{
    [QueryProperty("CategoryTitle", "CategoryTitle")]
    public partial class CategoryPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> recipes;

        [ObservableProperty]
        private string categoryTitle;

        public CategoryPageViewModel()
        {
            Recipes = new ObservableCollection<string>();
            Recipes.Add("Ost- & Skinkpaj");
            Recipes.Add("Pannkakor");
            Recipes.Add("Hamburgare");
        }

        [RelayCommand]
        private async Task TapRecipe(string recipeTitle)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipePage)}?RecipeTitle={Uri.EscapeDataString(recipeTitle)}");
        }

        [RelayCommand]
        private async Task TapReturn()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
