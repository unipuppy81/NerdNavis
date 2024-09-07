using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
    [SerializeField] private GachaManager gachaManger;
    [SerializeField] private ItemOptionUpgradeManager itemUpgradeOption;
    [SerializeField] private StatsManager statsManager;

    [SerializeField] private GameObject[] slots;

    [SerializeField] 
    private List<Item> myItemList, curItemList;
    private List<Item> totalItem_Weapon, totalItem_Armor, totalItem_Shield;

    public List<Item> gachaItemList;

    private string curType = "AttackIncrease";
    void Start()
    {
        totalItem_Weapon = CSVLoadManager.Instance.weaponItems;
        totalItem_Armor = CSVLoadManager.Instance.armorItems;
        totalItem_Shield = CSVLoadManager.Instance.shieldItems;

        //ResetItem();
        Load();
    }

    void ResetItem()
    {
        Item BasicItem_Weapon = totalItem_Weapon.Find(x => x.s_ItemID == "101");
        Item BasicItem_Armor = totalItem_Armor.Find(x => x.s_ItemID == "201");
        Item BasicItem_Shield = totalItem_Shield.Find(x => x.s_ItemID == "301");

        BasicItem_Weapon.InitItemSet();
        BasicItem_Armor.InitItemSet();
        BasicItem_Shield.InitItemSet();


        myItemList = new List<Item>() { BasicItem_Weapon, BasicItem_Armor, BasicItem_Shield };
        Save();
    }

    #region ������ ȹ�� & ������

    public void GetItem_Weapon(string itemId)
    {
        Item curItem = myItemList.Find(x => x.s_ItemID.Equals(itemId));
        Item gachaItem = gachaItemList.Find(x => x.s_ItemID.Equals(itemId));
        if(curItem != null)
        {
            curItem.s_itemCount = int.Parse((curItem.s_itemCount + 1)).ToString();
            gachaItem.s_itemCount = int.Parse((gachaItem.s_itemCount + 1)).ToString();
        }
        else
        {
            Item findItem = totalItem_Weapon.Find(x => x.s_ItemID == itemId);
            if(findItem != null)
            {
                findItem.s_itemCount = "1";
                findItem.InitItemSet();
                myItemList.Add(findItem);
                gachaItemList.Add(findItem);
            }
        }


        if (int.Parse(curItem.s_itemCount) == curItem.n_needCount)
        {
            itemUpgradeOption.ItemUpgrade(curItem);
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
        Item curItem = myItemList.Find(x => x.s_ItemID.Equals(itemId));
        Item gachaItem = gachaItemList.Find(x => x.s_ItemID.Equals(itemId));
        if (curItem != null)
        {
            curItem.s_itemCount = int.Parse((curItem.s_itemCount + 1)).ToString();
            gachaItem.s_itemCount = int.Parse((gachaItem.s_itemCount + 1)).ToString();
        }
        else
        {
            Item findItem = totalItem_Armor.Find(x => x.s_ItemID == itemId);
            if (findItem != null)
            {
                findItem.s_itemCount = "1";
                findItem.InitItemSet();
                myItemList.Add(findItem);
                gachaItemList.Add(findItem);
            }
        }


        if (int.Parse(curItem.s_itemCount) == curItem.n_needCount)
        {
            itemUpgradeOption.ItemUpgrade(curItem);
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
        Item curItem = myItemList.Find(x => x.s_ItemID.Equals(itemId));
        Item gachaItem = gachaItemList.Find(x => x.s_ItemID.Equals(itemId));
        if (curItem != null)
        {
            curItem.s_itemCount = int.Parse((curItem.s_itemCount + 1)).ToString();
            gachaItem.s_itemCount = int.Parse((gachaItem.s_itemCount + 1)).ToString();
        }
        else
        {
            Item findItem = totalItem_Shield.Find(x => x.s_ItemID == itemId);
            if (findItem != null)
            {
                findItem.s_itemCount = "1";
                findItem.InitItemSet();
                myItemList.Add(findItem);
                gachaItemList.Add(findItem);
            }
        }

        if (int.Parse(curItem.s_itemCount) == curItem.n_needCount)
        {
            itemUpgradeOption.ItemUpgrade(curItem);
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

    public void TabClick(string tabName)
    {
        curType = tabName;
        curItemList = myItemList.FindAll(x => x.s_ItemOptionType == tabName);

        for(int i =0;i < slots.Length; i++)
        {
            Slot s = slots[i].GetComponent<Slot>();

            bool isExist = i < curItemList.Count;
            slots[i].SetActive(isExist);

            if (isExist)
            {
                s.curItem = curItemList[i];
                s.UpdateSlot();
            }
        }

        int tabNum = 0;
        switch (tabName)
        {
            case "AttackIncrease": tabNum = 0; break;
            case "DefenseIncrease": tabNum = 1; break;
            case "HpIncrease": tabNum = 2; break;
        }

    }

    public void ItemPowerSetting()
    {
        foreach(Item item in myItemList)
        {
            string itemType = item.s_ItemOptionType;
            switch (itemType)
            {
                case "AttackIncrease": statsManager.PlusAttack(item.n_itemPower);  break;
                case "DefenseIncrease": statsManager.PlusDefense(item.n_itemPower); break;
                case "HpIncrease": statsManager.PlusHp(item.n_itemPower); break;
            }
        }
    }

    #endregion

    #region ��í
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


    public void GachaUISetting()
    {

    }

    #endregion


    #region JSON
    void Save()
    {
        string jdata = JsonConvert.SerializeObject(myItemList);
        File.WriteAllText(Application.dataPath + "/Resources/MyItemText.txt", jdata);

        TabClick(curType);
    }

    void Load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/Resources/MyItemText.txt");
        myItemList = JsonConvert.DeserializeObject<List<Item>>(jdata);

        ItemPowerSetting();
        GameManager.Instance.uiManager.UpdateStatsText();
        TabClick(curType);
    }
    #endregion
}
