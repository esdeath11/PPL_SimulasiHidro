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
    [SerializeField] Text seledri, bayamM, Dbawang, Selada;
    public static int cointSel, countBay, countBaw, countSelad;
    DatabaseReference reference;

    private void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        loadData();
    }

    public void loadData()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference("Inventory")
        .ValueChanged += Database_ValueChanged;
    }

    private void Database_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        seledri.text = e.Snapshot.Child("Seledri").GetValue(true).ToString();
        bayamM.text = e.Snapshot.Child("bayam").GetValue(true).ToString();
        Dbawang.text = e.Snapshot.Child("Bawang").GetValue(true).ToString();
        Selada.text = e.Snapshot.Child("Selada").GetValue(true).ToString();
        
    }

    public void useSeledri()
    {
        cointSel = int.Parse(seledri.text);
        if(cointSel > 0)
        {
            cointSel -= 1;
            seledri.GetComponent<Text>().text = cointSel.ToString();
            reference.Child("Inventory").Child("Seledri").SetValueAsync(int.Parse(seledri.text));
        }

    }

    public void useSelada()
    {
        countSelad = int.Parse(Selada.text);
       if(countSelad > 0)
        {
            countSelad -= 1;
            Selada.GetComponent<Text>().text = countSelad.ToString();
            reference.Child("Inventory").Child("Selada").SetValueAsync(int.Parse(Selada.text));
        }
    }

    public void useBayam()
    {
        countBay = int.Parse(bayamM.text);
        if (countBay > 0)
        {
            countBay -= 1;
            bayamM.GetComponent<Text>().text = countBay.ToString();
            reference.Child("Inventory").Child("bayam").SetValueAsync(int.Parse(bayamM.text));
        }
    }

    public void useBawang()
    {
        countBaw = int.Parse(Dbawang.text);
        if (countBaw > 0)
        {
            countBaw -= 1;
            Dbawang.GetComponent<Text>().text = countBaw.ToString();
            reference.Child("Inventory").Child("Bawang").SetValueAsync(int.Parse(Dbawang.text));
        }
    }


}
