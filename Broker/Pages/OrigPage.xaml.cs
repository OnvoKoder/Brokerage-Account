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
using Broker.Pages;
using Broker.Class;

namespace Broker.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrigPage.xaml
    /// </summary>
    public partial class OrigPage : Page
    {
        public OrigPage()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ChooseButton());
        }

        private void FinanceClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Finance());
        }
    }
}
