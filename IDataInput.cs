using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment
{
    interface IDataInput
    {
        Action GetNextAction();
        EditAction WhatToEdit(Person person);
        void ReturnAllContacts(List<Person> people);
        Person GetPerson();
        string Delete();
        string Edit();
        string Find();
        void PersonInformation(Person person);
        void NullCheck(Person person);
        string CheckIfValidPhoneNumber(string phoneNumber);
        Person ChangeName(Person person);
        Person ChangeEmail(Person person);
        Person HomeAdress(Person person);
        Person PrivatePhoneNumber(Person person);
        Person WorkPhoneNumber(Person person);
    }
}
