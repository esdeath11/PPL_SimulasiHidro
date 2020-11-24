using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    [SerializeField] GameObject bag;

    public void inventory()
    {
        bag.SetActive(true);
    }

    public void closeInventory()
    {
        bag.SetActive(false);
    }


}
