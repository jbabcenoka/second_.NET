using PirmaisMajasDarbs;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DatuRedigesana.xaml
    /// </summary>
    public partial class DatuRedigesana : Window
    {
        private IOrderManager parvaldnieks;
        private List<Employee1.Employee> employees = new List<Employee1.Employee>();
        private List<Customer1.Customer> customers = new List<Customer1.Customer>();
        private List<Product1.Product> products = new List<Product1.Product>();
        public DatuRedigesana(IOrderManager fi)
        {
            InitializeComponent();
            parvaldnieks = fi;
            Aizpildit_cbo(fi); //aizpildām visus Komboboksus
        }
        private void Aizpildit_cbo(IOrderManager fi)  //Comboboksu aizpildīšana
        {
            //notīram visas kolekcijas
            products.Clear();
            employees.Clear();
            customers.Clear();

            var allProducts = fi.GetProducts();
            foreach (var i in allProducts) {  products.Add(i);   }
            cboProdukti.ItemsSource = products;

            var allPersons = fi.GetPersons();
            foreach (var persona in allPersons)
            {
                if (persona is Employee1.Employee) { employees.Add((Employee1.Employee)persona); }  //ja ir darbinieks, tad pievienojam darbinieku kolekcijā
                else if (persona is Customer1.Customer) { customers.Add((Customer1.Customer)persona); } //ja ir pasūtītajs, tad pievienojam pasūtītāju kolekcijā
            }
            cboDarbiniki.ItemsSource = employees;
            cboPasutitaji.ItemsSource = customers;
        }
        private void RedigetDarbinieku_Click(object sender, RoutedEventArgs e)  
        {
            //ja nav izēlēts darbinieks, tad kļūdas paziņojums
            if (cboDarbiniki.SelectedItem == null)
            {
                System.Windows.Forms.MessageBox.Show("Kļūda! Nav izvēlēts darbinieks", "Darbinieka rediģēšana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //ja VISMAZ VIENS lauks nav aizpildīts, tad tas nozīmē , ka nav ko rediģet => kļūdas paziņojums 
            if (String.IsNullOrEmpty(DarbiniekaNosaukums.Text) && String.IsNullOrEmpty(DarbiniekaUzvards.Text)
                && String.IsNullOrEmpty(DarbiniekaEmail.Text) && String.IsNullOrEmpty(DarbiniekaNum.Text)
                && !DarbiniekaDate.SelectedDate.HasValue)
            {
                System.Windows.Forms.MessageBox.Show("Lūdzu ievadiet vismaz vienu neobligāto lauku!", "Darbinieka rediģēšana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else  //ja nav kļūdu
            {
                //atvēras jautājumu logas
                DialogResult dr = new DialogResult();           //avots  https://csharp.hotexamples.com/examples/-/DialogResult/-/php-dialogresult-class-examples.html
                dr = System.Windows.Forms.MessageBox.Show("Vai rediģēt darbinieku?", "Darbinieka rediģēšana", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //ja lietotajs patiešām  grib rediģēt darbinieku
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (var darbinieks in employees)
                    {
                        if (darbinieks.Equals(cboDarbiniki.SelectedItem)) //atrodam lietotāja izvēlēto darbinieku kolekcijā
                        {
                            //ja lietotajs ievada jauno Emailu
                            if (!String.IsNullOrEmpty(DarbiniekaEmail.Text))
                            {
                                //pārbaudam, vai jauns Email ir korekts
                                var iepreksejaisEmails = darbinieks.EMail;
                                darbinieks.EMail = DarbiniekaEmail.Text;
                                if (iepreksejaisEmails == darbinieks.EMail)  //ja ir līdzigs iepiekšējam, tad jauns Email ir tas pats kas bija =>
                                {                                               //jauns Email nav jauns vai vienkārši bija nekorekti ievadīts
                                    System.Windows.Forms.MessageBox.Show("Kļūda! Email ievadīts nekorekti vai šis Email jau bija", "Darbinieka rediģēšana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break; //ja Email jau bija nekorekts, tad beidzam talāko darbību
                                }
                            }
                            //ja lietotājs ievada jauno darbinieka vārdu
                            if (!String.IsNullOrEmpty(DarbiniekaNosaukums.Text)) { darbinieks.Name = DarbiniekaNosaukums.Text; }
                            //ja lietotājs ievada jauno darbinieka uzvārdu
                            if (!String.IsNullOrEmpty(DarbiniekaUzvards.Text)) { darbinieks.Surname = DarbiniekaUzvards.Text; }
                            //ja lietotājs ievada jauno darbinieka numuru
                            if (!String.IsNullOrEmpty(DarbiniekaNum.Text)) { darbinieks.AgreementNr = DarbiniekaNum.Text; }
                            //ja lietotājs ievada jauno darbinieka līguma datumu
                            if (!String.IsNullOrEmpty(DarbiniekaDate.Text))
                            {
                                //pārbaudam un pārdefinējam tipu (stingd => DateTime)
                                DateTime date1 = new DateTime();
                                DateTime.TryParse(DarbiniekaDate.Text, out date1);
                                darbinieks.AgreementDate = date1;
                            }
                            System.Windows.Forms.MessageBox.Show("Veiksmigi rediģēts darbinieks!", "Darbinieka rediģēšana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); //aizvēram šo logu 
                        }
                    }


                }
            }  
        }  //nodrošina darbinika rediģēšanu
        private void RedigetPasutitaju_Click(object sender, RoutedEventArgs e)
        {
            //ja nav izvēlēts pasūtītājs Comboboksā, tad kļūda
            if (cboPasutitaji.SelectedItem == null)
            {
                System.Windows.Forms.MessageBox.Show("Kļūda! Nav izvēlēts pasūtītajs", "Pasūtītāja rediģēšana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //ja nav aizpildīts VISMAZ VIENS lauks, tad paziņojums, ka nav ko mainīt
            else if (String.IsNullOrEmpty(PasutitajaVards.Text) && String.IsNullOrEmpty(PasutitajaUzvards.Text)
                && String.IsNullOrEmpty(PasutitajaEmail.Text))
            {
                System.Windows.Forms.MessageBox.Show("Lūdzu ievadiet vismaz vienu neobligāto lauku!", "Darbinieka rediģēšana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = new DialogResult();           //avots  https://csharp.hotexamples.com/examples/-/DialogResult/-/php-dialogresult-class-examples.html
                dr = System.Windows.Forms.MessageBox.Show("Vai rediģēt pasūtītāju?", "Pasūtītāja rediģēšana", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (var cust in customers)
                    {
                        if (cust.Equals(cboPasutitaji.SelectedItem)) // atrodam kolekcijā noteikto pasūtītāju
                        {
                            //ja ir ievadīts pasūtītāja jauns Email
                            if (!String.IsNullOrEmpty(PasutitajaEmail.Text))
                            {
                                var iepreksejaisEmails = cust.EMail;
                                cust.EMail = PasutitajaEmail.Text;
                                if (iepreksejaisEmails == cust.EMail) //ja jauns Email bija nekorekti ievadīt, vai līdzigs iepriekšējam
                                {
                                    //paziņojums
                                    System.Windows.Forms.MessageBox.Show("Kļūda! Email ievadīts nekorekti vai ir tas pats, kas bija iepriekš", "Pasūtītāja rediģēšana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break; //beidzam darbu
                                }
                            }
                            //ja ir ievadīts pasūtītāja jauns vārds
                            if (!String.IsNullOrEmpty(PasutitajaVards.Text)) {  cust.Name = PasutitajaVards.Text; }
                            //ja ir ievadīts pasūtītāja jauns uzvārds
                            if (!String.IsNullOrEmpty(PasutitajaUzvards.Text)) { cust.Surname = PasutitajaUzvards.Text; }
                            System.Windows.Forms.MessageBox.Show("Veiksmigi rediģēts pasūtītājs!", "Pasūtītāja rediģēšana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); //aizvēram šo logu 
                        }
                    }


                }
            }
        }  //nodrošina pasūtītāju rediģēšanu
        private void RedigetProduktu_Click(object sender, RoutedEventArgs e)
        {
            //ja nav izvēlēts produkts Comboboksā => kļūdas paziņojums
            if (cboProdukti.SelectedItem == null)
            {
                System.Windows.Forms.MessageBox.Show("Kļūda! Nav izvēlēts produkts", "Produkta rediģēšana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //ja VISMAZ VIENS no laukim nav aizpildīts, tad kļūda - nav ko mainīt
            if (String.IsNullOrEmpty(ProduktaNosaukums.Text) && String.IsNullOrEmpty(ProduktaCena.Text))
            {
                System.Windows.Forms.MessageBox.Show("Kļūda! Ievadiet jauno nosaukumu un/vai cenu", "Produkta pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //ja nav kļūdu
            {
                DialogResult dr = new DialogResult();           //avots  https://csharp.hotexamples.com/examples/-/DialogResult/-/php-dialogresult-class-examples.html
                dr = System.Windows.Forms.MessageBox.Show("Vai rediģēt produktu?", "Produkta rediģēšana", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //ja lietotājs patiešām grib rediģēt produktu
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    //pārbaude vai cena ir ievadīta pareiza - vai var pārvedot (string => decimal)?
                    decimal cena;
                    bool success = decimal.TryParse(ProduktaCena.Text, out cena);
                    if (!success)               //https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=netcore-3.1
                    {
                        System.Windows.Forms.MessageBox.Show("Nepareizi iepadīta cena", "Produkta pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else //ja lauki ir iedīti pareizi
                    {
                        foreach (var product in parvaldnieks.GetProducts())
                        {
                            if (product.Equals(cboProdukti.SelectedItem))  //atrodam produktu sarakstā
                            {
                                //ja ir ievadīts produkta jauns nosaukums 
                                if (!String.IsNullOrEmpty(ProduktaNosaukums.Text)) { product.Name = ProduktaNosaukums.Text; }
                                //ja ir ievadīts produkta jauna cena 
                                if (!String.IsNullOrEmpty(ProduktaCena.Text)) { product.Price = cena; }
                            }
                        }
                        System.Windows.Forms.MessageBox.Show("Veiksmigi rediģēts produkts! :)", "Produkta rediģēšana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();  //aizvēram šo logu pēc veiksmīgas rediģēšanas
                    }

                }

            }
        } //nodrošina produkta rediģēšanu
    }
}
