using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "ScriptableObject/New Auto Clicker Item")]
public class AutoClickerItem : MenuItem
{
    [Header("Auto Clicker Data")]
    public float CPSAmount;

    public override void OnBought()
    {
        base.OnBought();

        //get auto clicker and add CPSAmount
        AutoClickerManager.Instance.AddNewAutoClicker(CPSAmount);
    }
}
