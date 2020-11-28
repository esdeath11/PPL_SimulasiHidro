using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System;

public class RockwoolPlant : MonoBehaviour
{
    [SerializeField] GameObject rock, rock1, rock2, rock3, rock4, rock5, rock6, rock7, rock8, rock9, Lubang, Basah, Gelap, terang, PotonganRK, RKUtuh, ButtonUI,
        AlertUI;
    [SerializeField] Sprite rockhole, rockSeed, rockKecambah, rockTunas, rockBasah;
    [SerializeField] Image Background;
    [SerializeField] Text idName;
    DatabaseReference reference;
    bool rockStatus;
    string id;


    private void Start()
    {
        
        rockStatus = false;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    private void Update()
    {
        id = idName.text;
    }

    public void lubangiRockwool()
    {
        if(rockStatus == false)
        {
            rock.GetComponent<Image>().sprite = rockhole;
            rock1.GetComponent<Image>().sprite = rockhole;
            rock2.GetComponent<Image>().sprite = rockhole;
            rock3.GetComponent<Image>().sprite = rockhole;
            rock4.GetComponent<Image>().sprite = rockhole;
            rock5.GetComponent<Image>().sprite = rockhole;
            rock6.GetComponent<Image>().sprite = rockhole;
            rock7.GetComponent<Image>().sprite = rockhole;
            rock8.GetComponent<Image>().sprite = rockhole;
            rock9.GetComponent<Image>().sprite = rockhole;
            Lubang.SetActive(false);
            Gelap.SetActive(true);
            rockStatus = true;
            reference.Child(id).Child("Inventory").Child("Tools").Child("Rockwool").Child("Lubang Status").SetValueAsync(rockStatus);
        }
        
    }

    public void siram()
    {
        rock.GetComponent<Image>().sprite = rockBasah;
        rock1.GetComponent<Image>().sprite = rockBasah;
        rock2.GetComponent<Image>().sprite = rockBasah;
        rock3.GetComponent<Image>().sprite = rockBasah;
        rock4.GetComponent<Image>().sprite = rockBasah;
        rock5.GetComponent<Image>().sprite = rockBasah;
        rock6.GetComponent<Image>().sprite = rockBasah;
        rock7.GetComponent<Image>().sprite = rockBasah;
        rock8.GetComponent<Image>().sprite = rockBasah;
        rock9.GetComponent<Image>().sprite = rockBasah;
        Basah.SetActive(false);
        Lubang.SetActive(true);
    }

    public void tempatGelap()
    {
        terang.SetActive(true);
        Gelap.SetActive(false);
        Background.GetComponent<Image>().color = Color.black;
    }

    public void tempatTerang()
    {
        terang.SetActive(false);
        Background.GetComponent<Image>().color = Color.white;
    }

    public void PotongRockwool()
    {
        RKUtuh.SetActive(false);
        PotonganRK.SetActive(true);
        ButtonUI.SetActive(true);
        AlertUI.SetActive(true);
    }

    
}
