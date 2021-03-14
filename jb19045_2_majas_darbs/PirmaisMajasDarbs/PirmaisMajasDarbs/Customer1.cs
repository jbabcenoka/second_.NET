using System;
using Person1;


namespace Customer1
{
    [Serializable]
    public class Customer : Person  //pasūtītājs manto personu
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
