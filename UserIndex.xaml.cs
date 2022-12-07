using Game_Store.Helpers;
using Game_Store.Models;
using Game_Store.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game_Store
{
    /// <summary>
    /// Interaction logic for UserIndex.xaml
    /// </summary>
  
    public partial class UserIndex : UserControl
    {
        public UserIndex()
        {
            InitializeComponent();

            try
            {
                List<users> games = UsersHelper.GetAllUsers();
                dgUsers.ItemsSource = games;
                txtblockNumberOfGames.Text = $"The Number of Users is {games.Count().ToString()}";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr.....", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void txtSeach_KeyUp(object sender, KeyEventArgs e)
        {
            List<users> users = UsersHelper.GetAllUsers();
            List<users> Sreachedusers = UsersHelper.GetAllUsers().Where(
               user => user.user_id.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               user.name.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               user.store_id.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               user.password.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               user.surname.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               user.age.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               user.email.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               user.gender.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               user.username.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) 
               
            ).ToList();

            if (txtSeach.Text.Length > 0)
            {

                dgUsers.ItemsSource = Sreachedusers;
                txtblockNumberOfGames.Text = $"The Number of games is {Sreachedusers.Count().ToString()}";
            }
            else
            {
                dgUsers.ItemsSource = users;
                txtblockNumberOfGames.Text = $"The Number of games is {users.Count().ToString()}";

            }

        }


        private void btnAddGame_Click(object sender, RoutedEventArgs e)
        {
            AddUser addGame = new AddUser();
            addGame.x = 0;
            addGame.ShowDialog();
            dgUsers.ItemsSource = UsersHelper.GetAllUsers();
            txtblockNumberOfGames.Text = $"The Number of games is {UsersHelper.GetAllUsers().ToString()}";


        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                users selectedGame = (users)dgUsers.SelectedItem;

                var addGame = new AddUser();
                addGame.x = 1;

                stores store = StoresHelper.GetAllStores().Where(o => o.store_id == Convert.ToInt32(selectedGame.store_id)).ToList()[0];

                int storeindex = StoresHelper.GetAllStores().Select(asas => asas.store_id.ToString()).ToList().IndexOf(store.store_id.ToString());

                //MessageBox.Show(addGame.x.ToString());
                //MessageBox.Show($"you clicked {dept.dname}");
                addGame.txtname.Text = selectedGame.name;
                addGame.txtUserId.Text = selectedGame.user_id.ToString();
                addGame.txtAge.Text = Convert.ToInt32(selectedGame.age).ToString();

                addGame.txtpassword.Text = Convert.ToInt32(selectedGame.password).ToString();
               addGame.cmboxStoreId.SelectedIndex = storeindex;
 
                addGame.txtSurname.Text = selectedGame.surname.ToString();
                addGame.txtemail.Text = selectedGame.email.ToString();
                addGame.txtUsername.Text = selectedGame.username.ToString();
                if (selectedGame.gender=="Male")
                {
                    addGame.rdmale.IsChecked = true;
                }
                else 
                {
                    addGame.rdfemale.IsChecked = true;

                }
                addGame.ShowDialog();
                List<users> games = UsersHelper.GetAllUsers();
                dgUsers.ItemsSource = games;
                txtblockNumberOfGames.Text = $"The Number of Users is {games.Count().ToString()}";
                //if (addGame.ShowDialog()==true)
                //{
                //    if (MessageBox.Show("Update", "Are You Sure To Delete This Game?", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                //    {
                //        int COUNT = GamesHelper.UpdateGame(selectedGame);
                //        if (COUNT > 0)
                //        {
                //            MessageBox.Show(COUNT.ToString());
                //        };
                //    }

                //    dgGames.ItemsSource = GamesHelper.GetAllGames();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }



        }

        //private void btnEdit_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        var row = sender as DataGridRow;
        //        MessageBox.Show($"you clicked {row}");

        //        var Game = row.DataContext as Game;
        //        MessageBox.Show($"you clicked {Game.name}");

        //        AddGame w = new AddGame();
        //        MessageBox.Show($"you clicked {Game.name}");
        //        w.Show();
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message.ToString());
        //        ;
        //    }

        //    //List<Game> games = GamesHelper.GetAllGames();
        //    //try
        //    //{
        //    //    var selectedGame = (Game)dgGames.SelectedItem;
        //    //    AddGame addGame = new AddGame();
        //    //    addGame.ShowDialog();


        //    //    if (MessageBox.Show("Deleted", "Are You Sure To Delete This Game?", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
        //    //    {
        //    //        int COUNT = GamesHelper.UpdateGame(selectedGame);
        //    //        if (COUNT > 0)
        //    //        {
        //    //            MessageBox.Show(COUNT.ToString());
        //    //        };
        //    //    }

        //    //    dgGames.ItemsSource = games;
        //    //    txtblockNumberOfGames.Text = $"The Number of games is {games.Count().ToString()}";



        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.Message.ToString());

        //    //}


        //}

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedRow = (users)dgUsers.SelectedItem;

                if (MessageBox.Show("Are You Sure To Delete This Game?", "Delete Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    int COUNT = UsersHelper.DeleteUsersbyId(selectedRow);
                    if (COUNT > 0)
                    {
                        MessageBox.Show(COUNT.ToString());
                    };
                }
                List<users> games = UsersHelper.GetAllUsers();

                dgUsers.ItemsSource = games;
                txtblockNumberOfGames.Text = $"The Number of Users is {games.Count().ToString()}";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erorr.....", MessageBoxButton.OK, MessageBoxImage.Error);


            }


        }


    }
}
