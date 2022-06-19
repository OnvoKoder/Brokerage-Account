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
    /// Interaction logic for BuyOut.xaml
    /// </summary>
    public partial class BuyOut : Page
    {
        Model model = new Model();
        int req=1;
        public BuyOut()
        {
            InitializeComponent();

        }

        private void btnChooseClick(object sender, RoutedEventArgs e)
        {
            Ordered.Visibility = Visibility.Visible;
            cmbStonks.Items.Clear();
            switch (Choose.SelectedIndex)
            {
                case 0:
                    model.Puchase(cmbStonks);
                    req = 1;
                    break;
                case 1:
                    model.Sale(cmbStonks);
                    req = 2;
                    break;
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (cmbStonks.SelectedIndex)
                {
                    case 0:
                        GetNameCompany.Get((string)cmbStonks.SelectedItem);
                        break;
                    case 1:
                        GetNameCompany.Get((string)cmbStonks.SelectedItem);
                        break;
                    case 2:
                        GetNameCompany.Get((string)cmbStonks.SelectedItem);
                        break;
                    case 3:
                        GetNameCompany.Get((string)cmbStonks.SelectedItem);
                        break;
                    case 4:
                        GetNameCompany.Get((string)cmbStonks.SelectedItem);
                        break;
                }
               
               model.Create(double.Parse(tbxCount.Text), req);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
   
}
