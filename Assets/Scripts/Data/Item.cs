using UnityEngine;

[System.Serializable]
public class Item
{
    [Header("Data")]
    public string s_ItemID;
    public string s_ItemGrade;
    public string s_ItemOptionType; // Type 
    public string s_DefaultValue; 
    public string s_IconPath; 

    [Header("Option")]
    public string s_itemCount;
    public string s_itemLevel;
    public int n_itemPower;
    public int n_needCount;

    [Header("NextUpgrade")]
    public int curCost;

    public void InitItemSet()
    {
        n_itemPower = int.Parse(s_DefaultValue);
        curCost = int.Parse(s_itemCount);
        n_needCount = 2;
    }
    public void UpGradeItem(int needUpgradeCost, int upgradeValue)
    {
        s_itemCount = "0";
        s_itemLevel = (int.Parse(s_itemLevel) + 1).ToString();
        n_itemPower += upgradeValue;
        n_needCount = needUpgradeCost;
    }
}
