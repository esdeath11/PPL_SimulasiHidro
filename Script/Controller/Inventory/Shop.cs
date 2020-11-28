using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System;

public class Shop : MonoBehaviour
{
    [SerializeField] Text textMoney, idName;
    public static int money, countSelada, countSeledri, countBayam, countBawang, rockwool;
    DatabaseReference reference;
    string id;

    private void Update()
    {
        id = idName.text;
        
        loadData();
    }

    void Start()
    {
        id = idName.text;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        
    }


    void loadData()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference(id)
        .ValueChanged += Database_ValueChanged;
        
    }

    private void Database_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        textMoney.text = e.Snapshot.Child("Inventory").Child("Economy").Child("Money").GetValue(true).ToString();
    }

    public void buySelada()
    {
        money = int.Parse(textMoney.text);
        if(money > 0)
        {
            money -= 3000;
            countSelada += 3;
            textMoney.GetComponent<Text>().text = money.ToString();
            reference.Child(id).Child("Inventory").Child("Economy").Child("Money").SetValueAsync(int.Parse(textMoney.text));
            reference.Child(id).Child("Inventory").Child("Seed").Child("Selada").SetValueAsync(countSelada);
        }
    }

    public void buyRockwool()
    {
        money = int.Parse(textMoney.text);
        if (money > 0)
        {
            money -= 7500;
            rockwool += 1;
            textMoney.GetComponent<Text>().text = money.ToString();
            reference.Child(id).Child("Inventory").Child("Economy").Child("Money").SetValueAsync(int.Parse(textMoney.text));
            reference.Child(id).Child("Inventory").Child("Tools").Child("Rockwool").Child("Value").SetValueAsync(rockwool);
            reference.Child(id).Child("Inventory").Child("Tools").Child("Rockwool").Child("Status").SetValueAsync("0");
        }
    }

}
