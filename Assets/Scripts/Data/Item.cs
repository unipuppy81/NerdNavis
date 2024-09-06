using UnityEngine;

[System.Serializable]
public class Item
{
    [Header("Data")]
    public string s_ItemID;
    public string s_ItemGrade;
    public string s_ItemOptionType; // Type 분리
    public string s_DefaultValue; // 능력치
    public string s_IconPath; // 아이콘 경로
    public string s_curUpgradeLevel;
    public string s_itemCount;

    [Header("Option")]
    public string itemName;
    public int basePower;

    public int GetPower()
    {
        return basePower;
    }
}
