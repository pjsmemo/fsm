using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PJS.StateMachine;

public enum VendingMachineState
{
    MoneyEmpty,
    MoneyHas,
    SoldOut,
}

public class VendingMachine : StateMachine<VendingMachineState>
{

    public int coin = 0;
    public int productCount = 0;


    void Start()
    {
        coin = 10;
        productCount = 2;

        var items = transform.GetComponentsInChildren<VendingMachineStateBase<VendingMachineState>>();
        Debug.Log("found count : " + items.Length);
        foreach (var item in items)
        {
            Debug.Log("Initilize :  " + item.state);
            item.InitlizeVendingState(item.state, this);
        }

        SetState(VendingMachineState.MoneyEmpty);
    }

    private VendingMachineStateBase<VendingMachineState> vendingMachineState
    {
        get
        {
            return currentState as VendingMachineStateBase<VendingMachineState>;
        }
    }


    public void InsertCoin ()
    {
        vendingMachineState.InsertCoin();
    }

    public void BuySomething ()
    {
        vendingMachineState.BuySomething();
    }

    public void ReturnButton ()
    {
        vendingMachineState.ReturnButton();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            vendingMachineState.InsertCoin();
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            vendingMachineState.BuySomething();
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            vendingMachineState.ReturnButton();
        }
    }
}
