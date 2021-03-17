using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PJS.StateMachine;

public abstract class VendingMachineStateBase <T> : State<T>  where T : System.Enum
{
    protected VendingMachine _vendingMachine;

    public void InitlizeVendingState (T state, VendingMachine vendingMachine)
    {
        Initlize(vendingMachine as StateMachine<T>);

        _vendingMachine = vendingMachine;
    }

    public VendingMachine VendingMachine
    {
        get
        {
            return _vendingMachine;
        }
    }

    public abstract void BuySomething ();

    public abstract void InsertCoin ();

    public abstract void ReturnButton ();
}
