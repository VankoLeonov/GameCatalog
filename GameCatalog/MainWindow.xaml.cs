using System.Windows;
using System.Windows.Controls;

namespace GameCatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GameViewModel GameVM { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            GameVM = new GameViewModel();
            Frame.Navigate(new HomePage(Frame, GameVM));
        }
    }
}
