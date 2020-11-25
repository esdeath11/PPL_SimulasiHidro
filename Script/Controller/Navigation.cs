using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    [SerializeField] GameObject bag,shop;

    public void inventory()
    {
        bag.SetActive(true);
        shop.SetActive(false);
    }

    public void closeInventory()
    {
        bag.SetActive(false);
    }

    public void openShop()
    {
        shop.SetActive(true);
        bag.SetActive(false);
    } 

    public void closeShop()
    {
        shop.SetActive(false);
    }
}
