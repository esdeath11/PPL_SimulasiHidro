using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nav_id : MonoBehaviour
{
    [SerializeField] GameObject reg, log, auth, menu, authMenu;
    public void accessLogin()
    {
        
        reg.SetActive(false);
        log.SetActive(true);
        auth.SetActive(false);
    }

    public void closeAuth()
    {
        auth.SetActive(true);
        log.SetActive(false);
        reg.SetActive(false);
    }

    public void accessRegister()
    {
        reg.SetActive(true);
        auth.SetActive(false);
        log.SetActive(false);
    }

    public void back()
    {
        menu.SetActive(true);
        auth.SetActive(false);
        reg.SetActive(false);
        log.SetActive(false);
        authMenu.SetActive(false);
    }
}
