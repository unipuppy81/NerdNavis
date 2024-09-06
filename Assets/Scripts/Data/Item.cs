using UnityEngine;

[System.Serializable]
public class Item
{
    [Header("Data")]
    public int n_ItemID;
    public string e_ItemGrade;
    public string e_ItemOptionType; // Type �и�
    public int n_DefaultValue; // �ɷ�ġ
    public string s_IconPath; // ������ ���
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
