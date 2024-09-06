using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Image frameImage;
    [SerializeField] private Image levelImage;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI upgradeText;


    [Header("Item Information")]
    public string itemName;
    public string itemGrade;
    public string itemType;
    public string itemValue;
    public string itemImagePath;
    public string itemCount;
    public string itemLevel;

    public void UpdateSlot()
    {
        ImageUpdate();
        SliderUpdate();
        TextUpdate();
    }

    void ImageUpdate()
    {
        // 안되는 이유 찾지 못함
        /*
        string path = "Image_/" + itemImagePath;
        Sprite newItemSprite = Resources.Load<Sprite>(path);

        if (newItemSprite != null)
            itemImage.sprite = newItemSprite;
        */

        Sprite newItemSprite = null;

        if (GameManager.Instance.imageDic.ContainsKey(itemName))
        {
            newItemSprite = GameManager.Instance.imageDic[itemName];
            itemImage.sprite = newItemSprite;
        }

        switch (itemGrade)
        {
            case "Normal":
                frameImage.sprite = GameManager.Instance.normal;
                levelImage.color = GameManager.Instance.normalColor;
                break;
            case "Rare": 
                frameImage.sprite = GameManager.Instance.rare;
                levelImage.color = GameManager.Instance.rareColor;
                break;
            case "Epic": 
                frameImage.sprite = GameManager.Instance.epic;
                levelImage.color = GameManager.Instance.epicColor;
                break;
        }
    }


    void SliderUpdate()
    {
        // 나중에
    }

    void TextUpdate()
    {
        levelText.text = "Lv." + itemLevel;
        // upgradeText 나중에
    }
}
