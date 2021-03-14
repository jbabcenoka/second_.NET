using System;
using Employee1;
using Customer1;
using Product1;
using Order1;
using OrderDetail1;
using InterfacesImplementation;
using System.Collections.Generic;


namespace uzdevums1
{
    [Serializable]
    class MainProgram 
    {
        static void Main(string[] args)
        {
            void PrintOrder(Order pasutijums)  //parasta metode, lai printētu info par objektu
            {
                Console.WriteLine("         Info par pasutijumu:\n" + pasutijums.ToString());
                Console.WriteLine("\n         Pasutitajs:\n" + pasutijums.Customer.ToString());
                Console.WriteLine("\n         Atbildigais darbinieks:\n" + pasutijums.ResponsibleEmployee.ToString());
                Console.WriteLine("\n         Pasutijuma produkti:");
                foreach (OrderDetail i in pasutijums.Details)
                {
                    Console.WriteLine(i.product.Name.ToString() + ", "
                        + i.product.Price.ToString() + " EUR, skaits:  "
                        + i.amount.ToString());
                }
            }

            Console.WriteLine("Parasta objektu darbiba NO MAIN clases :) \n");
            //Izmantojot Order konstruktoru AR parametriem
            Console.WriteLine("-------------------------------------------------\n");
            Console.WriteLine("Pirmais pasutijums :) \n");
            DateTime dt1_1 = new DateTime(2020, 08, 10);  //pasutijuma datums
            DateTime dt1_2 = new DateTime(2019, 05, 17);  //datums darbinieka ligumam
            Order pasutijums = new Order(dt1_1, states.Canceled);  //veidojam objektu - jauno pasūtījumu ar uzstādītiem parametriem
            var customer1 = new Customer(); //veidojam objektu - pasūtījuma pasūtītāju
            customer1.Name = "Karlis";
            customer1.Surname = "Broks";
            customer1.EMail = "kb@gmail";
            pasutijums.Customer = customer1; //piešķiram izveidoto pasūtītāju
            var respEmpl1 = new Employee(); //veidojam objektu - pasūtījuma atbildīgo darbinieku
            respEmpl1.Name = "Maris";
            respEmpl1.Surname = "Podnieks";
            respEmpl1.EMail = "mp@gmail";
            respEmpl1.AgreementDate = dt1_2;
            respEmpl1.AgreementNr = "45";
            pasutijums.ResponsibleEmployee = respEmpl1;  //piešķiram izveidoto atbildīgo darbinieku
            // produkts(name,price) => orderDetails(ieprieksais produkts, amaunt) => saraksts no orderDetails pasūtījumā(Order klas)
            Product produkts1_1 = new Product();  //veidojam atbilstošo objektu - produktu, kas ir atbilstošajā pasūtījumā
            produkts1_1.Name = "Lenovo Yoga Slim 7";
            produkts1_1.Price = 969.99M;   //ja ievadīt, piemērām 969.9, tad piešķirs vienalga 969.90!
            Product produkts1_2 = new Product(); //veidojam otro produktu
            produkts1_2.Name = "Apple MacBook Air 2020";
            produkts1_2.Price = 1519.40M;
            Product produkts1_3 = new Product(); //veidojam treso produktu
            produkts1_3.Name = "ThinkPad X1";
            produkts1_3.Price = 2170.90M; 
            OrderDetail Details1_1 = new OrderDetail();  //veidojam pasūtījuma detaļas objektu(OrderDetails ir saraksts Order klasē)
            Details1_1.product = produkts1_1; //piešķiram pasūtījuma detaļai 1. produktu(uzreiz tajā ir kads nosaukums, cena) un skaitu
            Details1_1.amount = 3;
            OrderDetail Details1_2 = new OrderDetail();  //veidojam otro pasūtījuma detaļas objektu
            Details1_2.product = produkts1_2;  //piešķiram pasūtījuma detaļai 2. produktu
            Details1_2.amount = 5;
            OrderDetail Details1_3 = new OrderDetail();  //veidojam otro pasūtījuma detaļas objektu
            Details1_3.product = produkts1_3;  //piešķiram pasūtījuma detaļai 3. produktu
            Details1_3.amount = 2;
            List<OrderDetail> DetalasList = new List<OrderDetail>();  //veidojam sarakstu kur būs visi produkti un viņu skaits
            pasutijums.Details = DetalasList; 
            DetalasList.Add(Details1_1);
            DetalasList.Add(Details1_2);
            DetalasList.Add(Details1_3);
            pasutijums.addProduct("Asus ZenBook 14", 849M, 5);  //pievienojam produktu izmantojot metodi 
            pasutijums.addProduct("Dell Vostro 14 ", 546.34M, 3);
            //pirmā pasūtījuma izvads
            PrintOrder(pasutijums);


            Console.WriteLine("\n-------------------------------------------------\n");
            Console.WriteLine("Otrais pasutijums :) \n");
            //Izmantojot Order konstruktoru BEZ uzstadītiem parametriem
            Order pasutijums2 = new Order();
            DateTime dt2_1 = new DateTime(2020, 03, 01);  //datums pasutijumam
            DateTime dt2_2 = new DateTime(2019, 06, 01);  //datums darbinieka ligumam
            pasutijums2.OrderDate = dt2_1; //piešķiram datumu, jo kontrukotrs nepieškir
            pasutijums2.State = states.AwaitingPayment; //izvēlējamies stāvokli
            var customer2 = new Customer(); //veidojam objektu - pasūtījuma pasūtītāju
            customer2.Name = "Niklavs";
            customer2.Surname = "Grudulis";
            customer2.EMail = "ng@gmail";
            pasutijums2.Customer = customer2; //piešķiram izveidoto pasūtītāju
            var respEmpl2 = new Employee(); //veidojam objektu - pasūtījuma atbildīgo darbinieku
            respEmpl2.Name = "Marta";
            respEmpl2.Surname = "Kesane";
            respEmpl2.EMail = "mk@gmail";
            respEmpl2.AgreementDate = dt2_2;
            respEmpl2.AgreementNr = "56";
            pasutijums2.ResponsibleEmployee = respEmpl2;  //piešķiram izveidoto atbildīgo darbinieku
            Product produkts2_1 = new Product(); //veidojam treso produktu
            produkts2_1.Name = "Lenovo IdeaPad Gaming 3";
            produkts2_1.Price = 837.90M;
            Product produkts2_2 = new Product(); //veidojam treso produktu
            produkts2_2.Name = "Acer Swift 7";
            produkts2_2.Price = 2170.90M;
            OrderDetail Details2_1 = new OrderDetail();  //veidojam pasūtījuma detaļas objektu(OrderDetails ir saraksts Order klasē)
            Details2_1.product = produkts2_1; //piešķiram pasūtījuma detaļai 1. produktu(uzreiz tajā ir kads nosaukums, cena) un skaitu
            Details2_1.amount = 1;
            OrderDetail Details2_2 = new OrderDetail();  //veidojam pasūtījuma detaļas objektu(OrderDetails ir saraksts Order klasē)
            Details2_2.product = produkts2_2; //piešķiram pasūtījuma detaļai 2. produktu(uzreiz tajā ir kads nosaukums, cena) un skaitu
            Details2_2.amount = 9;
            List<OrderDetail> DetalasList2 = new List<OrderDetail>();  //veidojam sarakstu kur būs visi produkti un viņu skaits
            pasutijums2.Details = DetalasList2;
            pasutijums2.addProduct("Dell Latitude 13", 1579.99M, 2); //iet VIENMĒR AIZ DetalasList izveidosanas, jo nevar pievienot, kamēr nav saraksta
            DetalasList2.Add(Details2_1);
            DetalasList2.Add(Details2_2);
            //otrā pasūtījuma izvads
            PrintOrder(pasutijums2);


            Console.WriteLine("\n-------------------------------------------------\n");
            Console.WriteLine("Tresais pasutijums :) \n");
            //Izmantojot Order konstruktoru BEZ uzstadītiem parametriem
            Order pasutijums3 = new Order();
            DateTime dt3_1 = new DateTime(2020, 04, 02);  //datums pasutijumam
            DateTime dt3_2 = new DateTime(2019, 06, 01);  //datums darbinieka ligumam
            pasutijums3.OrderDate = dt3_1; //piešķiram datumu, jo kontrukotrs nepieškir
            pasutijums3.State = states.AwaitingPickup; //izvēlējamies stāvokli
            var customer3 = new Customer(); //veidojam objektu - pasūtījuma pasūtītāju
            customer3.Name = "Pauls";
            customer3.Surname = "Kaimins";
            customer3.EMail = "pk@gmail";
            pasutijums3.Customer = customer3; //piešķiram izveidoto pasūtītāju
            var respEmpl3 = new Employee(); //veidojam objektu - pasūtījuma atbildīgo darbinieku
            respEmpl3.Name = "Eduards";
            respEmpl3.Surname = "Cakste";
            respEmpl3.EMail = "mk@gmail";
            respEmpl3.AgreementDate = dt3_2;
            respEmpl3.AgreementNr = "98";
            pasutijums3.ResponsibleEmployee = respEmpl3;  //piešķiram izveidoto atbildīgo darbinieku
            Product produkts3_1 = new Product(); //veidojam treso produktu
            produkts3_1.Name = "Lenovo ThinkPad X13";
            produkts3_1.Price = 1031M;
            OrderDetail Details3_1 = new OrderDetail();  //veidojam pasūtījuma detaļas objektu(OrderDetails ir saraksts Order klasē)
            Details3_1.product = produkts3_1; //piešķiram pasūtījuma detaļai 1. produktu(uzreiz tajā ir kads nosaukums, cena) un skaitu
            Details3_1.amount = 7;
            List<OrderDetail> DetalasList3 = new List<OrderDetail>();  //veidojam sarakstu kur būs visi produkti un viņu skaits
            pasutijums3.Details = DetalasList3;
            DetalasList3.Add(Details3_1);
            pasutijums3.addProduct("HP ZBook 15v", 1855.99M, 7);
            //trešā pasūtījuma izvads
            PrintOrder(pasutijums3);
        }

    }
}
