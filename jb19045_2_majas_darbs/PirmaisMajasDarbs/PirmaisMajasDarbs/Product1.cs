using System;

namespace Product1
{
    [Serializable]
    public class Product
    {
        
        public string Name { get; set; }
        private decimal cena;

        public decimal Price
        {
            get { return cena; }
            set
            {
                string s = String.Format("{0:0.00}", value);  //veidojam jauno skaitli, tips: 2 cīpari aiz komata
                cena = Convert.ToDecimal(s); ;  //piešķiram šo skaili, iepriekš pārveidot
            }
        }
        public override string ToString()
        {
            return Name.ToString() + ", " + Price.ToString() + " EUR";
        }
    }
}
