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
    }
}
