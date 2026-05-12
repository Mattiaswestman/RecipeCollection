using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using RecipeCollection.Services;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    [QueryProperty("RecipeTitle", "RecipeTitle")]
    public partial class RecipePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string recipeTitle;
        [ObservableProperty]
        private string ingredientsText;
        [ObservableProperty]
        private string instructionsText;

        private RecipeCollectionDbContext database;

        public RecipePageViewModel(RecipeCollectionDbContext database)
        {
            this.database = database;
        }

        [RelayCommand]
        private async Task TapReturn()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async Task UpdateRecipeAsync()
        {
            var recipe = await database.Recipes
                .Where(r => r.Title == RecipeTitle)
                .Select(r => new { r.Ingredients, r.Instructions })
                .FirstOrDefaultAsync();

            if (recipe != null)
            {
                IngredientsText = recipe.Ingredients;
                InstructionsText = recipe.Instructions;
            }
        }
    }
}
