using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.UI
{
    public class UserInterface
    {
        private userIO userIO;

        public UserInterface()
        {
            userIO = new userIO();
        }

        public int ShowMenuAndGetUserChoice()
        {
            Console.WriteLine("\nEnter a choice from the menu below: ");
            Console.WriteLine("1.Add Contact");
            Console.WriteLine("2.Show All Contacts");
            Console.WriteLine("3.Look Up Contact");
            Console.WriteLine("4.Edit Contact");
            Console.WriteLine("5.Remove Contact");
            Console.WriteLine("6.Exit Program");
            int userChoice = userIO.ReadInt("Enter your choice: ", 1, 6);

            return userChoice;
        }

        public Contact GetNewContactInformation()
        {
            Contact contact = new Contact();

            contact.FirstName = userIO.ReadString("\nEnter the contact's first name: ");
            contact.LastName = userIO.ReadString("enter the contact's last name: ");
            contact.Email = userIO.ReadString("Enter the contact's email address: ");
            contact.PhoneNumber = userIO.ReadString("Enter the contact's phone number: ");

            return contact;
        }

        public void DisplayContact(Contact contact)
        {
            Console.WriteLine("\nContact ID:   {0}", contact.ContactID);
            Console.WriteLine("First Name:     {0}", contact.FirstName);
            Console.WriteLine("Last Name:      {0}", contact.LastName);
            Console.WriteLine("Email:          {0}", contact.Email);
            Console.WriteLine("Phone Number:   {0}", contact.PhoneNumber);
        }

        public void ShowActionSuccess(string actionName)
        {
            Console.WriteLine("\n{0} executed successfully!", actionName);
        }

        public void ShowActionFailure(string actionName)
        {
            Console.WriteLine("\n{0} failed to execute properly!", actionName);
        }
    }


}
