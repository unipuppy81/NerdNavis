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
}
