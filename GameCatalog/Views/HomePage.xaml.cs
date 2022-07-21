using System.Windows;
using System.Windows.Controls;

namespace GameCatalog
{
    public partial class HomePage : Page
    {
        private Frame Frame;
        GameViewModel GameVM;

        public HomePage(Frame frame, GameViewModel gameVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.GameVM = gameVM;
        }
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new Search(this.Frame, this.GameVM));
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new CatalogPage(this.Frame, this.GameVM));

        }
    }
}
