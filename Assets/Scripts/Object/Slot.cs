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
    public Item curItem;


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
        string path = "Image_/" + curItem.s_IconPath;
        Sprite newItemSprite = Resources.Load<Sprite>(path);

        if (newItemSprite != null)
            itemImage.sprite = newItemSprite;
        */

        Sprite newItemSprite = null;

        if (GameManager.Instance.imageDic.ContainsKey(curItem.s_ItemID))
        {
            newItemSprite = GameManager.Instance.imageDic[curItem.s_ItemID];
            itemImage.sprite = newItemSprite;
        }

        switch (curItem.s_ItemGrade)
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
        slider.maxValue = curItem.n_needCount;
        slider.value = int.Parse(curItem.s_itemCount);
    }

    void TextUpdate()
    {
        levelText.text = "Lv." + curItem.s_itemLevel;
        
    }

    public void OnClickSlot()
    {
        GameManager.Instance.ClickSlot(this);
    }
}
