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
    private string type = null;

    [Header("Resource Scene")]
    [SerializeField] private TextMeshProUGUI totalResourcesText;
    [SerializeField] private TextMeshProUGUI totalPowerText;
    [SerializeField] private Slider resourcesCharge;
    [SerializeField] private Button collectionButton;
    [SerializeField] private TextMeshProUGUI isAcquireText;
    [SerializeField] private TextMeshProUGUI canAcquireAmountText;

    #region »ó´Ü ½ºÅÈÃ¢

    public void UpdateStatsText()
    {
        totalPowerText.text = statsManager.GetPower().ToString();
        atkText.text = statsManager.GetAttack().ToString();
        defText.text = statsManager.GetDefense().ToString();
        hpText.text = statsManager.GetHp().ToString();
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
    
    public void ClickOneBtn()
    {
        SetItemType();
        GameManager.Instance.itemManager.GetNewItemOfGacha(type);
        GameManager.Instance.itemManager.GachaUISetting();
        GameManager.Instance.itemManager.gachaItemList.Clear();
    }

    public void ClickTenBtn()
    {
        SetItemType();

        for (int i =0;i < 10; i++)
        {
            GameManager.Instance.itemManager.GetNewItemOfGacha(type);
        }

        GameManager.Instance.itemManager.GachaUISetting();
        GameManager.Instance.itemManager.gachaItemList.Clear();
    }

    public void ClickHundredBtn()
    {
        SetItemType();

        for (int i = 0; i < 100; i++)
        {
            GameManager.Instance.itemManager.GetNewItemOfGacha(type);
        }

        GameManager.Instance.itemManager.GachaUISetting();
        GameManager.Instance.itemManager.gachaItemList.Clear();
    }
    
    private void SetItemType()
    {
        int n = RandomCount();
        switch (n)
        {
            case 1: type = "10000"; break;
            case 2: type = "20000"; break;
            case 3: type = "30000"; break;
        }
    }

    private int RandomCount()
    {
        return Random.Range(1, 4);
    }

    #endregion

    #region ÀÚ¿ø ÅÇ

    public void ResourcesTabUpdate()
    {
        // ¸Þ´º Å¸ÀÌÆ²
        // ÀÚ¿ø ÃæÀü ÇöÈ²
        // ÀÚ¿øÈ¹µæ °¡´É À¯¹«
        // ÀÚ¿ø È¹µæ ÇöÈ²
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
