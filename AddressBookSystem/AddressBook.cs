using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                    Console.WriteLine("State:" + contact.state);
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

        public void SearchAPersonByCityOrState()
        {
            //Console.Clear();
            Console.WriteLine("Select option for search");
            Console.WriteLine("1.Search Person In City\n2.Search Person In State\n");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter that City name where you want to search the person  ");
                    string cityName = Console.ReadLine();
                    Console.WriteLine("Enter person name whom you want to search in City ");
                    string cityPersonName = Console.ReadLine();
                    foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
                    {
                        Console.WriteLine("Address Book Name: " + keyValue.Key);
                        foreach (Contact contact in keyValue.Value)
                        {
                            if (list.Any(s => contact.city.ToLower() == cityName.ToLower() && contact.firstName.ToLower() == cityPersonName.ToLower()))
                            {
                                Console.WriteLine("The Contact Details of person "+cityPersonName+" living in " + cityName + " are:\nFirstName: " + contact.firstName + "\nLastName: " + contact.lastName + " \nZipcode: " + contact.zip + "\nPhoneNumber: " + contact.phoneNumber);
                            }
                        }
                    }
                    Console.WriteLine("Person With Name {0} is not found in the AddressBook in City {1}", cityPersonName, cityName);
                    break;
                case 2:
                    Console.WriteLine("Enter the state name where you want to search the person  ");
                    string stateName = Console.ReadLine();
                    Console.WriteLine("Enter person name whom you want to search in State ");
                    string statePersonName = Console.ReadLine();
                    foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
                    {
                        Console.WriteLine("Address Book Name: " + keyValue.Key);
                        foreach (Contact contact in keyValue.Value)
                        {
                            if (list.Any(s => contact.state.ToLower() == stateName.ToLower() && contact.firstName.ToLower() == statePersonName.ToLower()))
                            {
                                Console.WriteLine("The Contact Details of person " + statePersonName + " living in " + stateName + " are:\nFirstName: " + contact.firstName + "\nLastName: " + contact.lastName + " \nZipcode: " + contact.zip + "\nPhoneNumber: " + contact.phoneNumber);
                            }
                        }
                    }
                    Console.WriteLine("Person With Name {0} is not found in the AddressBook in State {1}", statePersonName, stateName);
                    break;
                default:
                    Console.WriteLine("select only valid options");
                    break;
            }
        }

        public void ViewPersonByCityOrState()
        {
            //Console.Clear();
            Console.WriteLine("Select option for search");
            Console.WriteLine("1.Search Contact In City\n2.Search Contact In State\n");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter that City name where you want to search the person  ");
                    string cityName = Console.ReadLine();
                    foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
                    {
                        Console.WriteLine("Address Book Name: " + keyValue.Key);
                        foreach (Contact contact in keyValue.Value)
                        {
                            if (list.Any(s => contact.city.ToLower() == cityName.ToLower()))
                            {
                                Console.WriteLine("\nThe Contact Details of persons living in " + cityName + " are:\nFirstName: " + contact.firstName + "\nLastName: " + contact.lastName + " \nZipcode: " + contact.zip + "\nPhoneNumber: " + contact.phoneNumber);
                            }
                        }
                    }
                    Console.WriteLine("Person living {0} is not found in the AddressBook ", cityName);
                    break;
                case 2:
                    Console.WriteLine("Enter the state name where you want to search the person  ");
                    string stateName = Console.ReadLine();
                    
                    foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
                    {
                        Console.WriteLine("Address Book Name: " + keyValue.Key);
                        foreach (Contact contact in keyValue.Value)
                        {
                            if (list.Any(s => contact.state.ToLower() == stateName.ToLower()))
                            {
                                Console.WriteLine("\nThe Contact Details of person  living in " + stateName + " are:\nFirstName: " + contact.firstName + "\nLastName: " + contact.lastName + " \nZipcode: " + contact.zip + "\nPhoneNumber: " + contact.phoneNumber);
                            }
                        }
                    }
                    Console.WriteLine("Persons living {0} is not found in the AddressBook ", stateName);
                    break;
                default:
                    Console.WriteLine("select only valid options");
                    break;
            }
        }

        public void CountPersonByCityOrState()
        {
            //Console.Clear();
            Console.WriteLine("Select option for search");
            Console.WriteLine("1.Count Person In City\n2.Count Person In State\n");
            int count = 0;
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter that City name where you want to search the person  ");
                    string cityName = Console.ReadLine();
                    foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
                    {
                        foreach (Contact contact in keyValue.Value)
                        {
                            if (list.Any(s => contact.city.ToLower() == cityName.ToLower()))
                            {
                                count++;
                            }
                        }
                    }
                    Console.WriteLine("Total number of contact in " + cityName + " is "+count);
                    break;
                case 2:
                    Console.WriteLine("Enter the state name where you want to search the person  ");
                    string stateName = Console.ReadLine();
                    foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
                    {
                        foreach (Contact contact in keyValue.Value)
                        {
                            if (list.Any(s => contact.state.ToLower() == stateName.ToLower()))
                            {
                                count++;
                            }
                        }
                    }
                    Console.WriteLine("Total number of contact in " + stateName + " is " + count);
                    break;
                default:
                    Console.WriteLine("select only valid options");
                    break;
            }
        }
        public void SortingByPersonName()
        {
            foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
            {
                Console.WriteLine("AddressBook Name: " + keyValue.Key);
                Console.WriteLine("\nDisplaying the person details\n");
                var data=keyValue.Value.OrderBy(x=>x.firstName.ToLower()).ToList();
                foreach (var result in data)
                {
                    Console.WriteLine(result);
                    Console.WriteLine("\n");
                }
            }
        }
        public void SortByCityOrState()
        {
            Console.WriteLine("Select option for sorting");
            Console.WriteLine("1. Sort Contact By City\n2. Sort Contact By State\n3. Sort Contact By Zip ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
                    {
                        Console.WriteLine("AddressBook Name: " + keyValue.Key);
                        Console.WriteLine("\nDisplaying the person details\n");
                        var data = keyValue.Value.OrderBy(x => x.city.ToLower()).ToList();
                        foreach (var result in data)
                        {
                            Console.WriteLine(result);
                            Console.WriteLine("\n");
                        }
                    }
                    break;
                case 2:
                    foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
                    {
                        Console.WriteLine("AddressBook Name: " + keyValue.Key);
                        Console.WriteLine("\nDisplaying the person details\n");
                        var data = keyValue.Value.OrderBy(x => x.state.ToLower()).ToList();
                        foreach (var result in data)
                        {
                            Console.WriteLine(result);
                            Console.WriteLine("\n");
                        }
                    }
                    break;
                case 3:
                    foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
                    {
                        Console.WriteLine("AddressBook Name: " + keyValue.Key);
                        Console.WriteLine("\nDisplaying the person details\n");
                        var data = keyValue.Value.OrderBy(x => x.zip).ToList();
                        foreach (var result in data)
                        {
                            Console.WriteLine(result);
                            Console.WriteLine("\n");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Select the correct option");
                    break;
            }
        }
        public void WriteAndReadContactsIntoFile()
        {
            string path = @"C:\Users\Ayushi\source\repos\AddressBookSystem\AddressBookSystem\ContactDetails.txt";
            //Writing data into file
            StreamWriter writer = new StreamWriter(path);
            foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
            {
                foreach (Contact data in keyValue.Value)
                {
                    writer.WriteLine(data);  
                }
            }
            writer.Close();//Closing resources
            //Reading data from file
            StreamReader reader = new StreamReader(path);
            Console.WriteLine(reader.ReadToEnd());
            Console.ReadLine();
            reader.Close();//Closing resouces
        }
        public void WriteAndReadContactsAsCSVFile()
        {
            //Writing data into file
            string csvFilePath = @"C:\Users\Ayushi\source\repos\AddressBookSystem\AddressBookSystem\ContactDetails.csv";
            StreamWriter writer = new StreamWriter(csvFilePath);
            CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            foreach (KeyValuePair<string, List<Contact>> keyValue in contactDictionary)
            {                
                    csvWriter.WriteRecords(keyValue.Value);
            }
            //csvWriter.WriteRecords(list);//it will print last addressBook values
            writer.Close();
            //Reading data from file
            StreamReader streamReader = new StreamReader(csvFilePath);
            CultureInfo culture = CultureInfo.InvariantCulture;
            CsvReader reader = new CsvReader(streamReader, culture);
            reader.GetRecords<Contact>().ToList();
        }
        public void WriteAndReadContactsAsJSONFile()
        {
            //Writing data into file
            string jsonFilePath = @"C:\Users\Ayushi\source\repos\AddressBookSystem\AddressBookSystem\ContactDetails.json";
            string jasonData = JsonConvert.SerializeObject(contactDictionary);
            File.WriteAllText(jsonFilePath, jasonData);
            //Reading data from file
            string jasonDataRead = File.ReadAllText(jsonFilePath);
            JsonConvert.DeserializeObject(jasonDataRead);
            //List<Contact> lists = JsonConvert.DeserializeObject<List<Contact>>(jasonDataRead);
        }
    }
}
