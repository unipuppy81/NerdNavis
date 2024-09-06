using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private StatsManager statsManager;

    [Header("Gold")]
    [SerializeField] private TextMeshProUGUI goldText;

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI totalPowerText;
    [SerializeField] private TextMeshProUGUI atkText;
    [SerializeField] private TextMeshProUGUI defText;
    [SerializeField] private TextMeshProUGUI hpText;

    public void UpdateStatsText()
    {
        totalPowerText.text = statsManager.GetPower().ToString();
        atkText.text = statsManager.GetAttack().ToString();
        defText.text = statsManager.GetDefense().ToString();
        hpText.text = statsManager.GetHp().ToString();
    }
}
