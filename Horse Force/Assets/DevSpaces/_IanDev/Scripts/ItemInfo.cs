using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

// Ian Phurchpean
// Item Description for different items in the game

public class ItemInfo : MonoBehaviour
{
    public int itemID;
    public TMP_Text price;
    public TMP_Text quantity;
    public GameObject ShopManager;

    // Update is called once per frame
    void Update()
    {
        price.text = "Cost: " + ShopManager.GetComponent<ShopManager>().shopItems[2, itemID].ToString() + " Bucks";
        quantity.text = "Total: " + ShopManager.GetComponent<ShopManager>().shopItems[3, itemID].ToString();
    }
}
