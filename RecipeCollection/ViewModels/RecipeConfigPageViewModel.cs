using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    public partial class RecipeConfigPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private string category;
        [ObservableProperty]
        private string ingredients;
        [ObservableProperty]
        private string instructions;

        public RecipeConfigPageViewModel()
        {
        }

        [RelayCommand]
        private async Task TapReturn()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task TapSave()
        {
            
        }
    }
}
