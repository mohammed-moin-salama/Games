using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game_Store
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();

        }

        private void TextBox_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox box = (TextBox)sender;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Added successfully .....", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
