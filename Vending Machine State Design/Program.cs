using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vending_Machine_State_Design.Classes;

namespace Vending_Machine_State_Design
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Example usage of the vending machine 
            //

            // create some beverages to use in our vending machine
            //
            Beverage Tea = new Beverage() { Name = "Tea", Price = 100 };
            Beverage Coffee = new Beverage() { Name = "Coffee", Price = 100 };

            // assign these for clarity when passing them into the makeselection method
            //
            Beverage SelectedBeverage = Tea;    // user wants tea...
            bool WithSugar = true;              // user wants sugar...

            // create our vending machine instance
            //
            VendingMachine V = new VendingMachine();

            // user inserts some credit
            //
            V.InsertCredit(150);

            // user makes the beverage selection (with sugar +15 credit cost)
            //
            V.MakeSelection(SelectedBeverage, WithSugar);
            
            // dispense the beverage
            //
            V.Dispense();
            
            // try to dispense another
            //
            V.Dispense();

            // refund the leftover credit
            //
            V.RefundCredit();
        }
    }
}