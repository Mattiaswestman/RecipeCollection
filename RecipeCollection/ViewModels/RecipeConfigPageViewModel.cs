using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using RecipeCollection.Models;
using RecipeCollection.Services;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    public partial class RecipeConfigPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private string categoryTitle;
        [ObservableProperty]
        private string ingredients;
        [ObservableProperty]
        private string instructions;

        private RecipeCollectionDbContext database;

        public RecipeConfigPageViewModel(RecipeCollectionDbContext database)
        {
            this.database = database;
        }

        [RelayCommand]
        private async Task TapReturn()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task TapSave()
        {
            await AddRecipeAsync();
        }

        private async Task AddRecipeAsync()
        {
            if (await DoesRecipeExist(Title))
            {
                return;
            }

            var newRecipe = new Recipe()
            {
                Id = Random.Shared.Next(10000, 99999),
                Title = Title,
                Ingredients = Ingredients,
                Instructions = Instructions
            };

            var category = await database.Categories.FirstOrDefaultAsync(c => c.Title == CategoryTitle);
            if (category == null)
            {
                category = await AddCategoryAsync(CategoryTitle);
            }

            newRecipe.CategoryId = category.Id;
            newRecipe.CategoryTitle = category.Title;

            database.Recipes.Add(newRecipe);
            await database.SaveChangesAsync();
        }

        private async Task<Category> AddCategoryAsync(string category)
        {
            var newCategory = new Category()
            {
                Id = Random.Shared.Next(10000, 99999),
                Title = category
            };

            database.Categories.Add(newCategory);
            await database.SaveChangesAsync();
            return newCategory;
        }

        private async Task<bool> DoesRecipeExist(string title)
        {
            return await database.Recipes.AnyAsync(c => c.Title == title);
        }
    }
}
