using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactList.Models;
using ContactList.UI;

namespace ContactList.Data
{
    public class ContactRepository
    {
        Contact[] contacts;
        
        public ContactRepository()
        {
            contacts = new Contact[10];

            Contact contact1 = new Contact();
            contact1.ContactID = 0;
            contact1.FirstName = "Bill";
            contact1.LastName = "Gates";
            contact1.PhoneNumber = "605-555-1234";

            contacts[0] = contact1;

            Contact contact2 = new Contact();
            contact2.ContactID = 1;
            contact2.FirstName = "Elon";
            contact2.LastName = "Musk";
            contact2.PhoneNumber = "605-555-1235";

            contacts[1] = contact2;
        }

        public Contact CreateContact(Contact contact)
        {
            //find the first open spot in the contacts list
            for (int i=0; i<contacts.Length; i++)
            {
                if (contacts[i] == null)
                {
                    //set the id for the contact
                    contact.ContactID = i;
                    //add the contact to the list
                    contacts[i] = contact;
                    return contact;
                }
            }

            //the array was full so we weren't able to add the contact
            return null;
        }


        public Contact[] RetrieveAllContacts()
        {
            return contacts;
        }

        public Contact RetrieveContactById(int contactID)
        {
            return contacts[contactID];
        }

        public void DeleteContact(int contactID)
        {
            contacts[contactID] = null;
        }

        public Contact EditContact(Contact contact)
        {
            DeleteContact(contact.ContactID);
            UserInterface newContact = new UserInterface();
            contact = newContact.GetNewContactInformation();
            Contact updatedContact = CreateContact(contact);
            return updatedContact;
        }


    }
}
