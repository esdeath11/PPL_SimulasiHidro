using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System;

public class Register_id : MonoBehaviour
{
    DatabaseReference reference;
    public static int switchAuth = 0;
    [SerializeField] InputField username;
    public static string id;
    int Selada;
    int Money, Rockwool;
    bool statusTanam, UsageStatus, lubang;
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        Selada = 0;
        Money = 1000000;
        Rockwool = 0;
        statusTanam = false;
        UsageStatus = false;
        lubang = false;
        switchAuth = 0;
    }

    public void registerID()
    {
        id = username.text;
        switchAuth = 2;
        if(username.text != "")
        {
            reference.Child(id).Child("Name").SetValueAsync(username.text.ToString());
            reference.Child(id).Child("Inventory").Child("Seed").Child("Selada").SetValueAsync(Selada);
            reference.Child(id).Child("Inventory").Child("Economy").Child("Money").SetValueAsync(Money);
            reference.Child(id).Child("Inventory").Child("Tools").Child("Rockwool").Child("Lubang Status").SetValueAsync(lubang);
            reference.Child(id).Child("Inventory").Child("Tools").Child("Rockwool").Child("Status").SetValueAsync("0");
            reference.Child(id).Child("Inventory").Child("Tools").Child("Rockwool").Child("Value").SetValueAsync(Rockwool);
            reference.Child(id).Child("Management").Child("Status Tanam").SetValueAsync(statusTanam);
            reference.Child(id).Child("Management").Child("Usage Status").SetValueAsync(UsageStatus);


        }
        
    }
}
