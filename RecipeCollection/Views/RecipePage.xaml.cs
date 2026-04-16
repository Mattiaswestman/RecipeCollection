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
    }
}
