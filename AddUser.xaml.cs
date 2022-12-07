using Game_Store.Helpers;
using Game_Store.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Game_Store
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
  
    public partial class AddUser : Window
    {
        public int x = 0;
        public AddUser()
        {
            InitializeComponent();
            try
            {

           
                List<string> store = StoresHelper.GetAllStores().Select(a => a.store_id.ToString()).ToList();
                //List<int> list = new List<int>();
                //for (int i = 0; i < p.Count; i++)
                //{
                //    list.Add(p[i].publisher_id);

                //}
                //     cmboxDeveloper.ItemsSource = DevelopersHelper.GetAllDevelopers();
                // cmboxPublisherName.ItemsSource = PublisersHepler.GetAllPublisers();
                // cmboxStoreId.ItemsSource = StoresHelper.GetAllStores();
                cmboxStoreId.ItemsSource = store;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < grid.Children.Count; i++)
            {
                if (grid.Children[i] is StackPanel)
                {
                    for (int i2 = 0; i2 < ((StackPanel)grid.Children[i]).Children.Count; i2++)
                    {
                        if (((StackPanel)grid.Children[i]).Children[i2] is TextBox)
                        {

                            ((TextBox)(((StackPanel)grid.Children[i]).Children[i2])).Text = string.Empty;

                        }
                        else if (((StackPanel)grid.Children[i]).Children[i2] is Label)
                        {
                            ((Label)(((StackPanel)grid.Children[i]).Children[i2])).Content = string.Empty;

                        }
                    }
                }
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)

        {
            bool password = int.TryParse(txtpassword.Text, out int s);
            bool age = int.TryParse(txtAge.Text, out int s3);
            if (String.IsNullOrEmpty(txtname.Text))
            {
                lblerror.Content = "Pleas enter the name";
                return;
            }
            if (String.IsNullOrEmpty(txtSurname.Text))
            {
                lblerror.Content = "Pleas enter the Surname";
                return;
            }

            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                lblerror.Content = "Pleas enter the Username";
                return;
            }


            if (!password)
            {
                lblerror.Content = "Pleas enter the password";
                return;
            }


            if (!age)
            {
                lblerror.Content = "Pleas enter the age";
                return;
            }
          






            if (String.IsNullOrEmpty(txtemail .Text))
            {
                lblerror.Content = "Pleas enter the email";
                return;
            }

           
            if (cmboxStoreId.SelectedIndex == -1)
            {
                lblerror.Content = "Pleas enter the StoreId";
                return;
            }

           


            users game = new users()
            {

                name = txtname.Text.ToString(),
                email = txtemail.Text. ToString(),
                gender=(rdmale.IsChecked??false)?"Male":"female",
                age = s3,
                //store_id =7 ,
                store_id = Convert.ToInt32(cmboxStoreId.SelectedValue),
                //publisher = 6,
                // publisher = ((publishers)cmboxPublisherName.SelectedValue).publisher_id,
                //developer=5,
                // developer = ((Developer)cmboxDeveloper.SelectedValue).developer_id,
                password = Convert.ToInt32(txtpassword.Text),
                username = txtUsername.Text,
                surname = txtSurname.Text,
               
            

            };


            if (x == 0)
            {
                if (UsersHelper.AddUsers(game) > 0)
                {
                    MessageBox.Show("Add Success");
                    this.Close();
                }
                else MessageBox.Show("Not Add Success");
            }
            else
            {
                game.user_id = Convert.ToInt32(txtUserId.Text);

                if (UsersHelper.UpdateUsers(game) > 0)
                {
                    MessageBox.Show("Updated Success");
                    this.Close();

                }
                else MessageBox.Show("Update Not Success", "Update Not Success", MessageBoxButton.OK, MessageBoxImage.Error);
            }



            //MainWindow window = new MainWindow();
            //window.Show();
            //this.Close();
            //            this.DialogResult = true;
            //this.Visibility= Visibility.Hidden;




            //for (int i = 0; i < grid.Children.Count; i++)
            //{
            //    if (grid.Children[i] is StackPanel)
            //    {
            //        for (int i2 = 0; i2 < ((StackPanel)grid.Children[i]).Children.Count; i2++)
            //        {
            //            if (((StackPanel)grid.Children[i]).Children[i2] is Label)
            //            {
            //                ((Label)(((StackPanel)grid.Children[i]).Children[i2])).Content = "This Field is Required";
            //            }
            //        }
            //    }
            //}



            //this.Height = 700;


        }

    }
}

