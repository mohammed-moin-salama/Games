using Game_Store.Helpers;
using Game_Store.Models;
using Game_Store.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game_Store
{
    /// <summary>
    /// Interaction logic for GameIndex.xaml
    /// </summary>








    public partial class GameIndex : UserControl
    {
        public GameIndex()
        {
            InitializeComponent();

            try
            {
                List<Game> games = GamesHelper.GetAllGames();
                dgGames.ItemsSource = games;
                txtblockNumberOfGames.Text = $"The Number of games is {games.Count().ToString()}";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr.....", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void txtSeach_KeyUp(object sender, KeyEventArgs e)
        {
            List<Game> games = GamesHelper.GetAllGames();
            List<Game> Sreachedgames = GamesHelper.GetAllGames().Where(
               game => game.game_id.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               game.name.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               game.store_id.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               game.price.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               game.publisher.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               game.release_date.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               game.review.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               game.genre.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               game.game_id.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               game.except_country.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               game.description.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower()) ||
               game.developer.ToString().ToLower().Contains(txtSeach.Text.ToString().ToLower())
            ).ToList();

            if (txtSeach.Text.Length > 0)
            {

                dgGames.ItemsSource = Sreachedgames;
                txtblockNumberOfGames.Text = $"The Number of games is {Sreachedgames.Count().ToString()}";
            }
            else
            {
                dgGames.ItemsSource = games;
                txtblockNumberOfGames.Text = $"The Number of games is {games.Count().ToString()}";

            }

        }


        private void btnAddGame_Click(object sender, RoutedEventArgs e)
        {
            AddGame addGame = new AddGame();
            addGame.x = 0;
            addGame.ShowDialog();
            dgGames.ItemsSource = GamesHelper.GetAllGames();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Game selectedGame = (Game)dgGames.SelectedItem;

                var addGame = new AddGame();
                addGame.x = 1;

                publishers pub = PublisersHepler.GetAllPublisers().Where(o => o.publisher_id == Convert.ToInt32(selectedGame.publisher)).ToList()[0];
                stores store = StoresHelper.GetAllStores().Where(o => o.store_id == Convert.ToInt32(selectedGame.store_id)).ToList()[0];
                Developer  dev = DevelopersHelper.GetAllDevelopers().Where(o => o.developer_id == Convert.ToInt32(selectedGame.developer)).ToList()[0];

                int pubindex = PublisersHepler.GetAllPublisers().Select(asas => asas.name.ToString()).ToList().IndexOf(pub.name);
                int  storeindex = StoresHelper.GetAllStores().Select(asas => asas.store_id.ToString()).ToList().IndexOf(store.store_id.ToString());
                int devindex = DevelopersHelper.GetAllDevelopers().Select(asas => asas.name.ToString()).ToList().IndexOf(dev.name);

                //MessageBox.Show(addGame.x.ToString());
                //MessageBox.Show($"you clicked {dept.dname}");
                addGame.txtname.Text = selectedGame.name;
                addGame.txtgenre.Text = selectedGame.genre;
                addGame.txtprice.Text = Convert.ToInt32(selectedGame.price).ToString();
                addGame.txtrelease_date.Text = Convert.ToDateTime(selectedGame.release_date).ToString();
                addGame.txtreview.Text = Convert.ToInt32(selectedGame.review).ToString();
             //addGame.cmboxStoreId.SelectedValue = StoresHelper.GetAllStores().Where(o => o.store_id == Convert.ToInt32(selectedGame.store_id)).Select(o=>o.store_id).ToString();
                //addGame.cmboxDeveloper.SelectedValue = DevelopersHelper.GetAllDevelopers().Where(o => o.developer_id == Convert.ToInt32(selectedGame.developer)).Select(o => o.name).ToString();
              //addGame.cmboxPublisherName.SelectedItem =  PublisersHepler.GetAllPublisers().Where(o => o.publisher_id == Convert.ToInt32(selectedGame.publisher)).Select(o => o.name);
                addGame.cmboxDeveloper.SelectedIndex = devindex;
                addGame.cmboxStoreId.SelectedIndex = storeindex;
                addGame.cmboxPublisherName.SelectedIndex = pubindex;
                //addGame.txtpublishername.Text = selectedGame.publisher.ToString();
                addGame.txtage_limit.Text = Convert.ToInt32(selectedGame.age_limit).ToString();
                //addGame.txtdevelopername.Text = selectedGame.developer.ToString();
                addGame.txtexcept_country.Text = selectedGame.developer.ToString();
                addGame.txtDescrpition.Text = selectedGame.description.ToString();
                addGame.txtGameId.Text = Convert.ToInt32(selectedGame.game_id).ToString();
                addGame.ShowDialog();
                dgGames.ItemsSource = GamesHelper.GetAllGames();
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
                var selectedRow = (Game)dgGames.SelectedItem;

                if (MessageBox.Show("Are You Sure To Delete This Game?", "Delete Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    int COUNT = GamesHelper.DeleteGamebyId(selectedRow);
                    if (COUNT > 0)
                    {
                        MessageBox.Show(COUNT.ToString());
                    };
                }

                dgGames.ItemsSource = GamesHelper.GetAllGames();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erorr.....", MessageBoxButton.OK, MessageBoxImage.Error);


            }


        }


    }
}
