using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System;

public class Tanam : MonoBehaviour
{
    [SerializeField] Sprite biji, kecambah, tunas;
    [SerializeField] Text idName, agePlan, statusTanam, countSeed;
    [SerializeField] Image water;
    public static int countSelada;
    string id, statTanam, statRockwool, aksesTanam;
    float timer = 0.0f, day, thrist, timer1, age;
    bool akses, agerestric;
    DatabaseReference reference;
    private void Start()
    {
        
        akses = false;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
       
    }

   

    void loadGame()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference(id)
        .ValueChanged += Database_ValueChanged;
    }

    private void Database_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        countSelada = int.Parse(e.Snapshot.Child("Inventory").Child("Seed").Child("Selada").GetValue(true).ToString());
        statRockwool = e.Snapshot.Child("Inventory").Child("Tools").Child("Rockwool").Child("Lubang Status").GetValue(true).ToString();
        aksesTanam = e.Snapshot.Child("Management").Child("Status Tanam").GetValue(true).ToString();
      
    }

    public void Menanam()
    {
        if(aksesTanam == "True")
        {
            if (statusTanam.text == "Seed Selada" && statRockwool == "True")
            {
                // countSelada = int.Parse(countSeed.text);
                if (countSelada > 0)
                {
                    countSelada -= 1;
                    this.GetComponent<Image>().sprite = biji;
                    this.akses = true;
                    countSeed.text = countSelada.ToString();
                    reference.Child(id).Child("Inventory").Child("Seed").Child("Selada").SetValueAsync(countSelada);
                }
                else
                {
                    Debug.Log("biji kurang");
                }

            }
        }
        
    }


    private void Update()
    {
        dayTime();
        id = idName.text;
        loadGame();
    }

    void dayTime()
    {
        if (this.akses == true)
        {
            this.timer += Time.deltaTime/5;
            this.age = timer % 60f;
            this.agePlan.text = age.ToString("0");
            this.thrist += 1*Time.deltaTime;
            thristLevel();
            pertumbuhan();

        }
    }



    void pertumbuhan()
    {
        if(this.age > 4 && this.age < 8)
        {
            this.GetComponent<Image>().sprite = kecambah;
        }
        else if(this.age > 7 && this.age < 15)
        {
            this.GetComponent<Image>().sprite = tunas;
        }
    }

    void thristLevel()
    {
        Time.timeScale = 2;
        this.water.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(29.75677f, 150f - this.thrist);
        
    }

    
}
