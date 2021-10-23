using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuilder : MonoBehaviour
{
    public GameObject ItemGroup;
    public MenuItem[] Items; 

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            GameObject NewItem = Instantiate(ItemGroup);
            NewItem.transform.parent = transform;
            NewItem.GetComponent<ShopItemController>().SetupShopItem(Items[i]);
        }
    }

 
}
