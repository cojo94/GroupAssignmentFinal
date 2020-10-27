using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment
{
    class Adressbook : IAdressBook
    {
        public List<Person> AdressBookList = new List<Person>();

        public void CreatePerson(Person person)
        {
            AdressBookList.Add(person);
        }

        public void RemovePersonFromList(Person person)
        {
            AdressBookList.Remove(person);
        }

        public Person FindPerson(string userInput)
        {
            Person person = AdressBookList.Find(f => f.Name == userInput || f.HomeAdress == userInput 
            || f.EmailAdress == userInput || f.PrivatePhoneNumber == userInput || f.WorkPhoneNumber == userInput);

            return person;
        }

        public List<Person> ListAllContacts()
        {
            return AdressBookList;
        }
    }
}
