using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    public Text playerStatsText;

    private Dictionary<string, Item> playerItems = new Dictionary<string, Item>();
    private int playerPower = 0;

    private GameObject obj;

    void Start()
    {
        foreach (var item in itemDatabase.items)
        {
            //playerItems[item.itemName] = Instantiate(item);
        }
        UpdatePlayerStats();
    }

    public void Gacha(string itemName)
    {
        if (playerItems.ContainsKey(itemName))
        {
            var item = playerItems[itemName];
            if (item.level < item.maxLevel)
            {
                item.level++;
                UpdatePlayerStats();
            }
        }
    }

    private void UpdatePlayerStats()
    {
        playerPower = 0;
        foreach (var item in playerItems.Values)
        {
            playerPower += item.GetPower();
        }
        playerStatsText.text = "Power: " + playerPower;
    }
}
