using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        public List<Contact> list = new List<Contact>();
        public Dictionary<string, List<Contact>> contactDictionary = new Dictionary<string, List<Contact>>();
        Contact contact;
        public void Details()
        {
            Console.WriteLine("Enter the Number of AddressBook do you want to make");
            int numAddressBook = Convert.ToInt32(Console.ReadLine());
            string addressBookName;
            int num = 0;
            while (num < numAddressBook)
            {
             Console.WriteLine("Enter addressbook name to add contacts");
             addressBookName = Console.ReadLine();
             Console.WriteLine("Enter the number of Contact want to add in {0} AddressBook",addressBookName);
            int n = Convert.ToInt32(Console.ReadLine());
            list = new List<Contact>();
            for (int i = 0; i < n; i++)
            {
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
                contactDictionary.Add(addressBookName, list);
                num++;
            }
        }

        public void DisplayAdressBook()
        {
            foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
            {
                Console.WriteLine("AddressBook Name: "+ keyValue.Key);
                Console.WriteLine("\nDisplaying the person details\n");
                foreach (Contact contact in keyValue.Value)
                {
                    Console.WriteLine("First Name:" + contact.firstName);
                    Console.WriteLine("Last Name:" + contact.lastName);
                    Console.WriteLine("Adress:" + contact.address);
                    Console.WriteLine("City:" + contact.city);
                    Console.WriteLine("Zip Code:" + contact.zip);
                    Console.WriteLine("Phone Number:" + contact.phoneNumber);
                    Console.WriteLine("Email:" + contact.email);
                    Console.WriteLine("\n");
                }
            }
        }
        public void Display()
        {
            foreach (Contact contacts in list)
            {
                Console.WriteLine(contacts);
            }
        }

        public void EditContact(string editContact)
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

        public void DeleteContact(string delectContact)
        {
            foreach (var data in list)
            {
                if (delectContact.Equals(data.firstName) || delectContact.Equals(data.lastName))
                {
                    Console.WriteLine("Contact matched");
                    list.Remove(data);
                    Console.WriteLine("Contact deleted");
                    break;
                }
                else
                {
                    Console.WriteLine("Contact doesn't exist");
                }
            }
        }
        public void CheckDuplicateEntryOfAContact()
        {
            Console.WriteLine("Enter first name to which you want to  check duplicate entry ");
            string name = Console.ReadLine();
            bool isFound = false;
                foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
                {
                    //Console.WriteLine("AddressBook Name: " + keyValue.Key);
                    //Console.WriteLine("\nDisplaying the person details\n");
                    foreach (Contact contact in keyValue.Value)
                    {
                   // bool check = list.Any(s => name.ToLower()== contact.firstName.ToLower());//present in IEnumerable and determines whether the sequence satisfies a condition or not
                    if (list.Any(s => name.ToLower() == contact.firstName.ToLower()))
                        {
                            Console.WriteLine("person named {0} is aleady present in address book {1}",name, keyValue.Key);
                            isFound = true;
                            break;
                        }
                    }
                }
              if (isFound == false) 
                Console.WriteLine("contact does not Exists");
        }

    }
}
