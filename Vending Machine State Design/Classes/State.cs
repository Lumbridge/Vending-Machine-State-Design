namespace Vending_Machine_State_Design.Classes
{
    abstract class State
    {
        // protected instance of our context class
        //
        protected VendingMachine vendingMachine;

        // protected instance of the running total credit
        //
        protected int credit;

        // protected instance of the selected beverage
        //
        protected Beverage selectedBeverage;
        
        // the cost of sugar is constant
        //
        public const int SUGAR_COST = 15;

        // allows classes (other than derived ones) to access the protected
        // instance of our vending machine object
        //
        public VendingMachine VendingMachine
        {
            get { return vendingMachine; }
            set { vendingMachine = value; }
        }

        // allows classes (other than derived ones) to access the protected credit variable
        //
        public int Credit
        {
            get { return credit; }
            set { credit = value; }
        }

        // allows classes (other than derived ones) to access the selected beverage object
        //
        public Beverage SelectedBeverage
        {
            get { return selectedBeverage; }
            set { selectedBeverage = value; }
        }

        // this function returns the cost of a beverage with the added cost
        // of sugar if the user wants sugar or not
        //
        public int CalculateBeverageCost(Beverage beverage, bool withSugar)
        {
            if (withSugar)
                return beverage.Price + SUGAR_COST;
            else
                return beverage.Price;
        }

        // our overridable functions
        //
        public abstract void MakeBeverageSelection(Beverage beverage, bool withSugar);
        public abstract void InsertCredit(int amount);
        public abstract void RefundCredit();
        public abstract void Dispense();

        public abstract void PrintState();
    }
}
