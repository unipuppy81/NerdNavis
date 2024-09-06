using UnityEngine;

[System.Serializable]
public class Item
{
    [Header("Data")]
    public string s_ItemID;
    public string s_ItemGrade;
    public string s_ItemOptionType; // Type �и�
    public string s_DefaultValue; // �ɷ�ġ
    public string s_IconPath; // ������ ���
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
