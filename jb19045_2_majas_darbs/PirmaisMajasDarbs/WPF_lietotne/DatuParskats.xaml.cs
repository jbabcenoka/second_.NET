using PirmaisMajasDarbs;
using uzdevums1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_lietotne
{
    /// <summary>
    /// Interaction logic for DatuParskats.xaml
    /// </summary>
    public partial class DatuParskats : Window
    {
        private InterfacesImplementation.Implementation1 testa_dati = new InterfacesImplementation.Implementation1();
        public DatuParskats(IOrderManager fi)
        {
            InitializeComponent();
            testa_dati.CreateTestData();

            testaDati.Text = testa_dati.Print(); //teksta blokā printējam visud datus, kas bija 1.mājas darbā

            var AllOrders = fi.PrintOrders();
            PasutijumiDati.Text = AllOrders;  //printējam pasūtījumus

            var allDarb = fi.PrintDarbiniekus();
            DarbiniekiDati.Text = allDarb;  //printēja, darbiniekus , kas ir person kolekcijā

            var allPasutitaji = fi.PrintPasutitajus();
            PasutitajiDati.Text = allPasutitaji;  //printējam pasūtītājus, kas ir person kolekcijā

            var allProducts = fi.PrintProducts();
            ProduktiDati.Text = allProducts;          //printējam produktus (produktu kolekcijas saturs) 
        } 
    }
}
