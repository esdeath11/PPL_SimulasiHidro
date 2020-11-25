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
    [SerializeField] GameObject rock, rock1, rock2, rock3, rock4, rock5, rock6, rock7, rock8, rock9;
    [SerializeField] Sprite rockhole, rockSeed, rockKecambah, rockTunas;


    public void lubangiRockwool()
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
        
    }

}
