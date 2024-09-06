using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    private List<GachaInfo> gachaInfo = new List<GachaInfo>();

    [Header("Gacha")]
    [SerializeField] private List<Gacha> weapon;
    [SerializeField] private List<Gacha> armor;
    [SerializeField] private List<Gacha> shield;


    [Header("GachaInfo")]
    [SerializeField] private GachaInfo weaponInfo;
    [SerializeField] private GachaInfo armorInfo;
    [SerializeField] private GachaInfo shieldInfo;
    public void Start()
    {
        weapon = CSVLoadManager.Instance.gachaWaeponList;
        armor = CSVLoadManager.Instance.gachaArmorList;
        shield = CSVLoadManager.Instance.gachaShieldList;
        gachaInfo = CSVLoadManager.Instance.gachaInfoList;

        weaponInfo = FindGachaByID(10000);
        armorInfo = FindGachaByID(20000);
        shieldInfo = FindGachaByID(30000);
    }

    // ¾ÆÀÌÅÛ È®·ü
    public string GetItemID(string typeId)
    {
        string itemGrade = GetItemGrade(typeId);
        string itemType = typeId;

        List<Gacha> temp = new List<Gacha>();

        switch (typeId)
        {
            case "10000":
                temp = weapon;
                itemType = "Weapon";
                break;
            case "20000":
                temp = armor;
                itemType = "Armor";
                break;
            case "30000":
                temp = shield;
                itemType = "Shield";
                break;
        }
        
        List<Gacha> filteredItems = temp.FindAll(gacha => gacha.e_GachaRewardGrade == itemGrade);
        Gacha randomItem = new Gacha();

        if (filteredItems.Count > 0)
        {
            randomItem = filteredItems[Random.Range(0, filteredItems.Count)];
        }

        return randomItem.n_GachaRewardID.ToString();
    }

    // µî±Þ È®·ü
    public string GetItemGrade(string id)
    {
        string grade = "none";

        switch (id)
        {
            case "10000":
                grade = GetRandomItemGrade(weaponInfo);
                break;
            case "20000":
                grade = GetRandomItemGrade(armorInfo);
                break;
            case "30000":
                grade = GetRandomItemGrade(shieldInfo);
                break;
        }

        return grade;
    }

    private string GetRandomItemGrade(GachaInfo gachaInfo)
    {
        float randomValue = Random.value;
        float normalProbability = gachaInfo.GetNormalProbability();
        float rareProbability = gachaInfo.GetRareProbability();

        if (randomValue <= normalProbability)
        {
            return "Normal";
        }
        else if (randomValue <= normalProbability + rareProbability)
        {
            return "Rare";
        }
        else
        {
            return "Epic";
        }
    }

    private GachaInfo FindGachaByID(int id)
    {
        return gachaInfo.Find(gacha => gacha.n_GachaID == id);
    }
}
