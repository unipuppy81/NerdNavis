using UnityEngine;

[System.Serializable]

public class GachaInfo
{
    public int n_GachaID;
    public int n_NormalGachaRate;
    public int n_RareGachaRate;
    public int n_EpicGachaRate;
    public int n_GachaRandombagID;

    public float GetNormalProbability()
    {
        int totalRate = n_NormalGachaRate + n_RareGachaRate + n_EpicGachaRate;
        return (float)n_NormalGachaRate / totalRate;
    }

    public float GetRareProbability()
    {
        int totalRate = n_NormalGachaRate + n_RareGachaRate + n_EpicGachaRate;
        return (float)n_RareGachaRate / totalRate;
    }

    public float GetEpicProbability()
    {
        int totalRate = n_NormalGachaRate + n_RareGachaRate + n_EpicGachaRate;
        return (float)n_EpicGachaRate / totalRate;
    }
}
