using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuItem : ScriptableObject 
{
    [Header ("Item Data")]
    public string ItemName;
    public int Price;
    public Sprite ItemIcon, CurrencyIcon;
    
    public virtual void OnBought()
    {

    }
}
