using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System;
public class Check_id : MonoBehaviour
{
    
    [SerializeField] Text idname;
    string id;
    DatabaseReference reference;
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        authCheck();
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

    void authCheck()
    {
        if (Login_id.switchAuth == 1 && Register_id.switchAuth == 0)
        {
            id = Login_id.idLog;
            loadData();
        }

        if (Register_id.switchAuth == 2 && Login_id.switchAuth == 0)
        {
            id = Register_id.id;
            loadData();
        }
    }
}
