using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PJS.StateMachine;

public class VendingMachineStateSoldOut : VendingMachineStateBase<VendingMachineState>
{
    public override VendingMachineState state => VendingMachineState.SoldOut;


    public override void BuySomething ()
    {
        Debug.Log("[SoldOut] 다 팔렸다 : 살 수 없음");
    }

    public override void InsertCoin ()
    {
        Debug.Log("[SoldOut] 다 팔렸다 : 동전 반환, 자동");
    }

    public override void ReturnButton ()
    {
        Debug.Log("[SoldOut] 다 팔렸다 : 동전 반환, 수동");
    }
}
