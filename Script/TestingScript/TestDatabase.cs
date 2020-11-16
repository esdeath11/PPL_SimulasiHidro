using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System;

public class TestDatabase : MonoBehaviour
{
    DatabaseReference reference;
    [SerializeField] InputField textField;
    [SerializeField] Text loadedText;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }



    public void saveData()
    {
        reference.Child("Users").Child("User 1").Child("Email").SetValueAsync(textField.text.ToString());
    }

    public void loadData()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference("Users")
        .ValueChanged += TestDatabase_ValueChanged;
    }

    private void TestDatabase_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Debug.Log(e.Snapshot.Child("User 1").Child("Email").GetValue(true));
        loadedText.text = e.Snapshot.Child("User 1").Child("Email").GetValue(true).ToString();
    }

    public void checkData()
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("Leaders")
      .GetValueAsync().ContinueWith(task =>
      {
          if (task.IsFaulted)
          {
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              Debug.Log(snapshot.Child("User 1").Child("Email").GetValue(true));
          }
      });
    }
}
