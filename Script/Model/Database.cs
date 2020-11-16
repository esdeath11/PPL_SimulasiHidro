using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System;

public class Database : MonoBehaviour
{

    [SerializeField] Text seed1;
    [SerializeField] Text seed2;
    [SerializeField] Text seed3;
    [SerializeField] Text seed4;
    [SerializeField] Text rockwol;
    [SerializeField] Text pot;
    [SerializeField] Text obat;
    [SerializeField] Text money;
    [SerializeField] Text time;
    [SerializeField] GameObject tanaman1;
    [SerializeField] GameObject tanaman2;
    [SerializeField] GameObject tanaman3;
    [SerializeField] GameObject tanaman4;
    [SerializeField] GameObject tanaman5;
    [SerializeField] GameObject tanaman6;
    [SerializeField] GameObject tanaman7;
    [SerializeField] GameObject tanaman8;
    [SerializeField] GameObject tanaman9;
    [SerializeField] GameObject tanaman10;
    


    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void saveData()
    {
        //  reference.Child("Users").Child("User 1").Child("Email").SetValueAsync(textField.text.ToString());
    }

    public void loadData()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference("Users")
        .ValueChanged += Database_ValueChanged;
    }

    private void Database_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Debug.Log(e.Snapshot.Child("User 1").Child("Email").GetValue(true));

        // Update is called once per frame
        void Update()
        {

        }
    }
}
