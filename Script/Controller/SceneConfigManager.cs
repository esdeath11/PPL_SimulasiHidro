﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneConfigManager : MonoBehaviour
{

    [SerializeField] GameObject menuUtama;
    [SerializeField] GameObject usernameUI;
    [SerializeField] GameObject UsernameText;
    public string username;


    public void playGame()
    {
        menuUtama.SetActive(false);
        usernameUI.SetActive(true);
    }

    public void confirmPlay()
    {
        username = UsernameText.GetComponent<Text>().text;
        print(username);
        
        SceneManager.LoadScene("GamePlay");
    }


    public void about()
    {
        SceneManager.LoadScene("");
    }
    public void help()
    {
        SceneManager.LoadScene("");
    }

    public void cancelUser()
    {
        menuUtama.SetActive(true);
        usernameUI.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
