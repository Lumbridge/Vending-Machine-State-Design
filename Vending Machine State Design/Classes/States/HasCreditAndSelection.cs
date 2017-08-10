using System;

namespace Vending_Machine_State_Design.Classes.States
{
    // we will be in this state when the user has made a selection and has the
    // correct amount of credit to purchase that beverage
    //
    class HasCreditAndSelection : State
    {
        // overloaded constructor
        //
        public HasCreditAndSelection(State state) : this(state.Credit, state.VendingMachine, state.SelectedBeverage) { }

        // main constructor
        //
        public HasCreditAndSelection(int credit, VendingMachine vendingMachine, Beverage selectedBeverage)
        {
            this.credit = credit;
            this.vendingMachine = vendingMachine;
            this.selectedBeverage = selectedBeverage;
        }

        // in this implimentation we don't need to override this function
        // because our dispense function takes beverage and withSugar parameters.
        // an alternative method would be to store the beverage and withsugar options
        // using this function and then the dispense function wouldn't need these parameters
        // but would just dispense the stored beverage instead...
        //
        public override void MakeBeverageSelection(Beverage beverage, bool withSugar)
        {
            throw new NotImplementedException();
        }

        // the user can insert credit if they already have some
        // maybe they want multiple drinks...
        //
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

        // dispense function would dispense a beverage in this instance
        // becuase the selection the user made in the nocredit class means
        // they'd definitely have enough or more credit to dispense the beverage.
        //
        public override void Dispense()
        {
            // dispensing drink...
            //
            Console.WriteLine("Dispensing {0}, Sugar: {1}", selectedBeverage.Name, selectedBeverage.WithSugar);

            // remove the cost of the beverage from the total credit
            //
            credit -= CalculateBeverageCost(selectedBeverage, selectedBeverage.WithSugar);

            // check if user has leftover credit to return, buy more etc...
            //
            if (credit > 0)
                Console.WriteLine("{0} credit remaining.", credit);

            // set the state as no credit or selection because the user has dispensed their drink
            // and must make another selection if they want another drink,
            // alternatively they can return their leftover credit using the RefundCredit method
            //
            vendingMachine.State = new NoCreditOrSelection(this);
        }

        public override void PrintState()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Current State: {0}", GetType().Name);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
