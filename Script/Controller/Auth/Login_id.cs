using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System;
public class Login_id : MonoBehaviour
{
    public static string idLog;
    public static int switchAuth = 0;
    [SerializeField] InputField textField;

    private void Start()
    {
        switchAuth = 0;
    }

    public void getIdLogin()
    {
        switchAuth = 1;
        idLog = textField.text;
    }
}
