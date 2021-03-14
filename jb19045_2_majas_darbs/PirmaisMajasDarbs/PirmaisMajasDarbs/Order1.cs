using System;
using Customer1;
using Employee1;
using Product1;
using OrderDetail1;
using System.Collections.Generic;

namespace Order1
{
    
    public enum states  // pasūtījuma apraksts, sākumā jābūt New
    {
        New,
        Completed,
        Canceled,
        AwaitingPayment,
        Pending,
        AwaitingPickup
    };

    [Serializable]
    public class Order : Product
    {
        static private string pasutijumaNumurs = "0"; //veidojot pirmo pasūtījumu, pasūtījuma numura nav
        //static šeit tiek izmantots, lai ģenerētu unikālo pasūtījuma numuru. Šī vērība vienlīdzīgi pieder visiem objektiem

        public Order(DateTime pasutDate1, states States1)  //konstruktors ar parametriem
        {
            State = States1;
            pasutDate = pasutDate1;
            int pasutN = Int32.Parse(pasutijumaNumurs); //tā kā pasūtījuma numurs jābūt teksts, pārveidojam viņu uz integeru
            pasutN++; //palielinam par 1
            string tmp = Convert.ToString(pasutN); //konvertējam atpakaļ uz tekstu
            pasutijumaNumurs = tmp;
        }
        public Order()  //konstruktors bez parametriem, bet uzstādā noklūsētas vērtības
        {
            State = states.New; //veidjot jaunu pasūtījumu jāuzstādā vertība New
            pasutDate = DateTime.Now; //ja datums netika norādīts sākuma => piešķiram sistēmas datumu
            int pasutN = Int32.Parse(pasutijumaNumurs);
            pasutN++;
            string tmp = Convert.ToString(pasutN);
            pasutijumaNumurs = tmp;
        }

        public string Number
        {
            get { return pasutijumaNumurs; } //pasūtījuma numuru drīkt tikai lasīt
        }

        private DateTime pasutDate;

        public DateTime OrderDate
        {
            get { return pasutDate; }
            set { pasutDate = value; }
        }

        private states state1; //ar tipu enum State
        public states State
        {
            get { return state1; }
            set { state1 = value; }  // sākumā tas ir New(jauns) pasūtījums
        }

        public Customer Customer { get; set; }
        public Employee ResponsibleEmployee { get; set; }

        public void addProduct(string name, decimal price, int Amount)
        {
            OrderDetail Details = new OrderDetail(); //viedojam objektu - pasūtījuma detaļas
            Product newprodukts = new Product();  //veidojam produktu
            newprodukts.Name = name;
            newprodukts.Price = price;
            Details.product = newprodukts;  //pievienotjam pasūtījuma detaļam jauno produktu
            Details.amount = Amount;  //pievienojam attiecīgo pasūtījuma produkta daudzumu
            if(this.Details !=null ) this.Details.Add(Details);   //pievienojam pie visām pasūtījuma detaļām jauno pasūtījumu detaļu
            else
            {
                throw new System.ArgumentException("Vēl nav izveidots saraksts!!!!");
            }
         }
        public List<OrderDetail> Details { get; set; }  //visas pasūtījuma detaļas ar produktiem


        public override string ToString()
        {
            return "Numurs: " + pasutijumaNumurs.ToString() +
                    "\nDatums: " + pasutDate.ToString("dd/MM/yyyy") 
                        + "\nStavoklis: " + State.ToString();

        }

    }
}
