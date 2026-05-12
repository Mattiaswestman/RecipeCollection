using RecipeCollection.ViewModels;

namespace RecipeCollection.Views
{
    public partial class RecipePage : ContentPage
    {
        public RecipePage(RecipePageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is RecipePageViewModel viewModel)
            {
                await viewModel.UpdateRecipeAsync();
            }
        }
    }
}
