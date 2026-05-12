using RecipeCollection.ViewModels;

namespace RecipeCollection.Views
{
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage(CategoryPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is CategoryPageViewModel viewModel)
            {
                await viewModel.UpdateRecipesAsync();
            }
        }
    }
}
