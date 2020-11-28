using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System;


public class Navigation : MonoBehaviour
{
    [SerializeField] GameObject bag,shop,rockwool, Options, StatusUI, AlertUIOBJ;
    string id, statRockwool;
    [SerializeField] Text Selada, Rockwool;
    public void loadData()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference(id)
        .ValueChanged += Database_ValueChanged;
    }

    private void Database_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // seledri.text = e.Snapshot.Child("Seledri").GetValue(true).ToString();
        //  bayamM.text = e.Snapshot.Child("bayam").GetValue(true).ToString();
        //   Dbawang.text = e.Snapshot.Child("Bawang").GetValue(true).ToString();
        Selada.text = e.Snapshot.Child("Inventory").Child("Seed Selada").GetValue(true).ToString();
        Rockwool.text = e.Snapshot.Child("Inventory").Child("Rockwool").Child("Value").GetValue(true).ToString();
        statRockwool = e.Snapshot.Child("Inventory").Child("Rockwool").Child("Lubang Status").GetValue(true).ToString();

    }


    public void inventory()
    {
        bag.SetActive(true);
        shop.SetActive(false);
        rockwool.SetActive(false);
        Options.SetActive(false);
        StatusUI.SetActive(false);
    }

    public void closeInventory()
    {
        bag.SetActive(false);
        rockwool.SetActive(true);
        Options.SetActive(true);
        StatusUI.SetActive(true);
    }

    public void openShop()
    {
        shop.SetActive(true);
        bag.SetActive(false);
        rockwool.SetActive(false);
        Options.SetActive(false);
        StatusUI.SetActive(false);
    } 

    public void closeShop()
    {
        shop.SetActive(false);
        rockwool.SetActive(true);
        Options.SetActive(true);
        StatusUI.SetActive(true);
    }

    public void AlertUI()
    {
        AlertUIOBJ.SetActive(false);
        rockwool.SetActive(true);
        Options.SetActive(true);
        StatusUI.SetActive(true);
    }

 
}
