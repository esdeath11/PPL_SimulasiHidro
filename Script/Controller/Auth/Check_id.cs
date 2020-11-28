using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System;
public class Check_id : Register_id
{
    [SerializeField] Text idname;
    string id;
    DatabaseReference reference;
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        id = Register_id.id;
        
        loadData();
    }

    void loadData()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference(id)
        .ValueChanged += Database_ValueChanged;
    }

    private void Database_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        idname.text = e.Snapshot.Child("Name").GetValue(true).ToString();
    }
}
