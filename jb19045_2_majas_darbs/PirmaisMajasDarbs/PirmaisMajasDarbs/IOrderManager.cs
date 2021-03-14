using Employee1;
using Order1;
using Person1;
using Product1;
using System;
using System.Collections.Generic;
using System.Text;


namespace PirmaisMajasDarbs
{
    public interface IOrderManager 
    {
        void AddOrder(Order o);
        void AddProduct(Product p);
        void AddProduct(string name, decimal price, int Amount);
        void AddPerson(Person p);
        string Print();
        string PrintOrders();
        string PrintProducts();
        string PrintPeople();

        
        string PrintPasutitajus();

        string PrintDarbiniekus();
        IEnumerable<Order> GetOrders();
        IEnumerable<Person> GetPersons();
        IEnumerable<Product> GetProducts();

        void DeleteCustomer(Customer1.Customer cust);
        void DeleteEmployee(Employee1.Employee empl);
        void DeleteProduct(Product1.Product product);



    }
}
