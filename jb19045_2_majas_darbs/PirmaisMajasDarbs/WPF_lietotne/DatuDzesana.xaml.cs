using Customer1;
using Employee1;
using OrderDetail1;
using PirmaisMajasDarbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_lietotne
{
    /// <summary>
    /// Interaction logic for DatuDzesana.xaml
    /// </summary>
    public partial class DatuDzesana : Window
    {
        private IOrderManager parvaldnieks;
        private List<Employee> employees = new List<Employee>();
        private List<Customer> customers = new List<Customer>();
        private List<Product1.Product> produkti = new List<Product1.Product>();
        public DatuDzesana(IOrderManager fi)
        {
            InitializeComponent();
            parvaldnieks = fi;
            foreach (var i in parvaldnieks.GetPersons())
            {
                if (i is Employee) {  employees.Add((Employee)i);  } //ja ir darbinieks, pievienojam kolekcijai ar darbiniekiem
                else if (i is Customer) { customers.Add((Customer)i);  } //ja ir pasūtītājs, pievienojam kolekcijai ar pasūtītājiem
            }  //customer, employee koleciju aizpildīšana
            foreach (var product in parvaldnieks.GetProducts()) { produkti.Add((Product1.Product)product);} //aizpildām produktu kolekciju
            cboIzvelne.ItemsSource = customers; //sākumā Comboboksā ir visi pasūtītāji 
        }  //loga konstruktors

        private void Pasutitaji_Click(object sender, RoutedEventArgs e)
        {
            if (!customers.Any())  //ja sarakstā nav neviena pasūtītāja
            {
                IzvelnesTeksts.Content = "Nav neviena pasūtītāja";
                IzvelnesTeksts.Width = 250;
                //nav pieejams Comboboks ar pasūtītājiem
                cboIzvelne.Visibility = Visibility.Hidden;
                //nav pieejama vair poga "Dzēst"
                Dzest.IsEnabled = false;
            }
            else { // ja sarakstā ir vismaz viens pasūtītājs
                cboIzvelne.ItemsSource = customers;
                IzvelnesTeksts.Width = 105;
                IzvelnesTeksts.Content = "Pasūtītājs:";
                //ir redzama gan poga dzēst, gan Comboboks
                cboIzvelne.Visibility = Visibility.Visible;
                Dzest.IsEnabled = true;
            }
            
        } //lietotājs izvēlās dzēst kaut kādu pasūtītāju

        private void Darbinieki_Click(object sender, RoutedEventArgs e)
        {
            if (!employees.Any()) //ja sarakstā nav darbinieka
            {
                IzvelnesTeksts.Content = "Nav neviena darbinieka";
                cboIzvelne.Visibility = Visibility.Hidden;
                //nav pieejama poga "Dzēst" un Comboboks
                IzvelnesTeksts.Width = 250;
                Dzest.IsEnabled = false; 
            }
            else {  //ja sarakstā ir vismaz viens darbinieks 
                IzvelnesTeksts.Content = "Darbinieks:"; 
                cboIzvelne.ItemsSource = employees;
                IzvelnesTeksts.Width = 105;
                //ir pieejams Comboboks un ir pieejama poga "Dzēst"
                cboIzvelne.Visibility = Visibility.Visible;
                Dzest.IsEnabled = true;
            }
        }  //lietotājs izvēlās dzēst kaut kādu darbinieku

        private void Produkti_Click(object sender, RoutedEventArgs e)
        {
            if (!produkti.Any()) //ja sarakstā ar produktiem nav neviena produkta
            {
                IzvelnesTeksts.Content = "Nav neviena produkta";
                cboIzvelne.Visibility = Visibility.Hidden;
                //nav pieejama poga "Dzēst" un Comboboks
                Dzest.IsEnabled = false;
                IzvelnesTeksts.Width = 250;
            }
            else {  //ja sarakstā ir vismaz viens produkts
                IzvelnesTeksts.Content = "Produkts:"; 
                cboIzvelne.ItemsSource = produkti;
                //ir redzams gan Comboboks, gan poga "Dzēst"
                cboIzvelne.Visibility = Visibility.Visible;
                IzvelnesTeksts.Width = 105;
                Dzest.IsEnabled = true;
            }
        }  //lietotājs izvēlās dzēst kaut kādu produktu 

        private void Dzest_Click(object sender, RoutedEventArgs e) //lietotājs nospiež pogu "Dzēst"
        {
            //ja nekas nav izvēlēts ,tad klūda!
            if (cboIzvelne.SelectedItem == null )
            {
                System.Windows.Forms.MessageBox.Show("Izvēlējaties ko dzēst komboboksā", "Dzēšana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //ja ir kaut ko izvēlēts
            {
                if (cboIzvelne.SelectedItem.GetType() == typeof(Employee))  //ja izvēlēts darbinieks
                {
                    employees.Remove((Employee1.Employee)cboIzvelne.SelectedItem);  //no saraksta dzēstam šo darbinieku
                    parvaldnieks.DeleteEmployee((Employee1.Employee)cboIzvelne.SelectedItem); //dzēstam darbinieku
                    cboIzvelne.ItemsSource = null; // dzēšam visu Comboboksā
                    System.Windows.Forms.MessageBox.Show("Veiksmigi dzēsts darbinieks!", "Darbinieka dzēšana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Darbinieki_Click(sender, e);  //no jaunas izvēlējamies dzēst kādu darbinieku (izsaucam iepriekšējo funkciju)
                }
                else if (cboIzvelne.SelectedItem.GetType() == typeof(Customer)) //ja izvēlēts pasūtītajs
                {
                    customers.Remove((Customer1.Customer)cboIzvelne.SelectedItem); //no saraksta dzēšam šo pasūtītāju
                    parvaldnieks.DeleteCustomer((Customer1.Customer)cboIzvelne.SelectedItem);//dzēšam pasūtītāju
                    cboIzvelne.ItemsSource = null;  // dzēšam visu Comboboksā
                    System.Windows.Forms.MessageBox.Show("Veiksmigi dzēsts pasūtītajs!", "Pasūtītāja dzēšana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Pasutitaji_Click(sender, e);//no jaunas izvēlējamies dzēst kādu pasūtītāju (izsaucam iepriekšējo funkciju)
                }
                else if (cboIzvelne.SelectedItem.GetType() == typeof(Product1.Product)) //ja izvēlēts produkts
                {
                    produkti.Remove((Product1.Product)cboIzvelne.SelectedItem);//no saraksta dzēšam šo produktu
                    parvaldnieks.DeleteProduct((Product1.Product)cboIzvelne.SelectedItem);//dzēšam pasūtītāju
                    cboIzvelne.ItemsSource = null; // dzēšam visu Comboboksā
                    System.Windows.Forms.MessageBox.Show("Veiksmigi dzēsts produkts!", "Produkta dzēšana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Produkti_Click(sender, e);//no jaunas izvēlējamies dzēst kādu produktu (izsaucam iepriekšējo funkciju)
                }
            }

        }
    }
}
