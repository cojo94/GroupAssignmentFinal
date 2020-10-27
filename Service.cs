using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment
{
    class Service
    {
        IDataInput dataInput;
        IAdressBook adressBook;

        public Service(IDataInput data, IAdressBook adressBook)
        {
            dataInput = data;
            this.adressBook = adressBook;
        }

        public void UserChoice()
        {
            switch (dataInput.GetNextAction())
            {
                case Action.Create:
                    adressBook.CreatePerson(dataInput.GetPerson());
                    break;

                case Action.Find:
                    Person person = adressBook.FindPerson(dataInput.Find());
                    dataInput.NullCheck(person);
                    dataInput.PersonInformation(person);
                    break;

                case Action.ListAll:
                    dataInput.ReturnAllContacts(adressBook.ListAllContacts());
                    break;

                case Action.Delete:
                    Person person1 = adressBook.FindPerson(dataInput.Delete());
                    dataInput.NullCheck(person1);
                    adressBook.RemovePersonFromList(person1);
                    break;

                case Action.Edit:
                    Person person2 = adressBook.FindPerson(dataInput.Edit());
                    EditPerson(person2);
                    break;
            }
        }

        public void EditPerson(Person person)
        {
            dataInput.NullCheck(person);
            if (person != null)
            {
                switch (dataInput.WhatToEdit(person))
                {
                    case EditAction.Name:
                        dataInput.ChangeName(person);
                        break;

                    case EditAction.Email:
                        dataInput.ChangeEmail(person);
                        break;

                    case EditAction.HomeAdress:
                        dataInput.HomeAdress(person);
                        break;

                    case EditAction.PrivatePhone:
                        dataInput.PrivatePhoneNumber(person);
                        break;

                    case EditAction.WorkPhone:
                        dataInput.WorkPhoneNumber(person);
                        break;
                }
            }
        }
    }
}
