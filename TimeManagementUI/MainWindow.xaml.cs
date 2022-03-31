using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeManagementUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //-------------------------------------------------------------------------------------------------------\\       

        public MainWindow()
        {
            InitializeComponent();
            
        }

        //-------------------------------------------------------------------------------------------------------\\

        private void MinimizeButton(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //-------------------------------------------------------------------------------------------------------\\

        private void StartButton(object sender, RoutedEventArgs e)
        {
             this.Hide();

            UserModulePage UP = new UserModulePage();

            UP.Show(); // need to initiliaze as hidden or something 
        }

        //-------------------------------------------------------------------------------------------------------\\

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        //-------------------------------------------------------------------------------------------------------\\
    }
}

        //-------------------------------------------------------------------------------------------------------\\
