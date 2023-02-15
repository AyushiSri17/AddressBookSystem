﻿using System;
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
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. Create Contact \n2. Edit Contact \n3. Delete Contact \n4. Exit");
                int select = Convert.ToInt32(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        addressBook.Details();
                        addressBook.Display();
                        break;
                    case 2:
                        addressBook.Details();
                        addressBook.Display();
                        Console.WriteLine("Enter the name of the person whose contact details you want to edit");
                        string name = Console.ReadLine();
                        addressBook.EditContact(name);
                        addressBook.Display();
                        break;
                    case 3:
                        addressBook.Details();
                        addressBook.Display();
                        Console.WriteLine("Enter the name of the person whose contact details you want to delete");
                        string pname = Console.ReadLine();
                        addressBook.DeleteContact(pname);
                        addressBook.Display();
                        break;
                    case 4:
                        flag = false;
                        Console.WriteLine("Exist");
                        break;
                    default:
                        Console.WriteLine("Please choose the correct option");
                        break;
                }
            }
        }
    }
}
