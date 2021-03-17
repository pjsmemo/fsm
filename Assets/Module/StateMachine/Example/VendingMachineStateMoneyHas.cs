using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PJS.StateMachine;

public class VendingMachineStateMoneyHas : VendingMachineStateBase<VendingMachineState>
{
    public override VendingMachineState state => VendingMachineState.MoneyHas;

    public override void BuySomething ()
    {
        if (VendingMachine.coin < 100)
        {
            Debug.Log("[MoneyHas] 돈이 없어 적어 살 수 없다.");
            return;
        }

        VendingMachine.coin -= 100;
        VendingMachine.productCount -= 1;
        Debug.Log("[MoneyHas] 뭔가를 샀다, 현재 : " + VendingMachine.coin);

        if (VendingMachine.productCount <= 0)
        {
            Debug.Log("[MoneyHas] 모든 물건이 다 팔림");
            _stateMachine.SetState(VendingMachineState.SoldOut);
        }
    }

    public override void InsertCoin ()
    {
        VendingMachine.coin += 50;

        Debug.Log("[MoneyHas] 돈 추가, 현재 : " + VendingMachine.coin);
    }

    public override void ReturnButton ()
    {
        if (VendingMachine.coin <= 0)
        {
            Debug.Log("[MoneyHas] 반환할 돈이 없다.");
            return;
        }

        VendingMachine.coin = 0;

        Debug.Log("[MoneyHas] 돈 반환, 현재 : " + VendingMachine.coin);

        _stateMachine.SetState(VendingMachineState.MoneyEmpty);
    }
}
