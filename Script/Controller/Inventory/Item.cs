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
    [SerializeField] Text seledri, bayamM, Dbawang, Selada, idName, Rockwool, statusSeed, countSeed;
    [SerializeField] GameObject rockWoolObject, bag, cancelTanam, UIRockwool, BagUI, status, ButtonCancel, StatusRKUI;
    public static int cointSel, countBay, countBaw, countSelad, countRock;
    public static bool statTanam;
    DatabaseReference reference;
    string id, usageStatus, statRockwool;

    private void Update()
    {
        id = idName.text;
        loadData();
        
    }

    private void Start()
    {
        
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        
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
        Selada.text = e.Snapshot.Child("Inventory").Child("Seed").Child("Selada").GetValue(true).ToString();
        Rockwool.text = e.Snapshot.Child("Inventory").Child("Tools").Child("Rockwool").Child("Value").GetValue(true).ToString();
        statRockwool = e.Snapshot.Child("Inventory").Child("Tools").Child("Rockwool").Child("Lubang Status").GetValue(true).ToString();

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
       if(countSelad > 0 && statRockwool == "True")
        {
            cancelTanam.SetActive(true);
            UIRockwool.SetActive(true);
            BagUI.SetActive(false);
            statTanam = true;
            usageStatus = "Seed Selada";
            statusSeed.text = usageStatus;
            countSeed.text = countSelad.ToString();
            status.SetActive(true);
            ButtonCancel.SetActive(true);
            reference.Child(id).Child("Management").Child("Usage Status").SetValueAsync(usageStatus);
            reference.Child(id).Child("Management").Child("Status Tanam").SetValueAsync(statTanam);
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
            reference.Child(id).Child("Inventory").Child("Tools").Child("Rockwool").Child("Value").SetValueAsync(countRock);
            reference.Child(id).Child("Inventory").Child("Tools").Child("Rockwool").Child("Status").SetValueAsync("1");
            rockWoolObject.SetActive(true);
            bag.SetActive(false);
          //  StatusRKUI.SetActive(true);
        }
    }

    public void checkrock()
    {
        rockWoolObject.SetActive(true);
    }


}
