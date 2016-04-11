//Author: David Barnes
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{

    // He wasnts us to add a few methods here so that we can use and call them

    class WineItemCollection : IWineCollection
    {
        
        //Private Variables
        WineItem[] wineItems;
        int wineItemsLength;

        // They need to have their own DataBases and User Interface to call
        BeveragePBathEntities db = new BeveragePBathEntities();
        UserInterface ui = new UserInterface();

        // Going to do delete first because its easy
        // Hopefully.
        public void Delete(string id)
        {
            try
            {
                //Find that ID sent in and asign to the Delete possibility
                Beverage toDelete = db.Beverages.Find(id);

                // now delete
                db.Beverages.Remove(toDelete);
                //Dont forget to save!
                db.SaveChanges();

                ui.DisplayDeleteSuccess();
            }

            catch (Exception e)
            {
                ui.DisplayDeleteError();
            }
        }

        // Now do the UPDATE!!!!!!!
        public void Update(string id, string name, string pack, decimal price)
        {
            Beverage toUpdate = db.Beverages.Find(id);

            try
            {
                //Guess we should find it first
                FindById(id);

                //add info
                toUpdate.name = name;
                toUpdate.pack = pack;
                toUpdate.price = price;

                //Save info
                db.SaveChanges();
                ui.DisplayAddWineItemSuccess();
            }

            catch(Exception e)
            {
                ui.DisplayAddWineItemError();
            }
        }

        ////Constuctor. Must pass the size of the collection.
        //public WineItemCollection(int size)
        //{
        //    wineItems = new WineItem[size];
        //    wineItemsLength = 0;
        //}

        //Add a new item to the collection
        public void AddNewItem(string id, string name, string pack, decimal price)
        {
            Beverage toAdd = db.Beverages.Find(id);

            //Guess we should find it first
            FindById(id);

            //add info
            toAdd.id = id;
            toAdd.name = name;
            toAdd.pack = pack;
            toAdd.price = price;

            try
            {

                db.Beverages.Add(toAdd);
                //Save info
                db.SaveChanges();
                ui.DisplayAddWineItemSuccess();
            }

            catch (Exception e)
            {
                ui.DisplayAddWineItemError();
            }
        }
        
        //Get The Print String Array For All Items
        public string[] GetPrintStringsForAllItems()
        {
            //Create and array to hold all of the printed strings
            string[] allItemStrings = new string[wineItemsLength];
            //set a counter to be used
            int counter = 0;

            //If the wineItemsLength is greater than 0, create the array of strings
            if (wineItemsLength > 0)
            {
                //For each item in the collection
                foreach (WineItem wineItem in wineItems)
                {
                    //if the current item is not null.
                    if (wineItem != null)
                    {
                        //Add the results of calling ToString on the item to the string array.
                        allItemStrings[counter] = wineItem.ToString();
                        counter++;
                    }
                }
            }
            //Return the array of item strings
            return allItemStrings;
        }

        //Find an item by it's Id
        public string FindById(string id)
        {
            //Declare return string for the possible found item
            string returnString = null;

            //For each WineItem in wineItems
            foreach (WineItem wineItem in wineItems)
            {
                //If the wineItem is not null
                if (wineItem != null)
                {
                    //if the wineItem Id is the same as the search id
                    if (wineItem.Id == id)
                    {
                        //Set the return string to the result of the wineItem's ToString method
                        returnString = wineItem.ToString();
                    }
                }
            }
            //Return the returnString
            return returnString;
        }
        
    }
}
