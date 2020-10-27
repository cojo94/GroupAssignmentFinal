using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment
{
    interface IAdressBook
    {
        void CreatePerson(Person person);
        void RemovePersonFromList(Person person);
        Person FindPerson(string userInput);
        List<Person> ListAllContacts();
    }
}
