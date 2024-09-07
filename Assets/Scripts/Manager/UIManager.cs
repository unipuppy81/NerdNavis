using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private StatsManager statsManager;

    [Header("Gold")]
    [SerializeField] private TextMeshProUGUI goldText;

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI atkText;
    [SerializeField] private TextMeshProUGUI defText;
    [SerializeField] private TextMeshProUGUI hpText;

    [Header("PopUp")]
    [SerializeField] private GameObject popUpPanel;
    [SerializeField] private TextMeshProUGUI powerPopUpText;
    [SerializeField] private Image itemPopUpImage;
    [SerializeField] private Image itemTypeImage;
    [SerializeField] private Button exitBtn;
    [SerializeField] private Sprite atk, def, hp;


    [Header("Gacha")]
    [SerializeField] private Button oneBtn;
    [SerializeField] private Button tenBtn;
    [SerializeField] private Button hundredBtn;
    [SerializeField] private GameObject collectPanel;
    private string type = null;

    [Header("Resource Scene")]
    [SerializeField] private TextMeshProUGUI totalResourcesText;
    [SerializeField] private TextMeshProUGUI totalPowerText;
    [SerializeField] private Slider resourcesCharge;
    [SerializeField] private Button collectionButton;
    [SerializeField] private TextMeshProUGUI isAcquireText;
    [SerializeField] private TextMeshProUGUI canAcquireAmountText;
    [SerializeField] private TextMeshProUGUI titleText;

    #region »ó´Ü ½ºÅÈÃ¢

    public void UpdateStatsText()
    {
        totalPowerText.text = GameManager.Instance.FormatResource(statsManager.GetPower()).ToString();
        atkText.text = GameManager.Instance.FormatResource(statsManager.GetAttack()).ToString();
        defText.text = GameManager.Instance.FormatResource(statsManager.GetDefense()).ToString();
        hpText.text = GameManager.Instance.FormatResource(statsManager.GetHp()).ToString();
    }

    #endregion

    #region ÆË¾÷Ã¢

    public void OnClickItem(Item item)
    {
        popUpPanel.SetActive(true);
        powerPopUpText.text = item.n_itemPower.ToString();
        Sprite newItemSprite = null;

        if (GameManager.Instance.imageDic.ContainsKey(item.s_ItemID))
        {
            newItemSprite = GameManager.Instance.imageDic[item.s_ItemID];
            itemPopUpImage.sprite = newItemSprite;
        }

        switch (item.s_ItemOptionType)
        {
            case "AttackIncrease": itemTypeImage.sprite = atk; break;
            case "DefenseIncrease": itemTypeImage.sprite = def; break;
            case "HpIncrease": itemTypeImage.sprite = hp; break;
        }
    }

    public void OnClickExit()
    {
        popUpPanel.SetActive(false);
    }

    #endregion

    #region °¡Ã­
    
    public void ClickOneBtn(int count)
    {
        if(ResourceManager.Instance.GetCurResource() >= count * GlobalValueData.n_RequireGachaPrice)
        {
            ResourceManager.Instance.ResourcesSet(-count*GlobalValueData.n_RequireGachaPrice);
            GameManager.Instance.itemManager.GetNewItemOfGacha(count);
        }
    }

    public void ClickTenBtn(int count)
    {
        if (ResourceManager.Instance.GetCurResource() >= count * GlobalValueData.n_RequireGachaPrice)
        {
            ResourceManager.Instance.ResourcesSet(-count * GlobalValueData.n_RequireGachaPrice);
            GameManager.Instance.itemManager.GetNewItemOfGacha(count);
        }
    }

    public void ClickHundredBtn(int count)
    {
        if (ResourceManager.Instance.GetCurResource() >= count * GlobalValueData.n_RequireGachaPrice)
        {
            ResourceManager.Instance.ResourcesSet(-count * GlobalValueData.n_RequireGachaPrice);
            GameManager.Instance.itemManager.GetNewItemOfGacha(count);
        }
    }
   

    public void OnClickExit_Collect()
    {
        collectPanel.SetActive(false);
        GameManager.Instance.itemManager.gachaItemList.Clear();
        GameManager.Instance.itemManager.ItemPowerSetting();
        UpdateStatsText();
    }

    public void CollectPanelActive()
    {
        collectPanel.SetActive(true);
    }

    #endregion

    #region ÀÚ¿ø ÅÇ

    public void ResourcesTabUpdate(int index)
    {
        switch (index)
        {
            case 0:
                titleText.text = "Resource";
                break;
            case 1:
                titleText.text = "Gacha";
                break;
        }

    }

    public void UpdateButton(bool isAcquire)
    {
        collectionButton.interactable = isAcquire;
        isAcquireText.text = isAcquire ? "Click" : "Preparing";
    }

    public void totalResourcesSet(int amount)
    {
        totalResourcesText.text = GameManager.Instance.FormatResource(amount);
        canAcquireAmountText.text = GlobalValueData.n_RefillMoneyCount.ToString() + "/s";
    }

    public void resourcesChargeSet(int amount)
    {

    }

    #endregion
}
