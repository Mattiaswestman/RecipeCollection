using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> categories;
        [ObservableProperty]
        private string categoryToAdd;

        public MainPageViewModel() 
        {
            Categories = new ObservableCollection<string>();
            Categories.Add("Middag");
            Categories.Add("Desert");
        }

        [RelayCommand]
        private async Task TapCategory(string categoryTitle)
        {
            await Shell.Current.GoToAsync($"{nameof(CategoryPage)}?CategoryTitle={Uri.EscapeDataString(categoryTitle)}");
        }

        [RelayCommand]
        private void AddNewCategory()
        {
            Categories.Add(CategoryToAdd);
        }
    }
}
