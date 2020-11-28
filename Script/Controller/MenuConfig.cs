using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuConfig : MonoBehaviour
{
   
    [SerializeField] GameObject menuShop;
    [SerializeField] GameObject menuBag;
    [SerializeField] GameObject validationButton;
 


    private void Start()
    {

    }

    public void BMenuShop()
    {
        menuShop.gameObject.SetActive(true);
        
        menuBag.gameObject.SetActive(false);
        validationButton.gameObject.SetActive(false);
    }


    public void BMenuBag()
    {
        menuBag.gameObject.SetActive(true);
        menuShop.gameObject.SetActive(false);
       
    }

    public void closeMenu()
    {
        menuBag.gameObject.SetActive(false);
        menuShop.gameObject.SetActive(false);
    }

    public void mainGame()
    {
        
    }

   


}
