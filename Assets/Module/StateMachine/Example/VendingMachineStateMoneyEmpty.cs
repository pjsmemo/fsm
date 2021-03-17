using UnityEngine;

public class VendingMachineStateMoneyEmpty : VendingMachineStateBase<VendingMachineState>
{
    public override VendingMachineState state => VendingMachineState.MoneyEmpty;

    public override void BuySomething ()
    {
        Debug.Log("[MoneyEmpty] 돈이 없어 살 수 가 없다.");
    }


    public override void InsertCoin ()
    {
        VendingMachine.coin += 50;

        Debug.Log("[MoneyEmpty] 돈 추가, 현재 : " + VendingMachine.coin);

        _stateMachine.SetState(VendingMachineState.MoneyHas);
    }

    public override void ReturnButton ()
    {
        Debug.Log("[MoneyEmpty] 반환할 돈이 없다.");
    }
}
