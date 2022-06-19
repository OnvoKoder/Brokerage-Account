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
    /// Interaction logic for SignInEmp.xaml
    /// </summary>
    public partial class SignInEmp : Page
    {
        public SignInEmp()
        {
            InitializeComponent();
        }

        private void Sign(object sender, RoutedEventArgs e)
        {
            try
            {
                 Model model = new Model();
                 string psw = TxtPsw.Text;
                 string email = TxtLogin.Text;
                 if (string.IsNullOrEmpty(psw.Trim()) != true && string.IsNullOrEmpty(email.Trim()) != true)
                 {
                    model.CheckEmp(email, psw);
                 }
                 else
                 {
                    MessageBox.Show("Заполни поля");
                  }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
