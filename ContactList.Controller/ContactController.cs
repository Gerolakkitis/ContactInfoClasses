using ContactList.Data;
using ContactList.Models;
using ContactList.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Controller
{
    public class ContactController
    {
        private UserInterface userInterface;
        private ContactRepository repository;

        public ContactController()
        {
            userInterface = new UserInterface();
            repository = new ContactRepository();
        }

        public void Run()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                int menuChoice = userInterface.ShowMenuAndGetUserChoice();

                switch (menuChoice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        ShowAllContacts();
                        break;
                    case 3:
                        SearchContact();
                        break;
                    case 4:
                        UpdateContact();
                        break;
                    case 5:
                        DeleteContact();
                        break;
                    case 6:
                        keepRunning = false;
                        break;
                }
            }
        }

        private void AddContact()
        {
            Contact newContact = userInterface.GetNewContactInformation();
            Contact addedContact = repository.CreateContact(newContact);

            if(addedContact != null)//successfully added to repository
            {
                userInterface.DisplayContact(addedContact);

                userInterface.ShowActionSuccess("Add Contact");
            }
            else //Failed to add to repository
            {
                userInterface.ShowActionFailure("Add Contact");
            }

        }

        private void ShowAllContacts()
        {
            //REmove this line when you strart implementing action method
            Contact[] RetrievedContacts= repository.RetrieveAllContacts();
            //int i = 0;

            foreach (Contact i in RetrievedContacts)
            {
                if (i != null)
                {
                    userInterface.DisplayContact(i);
                }
            }

            //while (RetrievedContacts[i] != null)
            //{
            //    userInterface.DisplayContact(RetrievedContacts[i]);
            //    i++;
            //}
        }

        private void SearchContact()
        {
            userIO userIO = new userIO();
            Contact[] RetrievedContacts = repository.RetrieveAllContacts();
            int userInput = userIO.ReadInt("Enter userID: ", 0, RetrievedContacts.Length);
            for (int i=0; i<RetrievedContacts.Length; i++)
            {
                if (RetrievedContacts[i] != null)
                {
                    if (RetrievedContacts[i].ContactID == userInput)
                    {
                        userInterface.DisplayContact(RetrievedContacts[i]);
                        break;
                    }
                }
                else if ((i+1) == RetrievedContacts.Length)
                {
                    Console.WriteLine("Not a valid ID");
                    break;
                }
            }
        }

        private void UpdateContact()
        {
            //Remove this line when you start implementing action method
            userIO userIO = new userIO();
            Contact[] RetrievedContacts = repository.RetrieveAllContacts();
            int userInput = userIO.ReadInt("Enter userID you want to update: ", 0, RetrievedContacts.Length);

            if (RetrievedContacts[userInput] != null)
            {
                Console.WriteLine("Editing this user:");
                userInterface.DisplayContact(RetrievedContacts[userInput]);
                repository.EditContact(RetrievedContacts[userInput]);




                //Contact addedContact = repository.CreateContact(RetrievedContacts[userInput]);

                userInterface.ShowActionSuccess("Update Contact ");
            }
            else
            {
                Console.WriteLine("Not a valid ID");
                userInterface.ShowActionFailure("Update Contact ");
            }


        }

        private void DeleteContact()
        {
            userIO userIO = new userIO();
            Contact[] RetrievedContacts = repository.RetrieveAllContacts();
            int userInput = userIO.ReadInt("Enter userID you want to delete: ", 0, RetrievedContacts.Length);

            if (RetrievedContacts[userInput] != null)
            {
                repository.DeleteContact(RetrievedContacts[userInput].ContactID);
                userInterface.ShowActionSuccess("Delete Contact ID");
            }
            else
            {
                Console.WriteLine("Not a valid ID");
                userInterface.ShowActionFailure("Delete Contact ID");
            }

        }







    }


}
