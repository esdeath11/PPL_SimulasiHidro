using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidationImage : MonoBehaviour
{
    public GameObject img;
    // Update is called once per frame
    public Sprite selada;

    private void Start()
    {
        
    }

    public void changeImage()
    {
        img.SetActive(true);
        img.GetComponent<Image>().sprite = selada;
    }

    void Update()
    {
      
    }
}
