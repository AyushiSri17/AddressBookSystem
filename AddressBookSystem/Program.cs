using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System");
            AddressBook addressBook=new AddressBook();
            addressBook.Details();
            Console.ReadLine();
        }
    }
}
