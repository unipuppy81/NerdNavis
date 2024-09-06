using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GachaManager gachaManager;
    public ItemManager itemManager;

    public Sprite normal, rare, epic;
    public Color normalColor, rareColor, epicColor;


    public List<Sprite> sprite_Weapon, sprite_Armor, sprite_Shield;
    public List<string> string_Weapon, string_Armor, string_Shield;
    public Dictionary<string, Sprite> imageDic;

    private void Awake()
    {
        ColorUtility.TryParseHtmlString("#9DA8B6", out normalColor);
        ColorUtility.TryParseHtmlString("#30AF52", out rareColor);
        ColorUtility.TryParseHtmlString("#41AEEE", out epicColor);

        imageDic = new Dictionary<string, Sprite>();

        DicUpdate();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //itemManager.GetNewItemOfGacha();
        }
    }

    void DicUpdate()
    {
        for(int i =0;i < sprite_Weapon.Count;i++)
        {
            imageDic.Add(string_Weapon[i], sprite_Weapon[i]);
        }

        for(int i =0;i < sprite_Armor.Count;i++)
        {
            imageDic.Add(string_Armor[i], sprite_Armor[i]);
        }

        for(int i=0; i < sprite_Shield.Count; i++)
        {
            imageDic.Add(string_Shield[i], sprite_Shield[i]);
        }
    }
}
