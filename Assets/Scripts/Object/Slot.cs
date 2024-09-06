using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Image levelImage;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI upgradeText;
    







    public string itemName;
    public string itemGrade;
    public string itemType;
    public int itemValue;
    public string itemImagePath;
    public int itemCount;
}
