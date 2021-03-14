using System;
using Person1;

namespace Employee1
{
    [Serializable]
    public class Employee : Person  //darbinieks manto personu
    {
        
        public DateTime AgreementDate { get; set; }
        public string AgreementNr { get; set; }

        public override string ToString()
        {
            return base.ToString() + "\nLiguma datums: " + AgreementDate.ToString("dd/MM/yyyy") + "\nLiguma numurs: " + AgreementNr.ToString();
        }

        

    }
}
