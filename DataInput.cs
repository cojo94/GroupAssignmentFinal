using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment
{
    public enum Action { Create = 1, Edit = 2, Delete = 3, Find = 4, ListAll = 5, Invalid }
    public enum EditAction { Name = 1, Email = 2, HomeAdress = 3, PrivatePhone = 4, WorkPhone = 5, Invalid }
    class DataInput : IDataInput
    {
        public Action GetNextAction()
        {
            Console.WriteLine("What do you want to do?\n1. Create New Contact\n2. Edit Contact\n3. Remove Contact\n4. Find Person" +
                " \n5. List All Contacts\nType 'x' and 'Enter' to close the application.");
            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    return Action.Create;

                case "2":
                    return Action.Edit;

                case "3":
                    return Action.Delete;

                case "4":
                    return Action.Find;

                case "5":
                    return Action.ListAll;

                case "x":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }
            return Action.Invalid;
        }

        public Person GetPerson()
        {
            Console.WriteLine("Enter Name:");
            var name = Console.ReadLine().ToLower();

            Console.WriteLine("Enter Private Phone Number:");
            var privatePhoneString = Console.ReadLine();

            Person person = new Person(name, CheckIfValidPhoneNumber(privatePhoneString));
            Console.WriteLine("New contact created! If you want to add additional information to your contact, please choose Edit.");
            return person;
        }

        public string Delete()
        {
            Console.WriteLine("Who do you want to delete?");
            var userInput = Console.ReadLine().ToLower();
            return userInput;
        }

        public string Edit()
        {
            Console.WriteLine("Who do you want to edit?");
            var userInput = Console.ReadLine().ToLower();
            return userInput;
        }

        public string Find()
        {
            Console.WriteLine("Search for contact Name, Email or Adress to find a contact that matches that information:");
            var userInput = Console.ReadLine().ToLower();
            return userInput;
        }

        public EditAction WhatToEdit(Person person)
        {
            Console.WriteLine($"What do you want to edit?\n1. {person.Name}'s Name\n2. {person.Name}'s Email Adress" +
                $"\n3. {person.Name}'s Home Adress\n4. {person.Name}'s Private Phone Number\n5. {person.Name}'s Work Phone Number");

            var userInput1 = Console.ReadLine();
            switch (userInput1)
            {
                case "1":
                    return EditAction.Name;

                case "2":
                    return EditAction.Email;

                case "3":
                    return EditAction.HomeAdress;

                case "4":
                    return EditAction.PrivatePhone;

                case "5":
                    return EditAction.WorkPhone;

                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
            return EditAction.Invalid;
        }

        public Person ChangeName(Person person)
        {
            Console.WriteLine("Enter the updated Name:");
            var newName = Console.ReadLine().ToLower();
            person.Name = newName;
            return person;
        }

        public Person ChangeEmail(Person person)
        {
            Console.WriteLine("Enter the updated Email:");
            var newEmail = Console.ReadLine().ToLower();
            person.EmailAdress = newEmail;
            return person;
        }

        public Person HomeAdress(Person person)
        {
            Console.WriteLine("Enter the updated Home Adress:");
            var newHomeAdress = Console.ReadLine().ToLower();
            person.HomeAdress = newHomeAdress;
            return person;
        }

        public Person PrivatePhoneNumber(Person person)
        {
            Console.WriteLine("Enter the updated Private Phone Number:");
            var newPrivatePhone = Console.ReadLine();
            person.PrivatePhoneNumber = CheckIfValidPhoneNumber(newPrivatePhone);
            return person;
        }

        public Person WorkPhoneNumber(Person person)
        {
            Console.WriteLine("Enter the updated Work Phone Number:");
            var newWorkPhone = Console.ReadLine();
            person.WorkPhoneNumber = CheckIfValidPhoneNumber(newWorkPhone);
            return person;
        }

        public void PersonInformation(Person person)
        {
            if (person != null)
            {
                Console.WriteLine($"Name: {person.Name}\nEmail: {person.EmailAdress}\nHome Adress: {person.HomeAdress}\n" +
                    $"Private Phone: {person.PrivatePhoneNumber}\nWork Phone: {person.WorkPhoneNumber}");
                Console.ReadLine();
            }
        }

        public void ReturnAllContacts(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.Name}\nEmail: {person.EmailAdress}\nHome Adress: {person.HomeAdress}\n" +
                    $"Private Phone: {person.PrivatePhoneNumber}\nWork Phone: {person.WorkPhoneNumber}");
            }
        }

        public void NullCheck(Person person)
        {
            if (person == null)
            {
                Console.WriteLine("This person does not exist!");
            }
        }

        public string CheckIfValidPhoneNumber(string phoneNumber)
        {
            if(!Int32.TryParse(phoneNumber, out int checkIfValid))
            {
                while (true)
                {
                    Console.WriteLine("Please enter a valid Phone Number!");
                    phoneNumber = Console.ReadLine();
                    if (Int32.TryParse(phoneNumber, out checkIfValid))
                    {
                        break;
                    }
                }
            }
            return phoneNumber;
        }
    }
}
