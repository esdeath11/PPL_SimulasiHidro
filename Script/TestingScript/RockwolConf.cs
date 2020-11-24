using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockwolConf : MonoBehaviour
{
   // [SerializeField] Button potonganRockwol;
    [SerializeField] Sprite kering, basah, potKering, potKeringBiji;
    [SerializeField] GameObject buttonOptions;
    [SerializeField] GameObject GridRockwol;

    bool statusOptions;

    private void Start()
    {
        this.statusOptions = false;
    }

    public void siram()
    {
       this.GetComponent<Image>().sprite = basah;
    }

    public void options()
    {
        if (this.statusOptions == false)
        {
            GridRockwol.GetComponent<GridLayoutGroup>().spacing = new Vector2(0, 120);
            
            this.buttonOptions.SetActive(true);
            this.statusOptions = true;
            Debug.Log(statusOptions);
        }
        else if (this.statusOptions == true)
        {
            GridRockwol.GetComponent<GridLayoutGroup>().spacing = new Vector2(0, 20);
            this.buttonOptions.SetActive(false);
            this.statusOptions = false;
            Debug.Log(statusOptions);
        }
        Debug.Log(statusOptions);
        
    }


}
