using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        public void Details()
        {
            List<Contact> list = new List<Contact>();
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine(); ;
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zip code");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Phone number");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            list.Add(contact);
            Console.WriteLine(contact);
        }
    }
}
