using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System;

public class OpsiTanam : MonoBehaviour
{
    string id;
    string aksesTanam;
    [SerializeField] GameObject ButtonCancel;
    [SerializeField] Text statusSeed, countSeed, idName;
    DatabaseReference reference;
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    

    public void batalTanam()
    {
        aksesTanam = "false";
        statusSeed.text = "Status Seed = Null";
        countSeed.text = "Null";
        ButtonCancel.SetActive(false);
        //reference.Child(id).Child("Inventory").Child("Status Tanam").SetValueAsync(aksesTanam);
    }
}
