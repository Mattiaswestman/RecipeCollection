using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using RecipeCollection.Services;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> categories;

        private RecipeCollectionDbContext database;

        public MainPageViewModel(RecipeCollectionDbContext database) 
        {
            this.database = database;
            Categories = new ObservableCollection<string>();
            UpdateCategoriesAsync();
        }

        [RelayCommand]
        private async Task OpenRecipeConfigPage()
        {
            await Shell.Current.GoToAsync(nameof(RecipeConfigPage));
        }

        [RelayCommand]
        private async Task TapCategory(string categoryTitle)
        {
            await Shell.Current.GoToAsync($"{nameof(CategoryPage)}?CategoryTitle={Uri.EscapeDataString(categoryTitle)}");
        }

        public async Task UpdateCategoriesAsync()
        {
            Categories.Clear();
            var categories = await database.Categories
                .OrderBy(c => c.Title.Substring(0, 1))
                .ToListAsync();

            foreach (var category in categories)
            {
                Categories.Add(category.Title);
            }
        }
    }
}
