using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GameCatalog
{
    public partial class Search : Page
    {
        GameViewModel GameVM;
        Frame Frame;

        public Search(Frame frame, GameViewModel gameVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.GameVM = gameVM;
            DeleteBtn.IsEnabled = false;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            gridTable.DataContext = GameVM.searchInLibrary(searchBox.Text);
            gridTable.Columns[0].Visibility = Visibility.Hidden;

            if (gridTable.SelectedCells.Count == 0)
            {
                DeleteBtn.IsEnabled = false;
            }
            else
            {
                DeleteBtn.IsEnabled = true;
            }
        }
        private void searchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchBox.Text = "";
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Game game = (Game)gridTable.SelectedItem;
            GameVM.DeleteRecordFromLibrary(game.Id);
            MessageBox.Show("The record is deleted successfully", "Deleted");
            gridTable.DataContext = GameVM.searchInLibrary(searchBox.Text);
            gridTable.Columns[0].Visibility = Visibility.Hidden;
        }
        private void gridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridTable.SelectedCells.Count == 0)
            {
                DeleteBtn.IsEnabled = false;
                return;
            }
            DeleteBtn.IsEnabled = true;
        }
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new HomePage(Frame, GameVM));
        }
    }
}
