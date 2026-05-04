using RecipeCollection.ViewModels;

namespace RecipeCollection.Views
{
    public partial class RecipeConfigPage : ContentPage
    {
        public RecipeConfigPage(RecipeConfigPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
