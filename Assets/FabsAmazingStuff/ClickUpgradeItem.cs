using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "ScriptableObject/New Click Upgrade Item")]
public class ClickUpgradeItem : MenuItem
{
    [Header("Click upgrade Data")]
    public float ClickAmount;

    public override void OnBought()
    {
        base.OnBought();
        animalTap.Instance.singleTapIncrease += ClickAmount;
        // add more to clcik 
    }
}
