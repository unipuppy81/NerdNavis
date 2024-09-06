using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private int total_Power;
    [SerializeField] private int stats_Attack;
    [SerializeField] private int stats_Defense;
    [SerializeField] private int stats_Hp;

    private void Awake()
    {
        SetPower();
    }

    public int GetPower()
    {
        return total_Power;
    }

    public int GetAttack()
    {
        return stats_Attack;
    }

    public int GetDefense()
    {
        return stats_Defense;
    }

    public int GetHp()
    {
        return stats_Hp;
    }

    public void SetPower()
    {
        total_Power = stats_Attack + stats_Defense + stats_Hp;
    }

    public void PlusAttack(int attack)
    {
        stats_Attack += attack;
        SetPower();
    }

    public void PlusDefense(int def)
    {
        stats_Defense += def;
        SetPower();
    }

    public void PlusHp(int hp)
    {
        stats_Hp += hp;
        SetPower();
    }
}
