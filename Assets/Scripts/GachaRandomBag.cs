using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GachaRandomBag", menuName = "ScriptableObjects/GachaRandomBag", order = 2)]
public class GachaRandomBag : ScriptableObject
{
    public List<Item> weaponPool;
    public List<Item> armorPool;
    public List<Item> shieldPool;
}
