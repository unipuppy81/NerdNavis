using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOptionUpgradeManager : MonoBehaviour
{
    List<UpgradeData> upgradeDatas;

    private void Awake()
    {
        upgradeDatas = CSVLoadManager.Instance.upgradeDataList;
    }

    public void ItemUpgrade(Item item)
    {
        int needUpgradeCost = GetUpgradeCost(int.Parse(item.s_itemLevel) + 1);
        int upgradeValue = GetUpgradeValue(item.s_ItemGrade, int.Parse(item.s_itemLevel));

        item.UpGradeItem(needUpgradeCost, upgradeValue);
    }

    int GetUpgradeCost(int nowLevel)
    {
        foreach(var option in upgradeDatas)
        {
            if(nowLevel <= option.n_UpgradeBelowLimit)
            {
                return option.n_UpgradeCost;
            }
        }

        return 5;
    }

    int GetUpgradeValue(string grade, int nowLevel)
    {
        foreach (var option in upgradeDatas)
        {
            if (nowLevel <= option.n_UpgradeBelowLimit)
            {
                switch (grade)
                {
                    case "Normal":
                        return option.n_NormalUpgradeValue;
                    case "Rare":
                        return option.n_RareUpgradeValue;
                    case "Epic":
                        return option.n_EpicUpgradeValue;
                }
            }
        }

        return 0;
    }
}
