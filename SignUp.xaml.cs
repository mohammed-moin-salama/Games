using Game_Store.Helpers;
using Game_Store.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace Game_Store
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            Login login = new Login();
            login.Show();
            Close();
        }

        private void btnSignUP_Click(object sender, RoutedEventArgs e)
        {
            {


                if (txtName.Text.Length == 0)
                {
                    lblNameErorr.Height = Double.NaN;
                    lblNameErorr.Content = "Password is requird";

                }
                else
                {
                    lblNameErorr.Height = 0;
                    lblNameErorr.Content = "";
                }


                if (txtEmail.Text.Length == 0)
                {
                    lblEmailErorr.Height = Double.NaN;
                    lblEmailErorr.Content = "Password is requird";

                }
                else
                {
                    lblEmailErorr.Height = 0;
                    lblEmailErorr.Content = "";
                }

                if (txtPassWord.Password.Length == 0)
                {
                    lblPasswordeErorr.Height = Double.NaN;
                    lblPasswordeErorr.Content = "Password is requird";

                }
                else
                {
                    lblPasswordeErorr.Height = 0;
                    lblPasswordeErorr.Content = "";
                }
                if (txtUserName.Text.Length == 0)

                {
                    lblUserNameErorr.Height = Double.NaN;
                    lblUserNameErorr.Content = "UserName is requird";

                }
                else
                {
                    lblUserNameErorr.Height = 0;
                    lblUserNameErorr.Content = "";
                }

                if (txtPassWord.Password.Length == 0 || txtUserName.Text.Length == 0 || txtEmail.Text.Length == 0 || txtName.Text.Length == 0)
                { return; }
                else
                {
                    if (UsersHelper.AddUsers(new users()
                    {
                        email = txtEmail.Text,
                        password = Convert.ToInt32(txtPassWord.Password),
                        username = txtUserName.Text,
                        name = txtName.Text,
                        age = 18,
                        gender = "Male",
                        store_id = 1,
                        surname = " ",
                    }) > 0)
                    {
                        MessageBox.Show("Added successfully .....", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Login login = new Login();
                        login.ShowDialog();

                    
                    }
                    else
                    {
                        MessageBox.Show("Not Added successfully .....", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    }
                    ;
                }


            }
        }
    }
}
