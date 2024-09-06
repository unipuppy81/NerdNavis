using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GachaManager gachaManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //gachaManager.WeaponGacha();
        }
    }

    void GetRandomItem(string dropId)
    {

    }
}
