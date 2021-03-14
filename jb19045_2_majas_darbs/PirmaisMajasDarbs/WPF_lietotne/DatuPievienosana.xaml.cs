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
using Customer1;
using Employee1;
using OrderDetail1;
using PirmaisMajasDarbs;
namespace WPF_lietotne
{
    /// <summary>
    /// Interaction logic for DatuPievienosana.xaml
    /// </summary>
    
    public partial class DatuPievienosana : Window
    {
        private IOrderManager parvaldnieks;
        private List<Employee> employees = new List<Employee>();
        private List<Customer> customers = new List<Customer>();
        private List<OrderDetail> DetalasList = new List<OrderDetail>();
        public DatuPievienosana(IOrderManager fi)  //Konstruktors
        {
            InitializeComponent();
            parvaldnieks = fi; 
            Aizpildit_cbo(parvaldnieks); //aizpildām visas Comboboksus TabControlā
        }
        private void Aizpildit_cbo(IOrderManager fi)   //Comboboksas aizpildīšana
        {
            employees.Clear();  //tīram Lisu
            customers.Clear();
            var allPersons = parvaldnieks.GetPersons(); //visas personas
            foreach (var i in allPersons)
            {
                if (i is Employee) { employees.Add((Employee)i); } //ja ir darbinieks, tad pievienojam darbinieku Listā   
                else if (i is Customer) { customers.Add((Customer)i); } //ja ir pasūtītājs, tad pievienojam pasūtītāju Listā
            }
            cboDarbinieks.ItemsSource = employees;
            cboPasutitajs.ItemsSource = customers;
        }
        private void PievienotPasutitaju_Click(object sender, RoutedEventArgs e)
        {
            //pārbaudām, vai visi lauki ir ievadīti
            if (String.IsNullOrEmpty(PasutitajaVards.Text) || String.IsNullOrEmpty(PasutitajaUzvards.Text) || String.IsNullOrEmpty(PasutitajaEmail.Text))
            {
                System.Windows.Forms.MessageBox.Show("Kļūda! Kāds no laukiem nav ievadīts", "Pasūtītāju pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {       //jautājam, vai veikt pievienošanu?
                DialogResult dr = new DialogResult();           //avots  https://csharp.hotexamples.com/examples/-/DialogResult/-/php-dialogresult-class-examples.html
                dr = System.Windows.Forms.MessageBox.Show("Vai pievienot pasūtītāju?", "Pasūtītāja pievienošana", MessageBoxButtons.YesNo, MessageBoxIcon.Question);       
                if (dr == System.Windows.Forms.DialogResult.Yes)  //Lietotajs ir nospiedis "Jā"
                {
                    //veidojam jaunu pasūtītāju
                    var pasutitajs = new Customer1.Customer();
                    // pārbaudam Email ievadītu lauku
                    pasutitajs.EMail = PasutitajaEmail.Text;
                    if (pasutitajs.EMail == null)  //ja netika pievienots Email (ir nekorekts) 
                    {
                        System.Windows.Forms.MessageBox.Show("Kļūda! Email ievadīts nekorekti", "Pasūtītāju pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //ievadītie lauki bija korekti ievadīti, pievienojam personu 
                        pasutitajs.Name = PasutitajaVards.Text;
                        pasutitajs.Surname = PasutitajaUzvards.Text;
                        parvaldnieks.AddPerson(pasutitajs);  //pievienojam sarakstā jauno personu
                        System.Windows.Forms.MessageBox.Show("Veiksmigi pievienots jauns pasūtītājs! :)", "Pasūtītāja pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Aizpildit_cbo(parvaldnieks);  //atjaunojam visas Comboboksus
                    }
                    
                }
            }
            
        }  //realizē jaunā pasūtītāja veidošanu/pievienošnu
        private void PievienotDarbinieku_Click(object sender, RoutedEventArgs e)
        {
            //pārbaudām, vai visi lauki ir ievadīti
            if (String.IsNullOrEmpty(DarbiniekaVards.Text) || String.IsNullOrEmpty(DarbiniekaUzvards.Text) || String.IsNullOrEmpty(DarbiniekaEmail.Text)
                || !(DarbiniekaLigumsDate.SelectedDate.HasValue) || String.IsNullOrEmpty(DarbiniekaNumurs.Text))
            {
                System.Windows.Forms.MessageBox.Show("Kļūda! Kāds no laukiem nav ievadīts", "Darbinieka pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //jautājam, vai veikt pievienošanu?
                DialogResult dr = new DialogResult();           //avots  https://csharp.hotexamples.com/examples/-/DialogResult/-/php-dialogresult-class-examples.html
                dr = System.Windows.Forms.MessageBox.Show("Vai pievienot darbinieku?", "Darbinieka pievienošana", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //ja lietotajs ir nospiedis "Jā", vaicam pievienošanu
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    DateTime date1 = new DateTime();
                    //veidojam jauno objektu - Darbinieku
                    var darbinieks = new Employee1.Employee();
                    DateTime.TryParse(DarbiniekaLigumsDate.Text, out date1);
                    darbinieks.EMail = DarbiniekaEmail.Text;
                    if (darbinieks.EMail == null) //ja netika pievienots Email (ir nekorekts) 
                    {
                        System.Windows.Forms.MessageBox.Show("Kļūda! Email ievadīts nekorekti", "Darbinieka pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //ievadītie lauki bija korekti ievadīti, pieškiram īpašības 
                        darbinieks.Name = DarbiniekaVards.Text;
                        darbinieks.Surname = DarbiniekaUzvards.Text;
                        darbinieks.AgreementDate = date1;
                        darbinieks.AgreementNr = DarbiniekaNumurs.Text;
                        parvaldnieks.AddPerson(darbinieks);  //pievienojam jauno darbinieku sarakstā
                        System.Windows.Forms.MessageBox.Show("Veiksmigi pievienots jauns darbinieks! :)", "Darbinieka pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Aizpildit_cbo(parvaldnieks); //atjauninām Comboboksus
                    }
                }
            }
        }  //realizē jaunā darbinieka veidošanu/pievienošanu
        private void PievienotProduktu_Click(object sender, RoutedEventArgs e)
        {
            //pārbaudām, vai visi lauki ir ievadīti
            if (String.IsNullOrEmpty(ProduktaNosaukums.Text) || String.IsNullOrEmpty(ProduktaCena.Text))
            {
                System.Windows.Forms.MessageBox.Show("Kļūda! Kāds no laukiem nav ievadīts", "Produkta pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // jautājam, vai veikt pievienošanu?
                 DialogResult dr = new DialogResult();           //avots  https://csharp.hotexamples.com/examples/-/DialogResult/-/php-dialogresult-class-examples.html
                dr = System.Windows.Forms.MessageBox.Show("Vai pievienot produktu?", "Produkta pievienošana", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               // Lietotajs ir nospiedis "Jā"
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    decimal cena;
                    bool success = decimal.TryParse(ProduktaCena.Text, out cena);  //Cena pārbaudīšana (vai atbilst tipam?)
                    if (!success)               //https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=netcore-3.1
                    {
                        System.Windows.Forms.MessageBox.Show("Nepareizi iepadīta cena", "Produkta pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //ja ievadītie lauki bija korekti un visi aizpildīti, tad veidojam jauno produktu
                        var produkts = new Product1.Product();
                        produkts.Name = ProduktaNosaukums.Text;
                        produkts.Price = cena;
                        parvaldnieks.AddProduct(produkts); //pievienojam izvedoto produktu produktu Listā
                        System.Windows.Forms.MessageBox.Show("Veiksmigi pievienots jauns produkts! :)", "Produkta pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Aizpildit_cbo(parvaldnieks); //atjauninām Comboboksus
                    }
                }
            }
        }   //realizē jaunā produkta veidošnu/pievienošanu
        private void PievienotDetalas_Click(object sender, RoutedEventArgs e)
        {
                //veidojam objektu - jauno WPF logu, kas nodrošina detaļas pievienošanu  
                DetalasPievienosana detalas = new DetalasPievienosana(parvaldnieks);
                detalas.ShowDialog(); //Parādām logu modāli (bloķējam iepriekšējo logu)
               //ja lietotājs ir nospiedis "Ja" - tika izveidota jauna pasūtījuma detaļa ar aizpildītām īpašībām 
                if (detalas.dr == System.Windows.Forms.DialogResult.Yes)
                {
                    DetalasList.Add(detalas.detail); //pievienojam iepriekš izveidoto Listu pie pasūtījuma detaļām 
                    //jautājam, vai pievienot vēl vienu produktu?
                    DialogResult dr2 = new DialogResult(); 
                    dr2 = System.Windows.Forms.MessageBox.Show("Vai pievienot vēl vienu produktu pie pasūtījuma detaļam?", "Produkta pievienošana", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr2 == System.Windows.Forms.DialogResult.Yes)
                    { 
                        // ja lietotājs ir nospiedis "Jā", ja tiks atvērta vēlreiz šī funkcija, kas ļauj izveidot vēl vienu pasūtījuma detaļu 
                        PievienotDetalas_Click(sender, e);  
                    }
                     
                    PievienotDetalas.IsEnabled = false; //Neļaujam lietotājam nospiest pogu, kas ļauj pievienot jaunas detaļas
                    DetalasSaraksts.Visibility = Visibility.Visible;  //Dodam iespēju redzēt texta bloku
                    DetalasSarakstsScroller.Visibility = Visibility.Visible;
                    DzestDetalas.Visibility = Visibility.Visible;   //Dodam iespēju redzēt pogu, kas ļauj dzēst visas ieprieks izvadītas detaļas
                    //Rakstam visas izveidotas pasūtījuma detaļas text blokā
                    DetalasSaraksts.Text = "Pievienotas detaļas:\n";
                    int index = 1;
                    foreach (var d in DetalasList)
                    {
                        DetalasSaraksts.Text += index + ". " + d.product.Name + "\n   Cena: " + d.product.Price + "\n   Skaits:" +  d.amount + "\n\n";
                        index++;
                    }
                }
        }  //ļauj ievadīt/pievienot jaunās detāļas pie pasūtījuma (veido kolekciju ar detaļām)
        private void PievienotPasutijumu_Click_1(object sender, RoutedEventArgs e)
        {
            //pārbaudām, vai visi lauki ir ievadīti
            if (cboStavoklis.SelectedItem == null || cboDarbinieks.SelectedItem == null || cboPasutitajs == null || DetalasList == null || !(PasutijumaDatums.SelectedDate.HasValue))
            {
                System.Windows.Forms.MessageBox.Show("Kļūda! Kāds no laukiem nav ievadīts", "Pasūtījuma pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = new DialogResult();           //avots  https://csharp.hotexamples.com/examples/-/DialogResult/-/php-dialogresult-class-examples.html
                dr = System.Windows.Forms.MessageBox.Show("Vai pievienot pasūtījumu?", "Pasūtījuma pievienošana", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.Yes) //ja lietotājs nospiež "Jā"
                {
                    DateTime date1 = new DateTime();
                    DateTime.TryParse(PasutijumaDatums.Text, out date1); //datumu no teksta tipa pārveidojam uz tipu DateTime
                    var pasutijums = new Order1.Order(); //veidojam jaunu pasūtījumu 
                    var stavoklis = (Order1.states)cboStavoklis.SelectedItem; //izvēlēto stavokli piešķiram pasūtījumam
                    pasutijums.State = stavoklis;
                    pasutijums.ResponsibleEmployee = (Employee1.Employee)cboDarbinieks.SelectedItem;
                    pasutijums.Customer = (Customer1.Customer)cboPasutitajs.SelectedItem;
                    pasutijums.OrderDate = date1;
                    if (!DetalasList.Any())
                    {
                        System.Windows.Forms.MessageBox.Show("Jūs neizvēlējaties nevienu produktu! (Produkta detaļas)", "Produkta pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else //ja ir pievienots pasūtītījuma detaļas
                    {
                        pasutijums.Details = DetalasList;
                        parvaldnieks.AddOrder(pasutijums); //pievienojam jauno objektu - pasūtījumu kolekcijai ar visiem pasūtījumiem
                        System.Windows.Forms.MessageBox.Show("Veiksmigi pievienots jauns pasūtījums! :)", "Produkta pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); //aizvērām šo logu 
                    }
                }
            }
        }  //realizē jaunā pasūtījuma veidošanu/pievienošanu
        private void DzestDetalas_Click(object sender, RoutedEventArgs e)
        {
            //tīram kolekciju ar viesiem izveidotām detaļām
            DetalasList.Clear();
            //tīram teksu text blokā 
            DetalasSaraksts.Text = "";
            //nedodam iespēju redzēt text bloku
            DetalasSaraksts.Visibility = Visibility.Hidden;
            DetalasSarakstsScroller.Visibility = Visibility.Hidden;
            //nedodam iespēju redzēt pogu, kas ļauj dzēst detaļam
            DzestDetalas.Visibility = Visibility.Hidden;
            //ļaujam lietotājam izmantot pogu, lai pievienotu pasūtījuma detaļas
            PievienotDetalas.IsEnabled = true;

        }  //ļauj dzēst izveidotās pasūtījuma detaļas 
    }
}
