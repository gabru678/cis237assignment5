//Author: Paul Bath
//CIS 237
//Assignment 5
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set a constant for the size of the collection
            //const int wineItemCollectionSize = 4000;

            //Create an Instance of the Database
            BeveragePBathEntities beveregeEntity = new BeveragePBathEntities();

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Create an instance of the WineItemCollection class
            IWineCollection wineItemCollection = new WineItemCollection();

            //Create an instance of the CSVProcessor class
            //CSVProcessor csvProcessor = new CSVProcessor();

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        // Print All
                        foreach (Beverage bev in beveregeEntity.Beverages)
                        {
                            Console.WriteLine("Printing all in the Database! \n");
                            Console.WriteLine("The ID is: " + bev.id);
                            Console.WriteLine("The Name is: " + bev.name);
                            Console.WriteLine("The Pack is: " + bev.pack);
                            Console.WriteLine("The Price is: " + bev.price);
                        }
                            break;

                    case 2:
                        //Search for a specific ID
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = wineItemCollection.FindById(searchQuery);
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }

                        break;

                    case 3:
                        //Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        if (wineItemCollection.FindById(newItemInformation[0]) == null)
                        {
                            wineItemCollection.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2],Convert.ToDecimal(newItemInformation[3]));
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;

                    case 4:
                        // Modify Item
                        string[] modifyItem = userInterface.GetInfoToUpdate();

                        if (wineItemCollection.FindById(modifyItem[0]).Equals(true))
                        {
                           wineItemCollection.Update(modifyItem[0], modifyItem[1], modifyItem[2], Convert.ToDecimal(modifyItem[3]));
                        }

                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }

                        break;

                    case 5:
                        //Delete a Wine item by ID
                        string deleteItem = userInterface.GetIDToDelete();

                        if (wineItemCollection.FindById(deleteItem).Equals(true))
                        {
                            wineItemCollection.Delete(deleteItem);
                        }

                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }

                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
