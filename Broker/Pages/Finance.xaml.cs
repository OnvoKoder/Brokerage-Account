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
    /// Interaction logic for Finance.xaml
    /// </summary>
    public partial class Finance : Page
    {
        int x1, x2;
        Model model = new Model();
        public Finance()
        {
            InitializeComponent();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            switch(cmbOption.SelectedIndex)
            {
                case 0:
                    x1 = 0;
                    break;
                case 1:
                    x1 = 1;
                    break;
                case 2:
                    x1 = 2;
                    break;
                case 3:
                    x1 = 3;
                    break;
                case 4:
                    x1 = 4;
                    break;

            }
            switch(cmbOrder.SelectedIndex)
            {
                case 0:
                    x2= 0;
                    break;
                case 1:
                    x2=1;
                    break;
            }
            model.OrderMarket(x1, x2,ViewL);
            
        }
    }
}
