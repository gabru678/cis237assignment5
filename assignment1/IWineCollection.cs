using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    interface IWineCollection
    {
        
        void AddNewItem(string id, string name, string pack, decimal price);


        string[] GetPrintStringsForAllItems();

        string FindById(string id);

        void Delete(String id);
        void Update(string v1, string v2, string v3, decimal v4);
    }
}
