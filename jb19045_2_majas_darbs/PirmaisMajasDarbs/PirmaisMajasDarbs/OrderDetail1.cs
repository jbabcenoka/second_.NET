using System;
using Product1;

namespace OrderDetail1
{
    [Serializable]  
    public class OrderDetail
    {
        public Product product { get; set; }
        public decimal amount { get; set; }
    }
}
