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

namespace WPF_lietotne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    ///Galvena lapa!!!!
    public partial class MainWindow : Window
    {
        private InterfacesImplementation.Implementation1 fi = new InterfacesImplementation.Implementation1();
        string FileName = "..//..//test.bin";
        public MainWindow()  //FORMAS KONSTRUKTORS
        {
            InitializeComponent();  //ATBILD PAR UZZIMĒŠANU (IEBŪVĒTA METODE)
            fi.Reset();
            fi.CreateTestData();
            txtName.Content = "Sveicināti lietotnē!  :) ";
        }
        private void addAll_Click(object sender, RoutedEventArgs e)
        {
            DatuPievienosana p = new DatuPievienosana(fi);  
            p.Show();
        }  //atver logu, kur var izveidot objektus
        private void viewData_Click(object sender, RoutedEventArgs e)
        {
            DatuParskats p = new DatuParskats(fi);
            p.Show();
        }//atver logu, kur ir pasūtījumu pārskats/kolekcijas
        private void editAll_Click(object sender, RoutedEventArgs e)
        {
            DatuRedigesana p = new DatuRedigesana(fi);
            p.Show();
        } //atver logu, kur var rediģēt objektus
        private void deleteIt_Click(object sender, RoutedEventArgs e)
        {
            DatuDzesana dzest = new DatuDzesana(fi);
            dzest.Show();
        } //atver logu, kur var dzēst noteikto objektu
        private void saveIt_Click(object sender, RoutedEventArgs e)
        { 
            fi.Save(FileName);  //izsaucām metodi no 1.mājas darba, kas saglabā objektus filā
            txtName.Content = "Dati veiksmīgi tika saglabāti!";
        }    //saglabā datus failā
        private void loadIt_Click(object sender, RoutedEventArgs e)
        {
            fi.Reset();  //padaram kolekcijas tukšas
            fi.Load(FileName); //izsaucām metodi no 1.mājas darba, kas ielādē objektus filā
            txtName.Content = "Tika ielādeti dati!";
        }    //ielādē datus no faila
    }
}
