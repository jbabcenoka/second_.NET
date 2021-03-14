using System;

namespace Person1
{
    [Serializable]
    abstract public class Person
    {
        public string Name { get; set; }  // īpašība priekš vārda
        public string Surname { get; set; } //īpašība priekš uzvārda

        public string FullName   //lasāma īpašība, atgriež vārda un uzvārda konkatināciju
        {
            get { return Name + " " + Surname; }
        }

        private string Email;
        public string EMail  //email
        {
            set
            {
                 if (value.Contains("@"))  //ja emailā ir @
                  {
                    if (value.Length >= 3)  //ja emaila garums ir mazāk par 3 ir kļūda
                    {
                        if (value.IndexOf('@') != 0 && value.IndexOf('@') != (value.Length - 1))  //ja @ nav pirmais vai pēdējais
                        {
                            Email = value;

                        }
                    }
                 }
                

            }
            get { return Email;  }
        }
        public override string ToString()
        {
            return "Vards un uzvards: " + FullName.ToString() + "\nEmail: " + Email.ToString();
        }
    }

}
