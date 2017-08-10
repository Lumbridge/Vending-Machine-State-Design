using System;

namespace Vending_Machine_State_Design.Classes.States
{
    // we will be in this state when the user has not made a selection
    // and doesn't have the correct amount of credit to make the selection they're trying to make.
    //
    class NoCreditOrSelection : State
    {
        // overloaded constructor
        //
        public NoCreditOrSelection(State state) : this(state.Credit, state.VendingMachine) { }

        // main constructor
        //
        public NoCreditOrSelection(int credit, VendingMachine vendingMachine)
        {
            this.credit = credit;
            this.vendingMachine = vendingMachine;
        }

        public override void MakeBeverageSelection(Beverage beverage, bool withSugar)
        {
            // check if the user has inserted enough credit to cover the cost of the
            // beverage they're attempting to select before changing the state to
            // has credit and has made a selection...
            //
            if (credit >= CalculateBeverageCost(beverage, withSugar))
            {
                // set the local beverage to the selection made from the top level
                //
                selectedBeverage = beverage;

                // set the sugar option
                //
                selectedBeverage.WithSugar = withSugar;

                // if the user has enough or more credit to purchase the selected bevarage
                // then we change the state to HasCredit...
                //
                vendingMachine.State = new HasCreditAndSelection(this);

                // output some information to the console
                //
                Console.WriteLine("You have selected {0}, Sugar: {1}", selectedBeverage.Name, selectedBeverage.WithSugar);
            }
            else
            {
                // if the user doesn't have enough credit then we tell
                // them how much they'd need to insert for this beverage
                //
                Console.WriteLine("Please insert {0} credit to select this beverage.", CalculateBeverageCost(beverage, withSugar) - credit);
            }
        }

        public override void InsertCredit(int amount)
        {
            // add the amount inserted to the total credit
            //
            credit += amount;
            
            Console.WriteLine("{0} credit inserted, total credit: {1}.", amount, credit);
        }

        public override void RefundCredit()
        {
            // check if the user has any credit in the machine
            //
            if (credit > 0)
            {
                // if they have credit then we refund the credit
                //
                Console.WriteLine("Returned {0} credit.", credit);

                // then we set the credit to 0
                //
                credit = 0;
            }
            else
            {
                // if the user has no credit then we do nothing
                //
                Console.WriteLine("There is no credit to return!");
            }
        }

        public override void Dispense()
        {
            // in this state we cannot dispense beverages because the user
            // hasn't got enough credit to do so...
            //
            Console.WriteLine("Cannot dispense. No drink selected/no credit inserted.");
        }

        public override void PrintState()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Current State: {0}", GetType().Name);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
