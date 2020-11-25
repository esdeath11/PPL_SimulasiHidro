using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System;

public class Item : MonoBehaviour
{
    [SerializeField] Text seledri, bayamM, Dbawang, Selada, idName, Rockwool;
    [SerializeField] GameObject rockWoolObject, bag;
    public static int cointSel, countBay, countBaw, countSelad, countRock;
    DatabaseReference reference;
    string id;

    private void Start()
    {
        id = idName.text;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        loadData();
    }

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
        
    }

    public void useSeledri()
    {
        cointSel = int.Parse(seledri.text);
        if(cointSel > 0)
        {
            cointSel -= 1;
            seledri.GetComponent<Text>().text = cointSel.ToString();
            reference.Child(id).Child("Inventory").Child("Seledri").SetValueAsync(int.Parse(seledri.text));
        }

    }

    public void useSelada()
    {
        countSelad = int.Parse(Selada.text);
       if(countSelad > 0)
        {
            countSelad -= 1;
            Selada.GetComponent<Text>().text = countSelad.ToString();
            reference.Child(id).Child("Inventory").Child("Seed Selada").SetValueAsync(int.Parse(Selada.text));
        }
    }

    public void useBayam()
    {
        countBay = int.Parse(bayamM.text);
        if (countBay > 0)
        {
            countBay -= 1;
            bayamM.GetComponent<Text>().text = countBay.ToString();
            reference.Child(id).Child("Inventory").Child("bayam").SetValueAsync(int.Parse(bayamM.text));
        }
    }

    public void useBawang()
    {
        countBaw = int.Parse(Dbawang.text);
        if (countBaw > 0)
        {
            countBaw -= 1;
            Dbawang.GetComponent<Text>().text = countBaw.ToString();
            reference.Child(id).Child("Inventory").Child("Bawang").SetValueAsync(int.Parse(Dbawang.text));
        }
    }

    public void useRockwool()
    {
        countRock = int.Parse(Rockwool.text);
        if (countRock > 0)
        {
            countRock -= 1;
            Rockwool.GetComponent<Text>().text = countRock.ToString();
            reference.Child(id).Child("Inventory").Child("Rockwool").Child("Value").SetValueAsync(countRock);
            reference.Child(id).Child("Inventory").Child("Rockwool").Child("Status").SetValueAsync("1");
            rockWoolObject.SetActive(true);
            bag.SetActive(false);
        }
    }


}
