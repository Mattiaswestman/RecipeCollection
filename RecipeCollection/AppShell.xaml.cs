using RecipeCollection.Views;

namespace RecipeCollection
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CategoryPage), typeof(CategoryPage));
            Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
        }
    }
}
