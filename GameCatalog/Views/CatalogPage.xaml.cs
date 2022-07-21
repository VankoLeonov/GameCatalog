using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GameCatalog
{
    public partial class CatalogPage : Page
    {
        GameViewModel GameVM;
        Frame Frame;

        public CatalogPage(Frame frame, GameViewModel gameVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.GameVM = gameVM;
        }
        private void Title_TBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Title_TBox.Text = "";
        }
        private void Developer_TBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Developer_TBox.Text = "";
        }
        private void Genre_TBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Genre_TBox.Text = "";
        }
        private void ReleaseYear_TBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ReleaseYear_TBox.Text = "";
        }
        private void Rating_TBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Rating_TBox.Text = "";
        }
        private void Price_TBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Price_TBox.Text = "";
        }
        private void showBox_GotFocus(object sender, RoutedEventArgs e)
        {
            showBox.Text = "";
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game();
            game.Title = Title_TBox.Text;
            game.Developer = Developer_TBox.Text;
            game.Genre = Genre_TBox.Text;
            game.YearOfRelease = int.Parse(ReleaseYear_TBox.Text);
            game.Rating = int.Parse(Rating_TBox.Text);
            game.Price = int.Parse(Price_TBox.Text);
            GameVM.AddRecordToLibrary(game);
            MessageBox.Show("The record is added", "Add");
        }
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            WarningShowLabel.Visibility = Visibility.Hidden;
            showBox.Visibility = Visibility.Hidden;
            gridShowTable.DataContext = GameVM.showInLibrary(showBox.Text);
            gridShowTable.Columns[0].Visibility = Visibility.Hidden;
            if (gridShowTable.SelectedCells.Count == 0)
            {
                DeleteBtn.IsEnabled = false;
            }
            else
            {
                DeleteBtn.IsEnabled = true;
            }
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Game game = (Game)gridShowTable.SelectedItem;
            GameVM.DeleteRecordFromLibrary(game.Id);
            gridShowTable.DataContext = GameVM.searchInLibrary(showBox.Text);
            gridShowTable.Columns[0].Visibility = Visibility.Hidden;
            MessageBox.Show("The record is successfully deleted", "Delete");
        }
        private void gridShowTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridShowTable.SelectedCells.Count == 0)
            {
                DeleteBtn.IsEnabled = false;
                return;
            }
            DeleteBtn.IsEnabled = true;
        }
        private void backBtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new HomePage(Frame, GameVM));
        }
    }
}
