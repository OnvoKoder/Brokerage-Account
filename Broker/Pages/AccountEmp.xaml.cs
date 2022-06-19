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
    /// Interaction logic for AccountEmp.xaml
    /// </summary>
    public partial class AccountEmp : Page
    {
        public AccountEmp()
        {
            InitializeComponent();
            FullName.Text = GetName.Name;
        }
    }
}
