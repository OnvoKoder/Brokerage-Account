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
    /// Interaction logic for AddBrokerage.xaml
    /// </summary>
    public partial class AddBrokerage : Page
    {
        Model model = new Model();
        string broker;
        public AddBrokerage()
        {
            InitializeComponent();
            model.Broker(cmbbroker);
        }

        private void BrokerClick(object sender, RoutedEventArgs e)
        {
            try
            {
                double money = double.Parse(tbxMoney.Text);
                string Descr = tbxDesc.Text;
                switch (cmbbroker.SelectedIndex)
                {
                    case 0:
                        broker = "SBRBR";
                         break;
                    case 1:
                        broker = "TSPBR";
                         break;
                     case 2:
                        broker = "VTBBR";
                         break; 
                }
                if (money > 0 && string.IsNullOrEmpty(Descr))
                {
                   model.OpenBrokerage(Descr,broker,money);
                }   
            }
            catch (Exception ex)
            {
             MessageBox.Show(ex.Message);
            }                      
        }
    }
}
