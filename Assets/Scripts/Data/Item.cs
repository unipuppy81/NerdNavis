using UnityEngine;

[System.Serializable]
public class Item
{
    [Header("Data")]
    public int n_ItemID;
    public string e_ItemGrade;
    public string e_ItemOptionType; // Type 분리
    public int n_DefaultValue; // 능력치
    public string s_IconPath; // 아이콘 경로
    public int n_curUpgradeLevel;

    [Header("Option")]
    public string itemName;
    public int level;
    public int maxLevel;
    public int basePower;

    public int GetPower()
    {
        return basePower * (level + 1);
    }
}
