using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// Ian Phurchpean
// Shop Manager Script

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public float money;
    public TMP_Text moneyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyText.text = "Horse Bucks: " + money.ToString();

        // ID
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;

        // Price
        shopItems[2, 1] = 25;
        shopItems[2, 2] = 50;
        shopItems[2, 3] = 25;

        // Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
    } 

    public void BuyItem()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (money >= shopItems[2, ButtonRef.GetComponent<ItemInfo>().itemID])
        {
            money -= shopItems[2, ButtonRef.GetComponent<ItemInfo>().itemID];
            shopItems[3, ButtonRef.GetComponent<ItemInfo>().itemID]++;
            moneyText.text = "Horse Bucks: " + money.ToString();
            ButtonRef.GetComponent<ItemInfo>().quantity.text = shopItems[3, ButtonRef.GetComponent<ItemInfo>().itemID].ToString();
        }
    }
}
