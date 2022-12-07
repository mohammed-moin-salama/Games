using System;
using System.Windows;
using System.Windows.Threading;

namespace Game_Store
{
    /// <summary>
    /// Interaction logic for SplachScreen.xaml
    /// </summary>
    /// 
    public partial class SplachScreen : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public SplachScreen()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 4);
            timer.Start();
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            SignUp sign = new SignUp();
            sign.Show();
            timer.Stop();
            Close();
        }
    }
}
