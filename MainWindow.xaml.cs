using System.Windows;
using System.Windows.Input;

namespace Game_Store
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
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {

            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                //iconMaximize.Kind = MaterialDesignThemes.Wpf.PackIconKind.FullscreenExit;
            }
            else
            {
                //iconMaximize.Kind = MaterialDesignThemes.Wpf.PackIconKind.Fullscreen;
                WindowState = WindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }
        private void btnGames_Click(object sender, RoutedEventArgs e)
        {
            DynmicPan.Children.Clear();
            DynmicPan.Children.Add(new GameIndex());
        }

        private void btnDashborad_Click(object sender, RoutedEventArgs e)
        {
            DynmicPan.Children.Clear();


        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            DynmicPan.Children.Clear();
            DynmicPan.Children.Add(new UserIndex());

        }
    }
}
