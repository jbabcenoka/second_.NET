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
    /// Interaction logic for DetalasPievienosana.xaml
    /// </summary>
    public partial class DetalasPievienosana : Window
    {
        private IOrderManager parvaldnieks;
        private List<Product1.Product> products = new List<Product1.Product>();
        public OrderDetail1.OrderDetail detail = new OrderDetail1.OrderDetail();//public, lai pēc šī lista izveidošanās, iepriekšējā logā 
                                                                                //var redzēt šo listu - visas pievienotas detaļas

        public DialogResult dr = new DialogResult();  //public ir lai izmantotu atbildi iepriekšājā logā (Uzzināt atbildi uz jautājumu:
                                                        //vai tika pievienotas pasūtījuma detaļas? 
        public DetalasPievienosana(IOrderManager fi)
        {
            InitializeComponent();
            parvaldnieks = fi;
            var allProducts = parvaldnieks.GetProducts();
            foreach (var i in allProducts) {  products.Add(i); } //pievienojam visus produktus savā listā, lai aizpildītu Combobuksu
            cboProdukti.ItemsSource = products; //Aizpildām Comboboksu
        }
        private void PievienotDetalu_Click(object sender, RoutedEventArgs e)
        {
             //Pāŗbaudam vai ir ievadīti visi lauki
            if (String.IsNullOrEmpty(ProduktaDaudzums.Text) || cboProdukti.SelectedItem == null)
            {
                System.Windows.Forms.MessageBox.Show("Kļūda! Kāds no laukiem nav ievadīts", "Detaļas pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //aizpildīti visi lauki
            {
                //jautājam vai pievienot produktu pie pasūtījuma detaļām
                dr = System.Windows.Forms.MessageBox.Show("Vai pievienot produktu pie pasūtījuma detaļam?", "Produkta pievienošana", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               //Ja lietotājs nospiež "Jā" (Pievienot izvēlēto produktu pie pasūtījuma detāļām) 
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    //pārbaudam ievadīto cenu ( vai atbilst tipam?) 
                    int skaits;
                    bool success = int.TryParse(ProduktaDaudzums.Text, out skaits);
                    if (!success)
                    {
                        System.Windows.Forms.MessageBox.Show("Kļūda! Nepareizi ievadīts skaits", "Detaļas pievienošana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else //cena ir korekta, aizpildam  pasūtījuma jaunas detaļas
                    {
                        detail.product = (Product1.Product)cboProdukti.SelectedItem; //lieotāja izvēlēto produktu pievienojam pie pasūtījuma detaļa 
                        detail.amount = skaits;
                        this.Close(); //aizvēram šī logu
                    } 
                }
            }
        }
    }
}
