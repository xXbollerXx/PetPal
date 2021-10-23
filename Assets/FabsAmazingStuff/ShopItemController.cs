using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemController : MonoBehaviour
{

    [SerializeField]
    Image IconImage, CurrencyImage;
    [SerializeField]
    TextMeshProUGUI CostAmount, ItemName;
    MenuItem menuItem;
    [SerializeField]
    TMP_Dropdown Dropdown;
    [SerializeField]
    int[] TimesAmount = new int[3] { 1, 2, 5 };

    private int PriceSelected;
    private int AmountSelected;

    public void SetupShopItem(MenuItem _menuItem)
    {
        //Debug.LogWarning("this does not set up right, variables will b empty if you don't select form cdrop down first will fix");
        menuItem = _menuItem;
        IconImage.sprite = menuItem.ItemIcon;
        CurrencyImage.sprite = menuItem.CurrencyIcon;
        CostAmount.text = menuItem.Price.ToString();
        ItemName.text = menuItem.ItemName;
        AmountSelected = TimesAmount[0];
        PriceSelected = AmountSelected * menuItem.Price;
    }


    public void CalPrice()
    {
        Debug.Log(Dropdown.value);

        for (int i = 0; i < TimesAmount.Length; i++)
        {
            if (Dropdown.value == i)
            {
                PriceSelected = menuItem.Price * TimesAmount[i];
                AmountSelected = TimesAmount[i];
                CostAmount.text = PriceSelected.ToString();
            }
        }
    }
   
    public void BuyItem()
    {
        
        bool Result = CurrencyManager.Instance.TryToRemoveCurrency(PriceSelected);
        if (!Result)
        {
            return;
        }

        //add stuff 
        Debug.Log("Buy " + menuItem.ItemName + " to whatever  Cost =" + PriceSelected.ToString());

        for (int i = 0; i < AmountSelected; i++)
        {
            menuItem.OnBought();
        }
    }
}
