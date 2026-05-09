using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using RecipeCollection.Services;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    [QueryProperty("CategoryTitle", "CategoryTitle")]
    public partial class CategoryPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> recipes;
        [ObservableProperty]
        private string categoryTitle;

        private RecipeCollectionDbContext database;

        public CategoryPageViewModel(RecipeCollectionDbContext database)
        {
            this.database = database;
            Recipes = new ObservableCollection<string>();
            UpdateRecipesAsync();
        }

        [RelayCommand]
        private async Task OpenRecipeConfigPage()
        {
            await Shell.Current.GoToAsync(nameof(RecipeConfigPage));
        }

        [RelayCommand]
        private async Task TapReturn()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task TapRecipe(string recipeTitle)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipePage)}?RecipeTitle={Uri.EscapeDataString(recipeTitle)}");
        }

        private async Task UpdateRecipesAsync()
        {
            Recipes.Clear();
            var recipes = await database.Recipes
                .OrderBy(r => r.Title.Substring(0, 1))
                .ToListAsync();

            foreach (var recipe in recipes)
            {
                Recipes.Add(recipe.Title);
            }
        }
    }
}
