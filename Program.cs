using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment
{
    class Program
    {
        private static Adressbook Adressbook = new GroupAssignment.Adressbook();

        static void Main(string[] args)
        {
            IAdressBook adressBook = new Adressbook();
            IDataInput dataInput = new DataInput();
            Service service = new Service(dataInput, adressBook);

            bool programIsRunning = true;
            while (programIsRunning)
            {
                service.UserChoice();
            }
            Console.ReadLine();
        }
    }
}
