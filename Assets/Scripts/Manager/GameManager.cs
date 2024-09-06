using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GachaManager gachaManager;
    public ItemManager itemManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //itemManager.GetNewItemOfGacha();
        }
    }
}
