using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
    [SerializeField] GachaManager gachaManger;

    [SerializeField] 
    private List<Item> myItemList;
    private List<Item> totalItem_Weapon, totalItem_Armor, totalItem_Shield;
    void Start()
    {
        totalItem_Weapon = CSVLoadManager.Instance.weaponItems;
        totalItem_Armor = CSVLoadManager.Instance.armorItems;
        totalItem_Shield = CSVLoadManager.Instance.shieldItems;

        Load();
    }

    public void GetNewItemOfGacha(string typeId)
    {
        switch (typeId)
        {
            case "10000":
                string itemId_w = gachaManger.GetItemID("10000");
                GetItem_Weapon(itemId_w);
                break;
            case "20000":
                string itemId_a = gachaManger.GetItemID("20000");
                GetItem_Weapon(itemId_a);
                break;
            case "30000":
                string itemId_s = gachaManger.GetItemID("30000");
                GetItem_Weapon(itemId_s);
                break;
        }
    }

    public void GetItem_Weapon(string itemId)
    {
        Item curItem = myItemList.Find(x => x.s_ItemID == itemId);

        if(curItem != null)
        {
            curItem.s_itemCount = int.Parse((curItem.s_itemCount + 1)).ToString();
            // °ñµå °¨¼Ò
        }
        else
        {
            Item findItem = totalItem_Weapon.Find(x => x.s_ItemID == itemId);
            if(findItem != null )
            {
                findItem.s_itemCount = "1";
                myItemList.Add(findItem);
                // °ñµå °¨¼Ò
            }
        }

        myItemList.Sort((p1, p2) =>
        {
            try
            {
                int index1 = int.Parse(p1.s_ItemID);
                int index2 = int.Parse(p2.s_ItemID);
                return index1.CompareTo(index2);
            }
            catch (FormatException)
            {
                return p1.s_ItemID.CompareTo(p2.s_ItemID);
            }
        });

        Save();
    }

    public void GetItem_Armor(string itemId)
    {
        Item curItem = myItemList.Find(x => x.s_ItemID == itemId);

        if (curItem != null)
        {
            curItem.s_itemCount = int.Parse((curItem.s_itemCount + 1)).ToString();
            // °ñµå °¨¼Ò
        }
        else
        {
            Item findItem = totalItem_Armor.Find(x => x.s_ItemID == itemId);
            if (findItem != null)
            {
                findItem.s_itemCount = "1";
                myItemList.Add(findItem);
                // °ñµå °¨¼Ò
            }
        }

        myItemList.Sort((p1, p2) =>
        {
            try
            {
                int index1 = int.Parse(p1.s_ItemID);
                int index2 = int.Parse(p2.s_ItemID);
                return index1.CompareTo(index2);
            }
            catch (FormatException)
            {
                return p1.s_ItemID.CompareTo(p2.s_ItemID);
            }
        });

        Save();
    }

    public void GetItem_Shield(string itemId)
    {
        Item curItem = myItemList.Find(x => x.s_ItemID == itemId);

        if (curItem != null)
        {
            curItem.s_itemCount = int.Parse((curItem.s_itemCount + 1)).ToString();
            // °ñµå °¨¼Ò
        }
        else
        {
            Item findItem = totalItem_Shield.Find(x => x.s_ItemID == itemId);
            if (findItem != null)
            {
                findItem.s_itemCount = "1";
                myItemList.Add(findItem);
                // °ñµå °¨¼Ò
            }
        }

        myItemList.Sort((p1, p2) =>
        {
            try
            {
                int index1 = int.Parse(p1.s_ItemID);
                int index2 = int.Parse(p2.s_ItemID);
                return index1.CompareTo(index2);
            }
            catch (FormatException)
            {
                return p1.s_ItemID.CompareTo(p2.s_ItemID);
            }
        });

        Save();
    }

    void Save()
    {
        string jdata = JsonConvert.SerializeObject(myItemList);
        File.WriteAllText(Application.dataPath + "/Resources/MyItemText.txt", jdata);
    }

    void Load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/Resources/MyItemText.txt");
        myItemList = JsonConvert.DeserializeObject<List<Item>>(jdata);
    }
}
