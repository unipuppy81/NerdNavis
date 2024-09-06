using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVLoadManager : Singleton<CSVLoadManager>
{
    [Header("CSV File")]
    public TextAsset itemCSV;
    public TextAsset upgradeCSV;
    public TextAsset gachaCSV;
    public TextAsset ghchaInfoCSV;

    [Header("ItemList")]
    public List<Item> weaponItems = new List<Item>();
    public List<Item> armorItems = new List<Item>();
    public List<Item> shieldItems = new List<Item>();


    [Header("ItemUpgrade")]
    public List<UpgradeData> upgradeDataList = new List<UpgradeData>();


    [Header("Gacha")]
    public List<Gacha> gachaWaeponList = new List<Gacha>();
    public List<Gacha> gachaArmorList = new List<Gacha>();
    public List<Gacha> gachaShieldList = new List<Gacha>();

    [Header("GachaInfo")]
    public List<GachaInfo> gachaInfoList = new List<GachaInfo>();

    private void Awake()
    {
        LoadItemData();
        LoadUpGradeData();
        LoadGachaData();
        LoadGachaInfo();
    }

    void LoadItemData()
    {
        string[] data = itemCSV.text.Split(new char[] { '\n' });


        for (int i = 2; i < data.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(data[i])) continue;

            string[] row = data[i].Split(',');

            Item item = new Item
            {
                s_ItemID = row[0],              // ������ ���� ID
                s_ItemGrade = row[1],           // ������ ���
                s_ItemOptionType = row[2],      // ������ �ɼ� Ÿ��
                s_DefaultValue = row[3],        // �⺻ �ɷ�ġ ��
                s_IconPath = row[4].ToUpper(),            // ������ ���
                s_itemCount = "1",
                s_itemLevel = "1"
            };

  


            switch (item.s_ItemOptionType)
            {
                case "AttackIncrease":
                    weaponItems.Add(item);
                    GameManager.Instance.string_Weapon.Add(item.s_ItemID);
                    break;
                case "DefenseIncrease":
                    armorItems.Add(item);
                    GameManager.Instance.string_Armor.Add(item.s_ItemID);
                    break;
                case "HpIncrease":
                    shieldItems.Add(item);
                    GameManager.Instance.string_Shield.Add(item.s_ItemID);
                    break;
            }
        }
    }

    void LoadUpGradeData()
    {
        string[] data = upgradeCSV.text.Split(new char[] { '\n' });
        for (int i = 2; i < data.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(data[i])) continue;

            string[] row = data[i].Split(',');

            UpgradeData upgradeData = new UpgradeData
            {
                n_UpgradeBelowLimit = int.Parse(row[0]),  // ��ȭ �ܰ� ���� ����
                n_UpgradeCost = int.Parse(row[1]),        // ��ȭ ���
                n_NormalUpgradeValue = int.Parse(row[2]), // �Ϲ� ��� ��ȭ ��
                n_RareUpgradeValue = int.Parse(row[3]),   // ��� ��� ��ȭ ��
                n_EpicUpgradeValue = int.Parse(row[4])    // ��� ��� ��ȭ ��
            };

            upgradeDataList.Add(upgradeData);
        }
    }

    void LoadGachaData()
    {
        string[] data = gachaCSV.text.Split(new char[] { '\n' });
        for (int i = 2; i < data.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(data[i])) continue;

            string[] row = data[i].Split(',');

            Gacha gacha = new Gacha
            {
                n_DropID = int.Parse(row[0]),  
                e_GachaRewardGrade = row[1],       
                e_GachaRewardItemType = row[2], 
                n_GachaRewardID = int.Parse(row[3]),
            };

            switch (gacha.e_GachaRewardItemType)
            {
                case "Weapon":
                    gachaWaeponList.Add(gacha);
                    break;
                case "Armor":
                    gachaArmorList.Add(gacha);
                    break;
                case "Shield":
                    gachaShieldList.Add(gacha);
                    break;
            }
        }
    }


    void LoadGachaInfo()
    {
        string[] data = ghchaInfoCSV.text.Split(new char[] { '\n' });
        for (int i = 2; i < data.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(data[i])) continue;

            string[] row = data[i].Split(',');

            GachaInfo gacha = new GachaInfo
            {
                n_GachaID = int.Parse(row[0]), 
                n_NormalGachaRate = int.Parse(row[1]),      
                n_RareGachaRate = int.Parse(row[2]),
                n_EpicGachaRate = int.Parse(row[3]),   
                n_GachaRandombagID = int.Parse(row[4])
            };

            gachaInfoList.Add(gacha);
        }
    }
}
