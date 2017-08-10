using System;

// need to reference this because we put it in the states folder
// in the solution explorer...
//
using Vending_Machine_State_Design.Classes.States;

namespace Vending_Machine_State_Design.Classes
{
    class VendingMachine
    {
        // state variable changes depending on the current state
        // the machine is in.
        //
        private State _state;

        // constructor for the vending machine
        //
        public VendingMachine()
        {
            // default state is no credit (this is as if the machine just turned on).
            //
            _state = new NoCreditOrSelection(0, this);
        }

        // state class protected credit accessor for other classes
        //
        public int Credit { get { return _state.Credit; } }

        // state accessor for classes without access to the state base class
        //
        public State State
        {
            get { return _state; }
            set { _state = value; }
        }

        //
        // context functions --- accessible by classes without access to state base class
        //

        // function to make a beverage selection
        //
        public void MakeSelection(Beverage beverage, bool withSugar)
        {
            _state.MakeBeverageSelection(beverage, withSugar);
            _state.PrintState();
        }

        // function to insert credit into the machine
        //
        public void InsertCredit(int amount)
        {
            _state.InsertCredit(amount);
            _state.PrintState();
        }

        // function to return any credit from the machine to the user
        //
        public void RefundCredit()
        {
            _state.RefundCredit();
            _state.PrintState();
        }

        // function to dispense a beverage
        //
        public void Dispense()
        {
            _state.Dispense();
            _state.PrintState();
        }
    }
}
