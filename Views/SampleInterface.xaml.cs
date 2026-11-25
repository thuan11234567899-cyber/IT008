using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoAn_IT008.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
		private void Nav_Click(object sender, RoutedEventArgs e)
		{
			if (sender is Button btn && btn.Tag is string screen)
			{
				ShowScreen(screen);
			}
		}

		private void ShowScreen(string screen)
		{
			var screens = new Dictionary<string, Grid>
			{
				["Home"] = ScreenHome,
				["MyInfo"] = ScreenMyInfo,
				["Tickets"] = ScreenTickets,
				["AdminUsers"] = ScreenAdminUsers,
				["AdminEvents"] = ScreenAdminEvents
			};

			foreach (var item in screens.Values)
			{
				item.Visibility = Visibility.Collapsed;
			}

			if (screens.TryGetValue(screen, out var target))
			{
				target.Visibility = Visibility.Visible;
			}

			var activeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00B982"));
			BtnNavHome.Background = screen == "Home" ? activeBrush : Brushes.Transparent;
			BtnNavMyInfo.Background = screen == "MyInfo" ? activeBrush : Brushes.Transparent;
			BtnNavTickets.Background = screen == "Tickets" ? activeBrush : Brushes.Transparent;
			BtnNavAdminUsers.Background = screen == "AdminUsers" ? activeBrush : Brushes.Transparent;
			BtnNavAdminEvents.Background = screen == "AdminEvents" ? activeBrush : Brushes.Transparent;
		}
	}
}