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
    /// Interaction logic for EditData.xaml
    /// </summary>
    public partial class EditData : Page
    {
        public EditData()
        {
            InitializeComponent();
            model.Country(cmbCountry);
        }
        Model model = new Model();

        private void Open(object sender, RoutedEventArgs e)
        {
            try
            {
                string psw = txbPsw.Text;
                string email = txbEmail.Text;
                string bank = txbBankDetails.Text;
                string country = cmbCountry.SelectedItem.ToString();
                DateTime date = txbDateOfBirth.SelectedDate.Value;
                string name = txbFullName.Text;
                if (string.IsNullOrEmpty(psw.Trim()) != true && string.IsNullOrEmpty(email.Trim()) != true && string.IsNullOrEmpty(name.Trim()) != true && string.IsNullOrEmpty(bank.Trim()) != true && string.IsNullOrEmpty(country.Trim()) != true)
                {
                    if (bank.Length == 16 && (DateTime.Now.Year - date.Year >= 18))
                    {
                        model.Update(email, psw, name, country, date, bank);
                    }
                    else
                    {
                        MessageBox.Show("Неккоректный ввод банковской карты ");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
