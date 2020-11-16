using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    float hp;
    float mana;
    float level;

    // Start is called before the first frame update
    void Start()
    {
        hp = 1;
        mana = 1;
    }

    void levelUp()
    {
        hp += level;
        mana += hp + (level / 2);
    }



    // Update is called once per frame
    void Update()
    {
        level += 1;
        levelUp();
        Debug.Log(hp);
        Debug.Log(mana);
    }
}
