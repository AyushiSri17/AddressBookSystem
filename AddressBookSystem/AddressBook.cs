using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        List<Contact> list;
        Contact contact;
        public void Details()
        {
            list = new List<Contact>();           
                contact = new Contact();
                Console.WriteLine("Enter first name");
                contact.firstName = Console.ReadLine();
                Console.WriteLine("Enter last name");
                contact.lastName = Console.ReadLine();
                Console.WriteLine("Enter Address");
                contact.address = Console.ReadLine();
                Console.WriteLine("Enter City");
                contact.city = Console.ReadLine(); ;
                Console.WriteLine("Enter State");
                contact.state = Console.ReadLine();
                Console.WriteLine("Enter Zip code");
                contact.zip = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Phone number");
                contact.phoneNumber = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Email");
                contact.email = Console.ReadLine();  
                list.Add(contact);
                //Console.WriteLine(contact);
        } 
        public void Display()
        {
            foreach (Contact contacts in list)
            {
                Console.WriteLine(contacts);
            }
        }

        public void EditContact(String editContact)
        {
            //check the name is present or not
            foreach (var data in list)
            {
                if (editContact.Equals(data.firstName) || editContact.Equals(data.lastName))
                {
                    string repChoice;
                    do
                    {
                        Console.WriteLine("Select one field to edit" + "\n" + "Select 1. FirstName 2. Last Name 3. Address 4. City 5. State 6. Zip 7. PhoneNumber 8. Email ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Enter the First Name");
                                data.firstName = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Enter the Last Name");
                                data.address = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Enter the Address");
                                data.address = Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("Enter the City");
                                data.city = Console.ReadLine();
                                break;
                            case 5:
                                Console.WriteLine("Enter the State ");
                                data.state = Console.ReadLine();
                                break;
                            case 6:
                                Console.WriteLine("Enter the Zip");
                                data.zip = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 7:
                                Console.WriteLine("Enter the PhoneNumber");
                                data.phoneNumber = Convert.ToInt64(Console.ReadLine());
                                break;
                            case 8:
                                Console.WriteLine("Enter the Email");
                                data.email = Console.ReadLine();
                                break;
                        }
                        Console.WriteLine("Do Want Again Edit The contact Y oR N");
                        repChoice =Console.ReadLine().ToUpper();
                    } while (repChoice.Equals("Y"));
                   // Console.WriteLine(contact);
                }
                else
                {
                    Console.WriteLine("Contact not found in AddressBook");
                }
            }
        }
    }
}
