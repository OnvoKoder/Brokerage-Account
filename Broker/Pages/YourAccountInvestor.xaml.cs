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
    /// Логика взаимодействия для YourAccount.xaml
    /// </summary>
    public partial class YourAccount : Page
    {
        public YourAccount()
        {
            InitializeComponent();
            FullName.Text = GetName.Name;
        }

       

        private void SeeClick(object sender, RoutedEventArgs e)
        {
            if (Brokercmb.SelectedIndex != -1)
            {
                Model model = new Model();
                model.BrokerageAccount(User, Brokercmb.SelectedIndex);
            }
        }

        private void ViewClick(object sender, RoutedEventArgs e)
        {
            if (Marketcmb.SelectedIndex != -1)
            {
                Model model = new Model();
                model.Market(Users, Marketcmb.SelectedIndex);
            }
        }

        private void BtnEditClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditData());
        }

        private void PurchaseClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BuyOut());
        }
    }
}
