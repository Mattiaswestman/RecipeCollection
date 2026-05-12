using RecipeCollection.ViewModels;

namespace RecipeCollection.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is MainPageViewModel viewModel)
            {
                await viewModel.UpdateCategoriesAsync();
            }
        }
    }
}
