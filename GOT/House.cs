using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT
{
    
    class House
    {
        private Person head;
        private int numberOfPersons;
        private string name;
        public string Name { get { return name; } }
        public int NumberOfPersons { get { return numberOfPersons; } }
        private ProductPreference preference;
        public ProductPreference Preference { get { return preference; } }


        public House(ProductPreference preference, string name)
        {
            this.preference = preference;
            this.name = name;
        }

        public void InsertPerson(string Name)
        {
            if(head == null)
            {
                numberOfPersons = 1;
            }
            else
            {
                numberOfPersons++;
            }
            Person uj = new Person();
            uj.Name = Name;
            uj.Next = head;
            head = uj;
        }
        public void iterate()
        {
            Person p = head;
            while(p != null)
            {
                Console.WriteLine(p.Name);
                p = p.Next;
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public Person Next { get; set; }
        
    }
    class ProductPreference
    {
        private List<Type> Preference;
        private int requiredQuantity;

        public ProductPreference(List<Type> Preference, int requiredQuantity)
        {
            this.Preference = Preference;
            this.requiredQuantity = requiredQuantity;
        }

        public List<Type> PreferredProduct { get { return Preference; } }
        public int RequiredQuantity { get { return requiredQuantity; } }
    }
    
    
}
