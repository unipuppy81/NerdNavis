using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GachaSlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Image frameImage;
    [SerializeField] private TextMeshProUGUI countText;

    [Header("Item Information")]
    public Item curItem;

    public void UpdateSlot()
    {
        ImageUpdate();
        TextUpdate();
    }

    void ImageUpdate()
    {
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
                break;
            case "Rare":
                frameImage.sprite = GameManager.Instance.rare;
                break;
            case "Epic":
                frameImage.sprite = GameManager.Instance.epic;
                break;
        }
    }


    void TextUpdate()
    {
        countText.text =  curItem.gachaCount.ToString();

    }
}
