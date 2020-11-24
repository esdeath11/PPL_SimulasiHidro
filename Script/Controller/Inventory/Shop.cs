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
    [SerializeField] Text textMoney;
    int money;
    DatabaseReference reference;
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        loadData();
    }


    void loadData()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference("Shop")
        .ValueChanged += Database_ValueChanged;
    }

    private void Database_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        textMoney.text ="Rp. " + e.Snapshot.Child("Money").GetValue(true).ToString();
    }
}
