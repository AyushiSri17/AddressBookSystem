using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class Contact
    {
        private string firstName, lastName, address, city, state, email;
        private int zip;
        private long phoneNumber;
        
        public Contact(string firstName,string lastName,string address,string city,string state,int zip,long phoneNumber,string email) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
        public string getFirstName()
        { 
            return firstName; 
        }
        public string getLastName()
        {
            return lastName; 
        }
        public string getAddress() 
        { 
            return address; 
        }
        public string getCity() 
        { 
            return city; 
        }
        public string getState() 
        { 
            return state; 
        }
        public int getZip() 
        { 
            return zip; 
        }
        public long getPhoneNumber() 
        { 
            return phoneNumber; 
        }
        public string getEmail() 
        { 
            return email; 
        }
    }
}
