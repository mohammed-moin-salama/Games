using Game_Store.Helpers;
using Game_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game_Store.Windows
{
    /// <summary>
    /// Interaction logic for AddGame.xaml
    /// </summary>
    public partial class AddGame : Window
    {
        public int x = 0;
        public AddGame()
        {
            InitializeComponent();
            try
            {

                List<string> p = PublisersHepler.GetAllPublisers().Select(a=>a.name).ToList();
                List<string> deve = DevelopersHelper.GetAllDevelopers().Select(a=>a.name).ToList(); 
                List<string> store = StoresHelper.GetAllStores().Select(a=>a.store_id.ToString()).ToList(); 
                //List<int> list = new List<int>();
                //for (int i = 0; i < p.Count; i++)
                //{
                //    list.Add(p[i].publisher_id);

                //}
           //     cmboxDeveloper.ItemsSource = DevelopersHelper.GetAllDevelopers();
             cmboxDeveloper.ItemsSource = deve;
               // cmboxPublisherName.ItemsSource = PublisersHepler.GetAllPublisers();
                cmboxPublisherName.ItemsSource = p;
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
            bool price = int.TryParse(txtprice.Text, out int s);
            bool release_date = DateTime.TryParse(txtrelease_date.Text, out DateTime s1);
            bool review = int.TryParse(txtreview.Text, out int s2);
            bool age = int.TryParse(txtage_limit.Text, out int s3);
            if ( String.IsNullOrEmpty( txtname.Text))
            {
                lblerror.Content = "Pleas enter the name";
                return;
            }

            if (String.IsNullOrEmpty(txtgenre.Text))
            {
                lblerror.Content = "Pleas enter the genre";
                return;
            }

            if (!price)
            {
                lblerror.Content = "Pleas enter the price";
                return;
            }


            if (!review)
            {
                lblerror.Content = "Pleas enter the review";
                return;
            }

            if (!age)
            {
                lblerror.Content = "Pleas enter the age_limit";
                return;
            }

            if (!release_date)
            {
                lblerror.Content = "Pleas enter the lease_date( 24-May-2016)";
                return;
            }

           
           

           

            if (String.IsNullOrEmpty(txtexcept_country.Text))
            {
                lblerror.Content = "Pleas enter the except_country";
                return;
            }

            if (cmboxDeveloper.SelectedIndex==-1)
            {
                lblerror.Content = "Pleas enter the Developer";
                return;
            }
            if (cmboxStoreId.SelectedIndex == -1)
            {
                lblerror.Content = "Pleas enter the StoreId";
                return;
            }

            if (cmboxPublisherName.SelectedIndex == -1)
            {
                lblerror.Content = "Pleas enter the PublisherName";
                return;
            }

            if (String.IsNullOrEmpty(txtDescrpition.Text))
            {
                lblerror.Content = "Pleas enter the Descrpition";
                return;
            }

            MessageBox.Show(PublisersHepler.GetAllPublisers().Where(p => p.name == cmboxPublisherName.SelectedValue.ToString()).Select(o => o.publisher_id).ToList()[0].ToString());

            Game game = new Game()
            {

                name = txtname.Text,
                genre = txtgenre.Text,
                price = Convert.ToInt32(txtprice.Text),
                release_date = Convert.ToDateTime(txtrelease_date.Text),
                review = Convert.ToInt32(txtreview.Text),
                //store_id =7 ,
                store_id =Convert.ToInt32 (cmboxStoreId.SelectedValue),
                //publisher = 6,
               // publisher = ((publishers)cmboxPublisherName.SelectedValue).publisher_id,
                publisher = PublisersHepler.GetAllPublisers().Where(p=>p.name == cmboxPublisherName.SelectedValue.ToString()).Select(o => o.publisher_id).ToList()[0],
                developer = DevelopersHelper.GetAllDevelopers().Where(p=>p.name == cmboxDeveloper.SelectedValue.ToString()).Select(o => o.developer_id).ToList()[0],
                //developer=5,
              // developer = ((Developer)cmboxDeveloper.SelectedValue).developer_id,
                age_limit = Convert.ToInt32(txtage_limit.Text),
                except_country = txtexcept_country.Text,
                description = txtDescrpition.Text,
                isObtainble = checkisObtainble.IsChecked ?? true,

            };


            if (x == 0)
            {
                if (GamesHelper.AddGame(game) > 0)
                {
                    MessageBox.Show("Add Success");
                    this.Close();
                }
                else MessageBox.Show("Not Add Success");
            }
            else
            {
                game.game_id = Convert.ToInt32(txtGameId.Text);

                if (GamesHelper.UpdateGame(game) > 0)
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

