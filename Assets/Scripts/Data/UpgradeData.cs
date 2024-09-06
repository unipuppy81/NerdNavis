[System.Serializable]
public class UpgradeData
{
    public int n_UpgradeBelowLimit;  // 강화 단계 이하 조건
    public int n_UpgradeCost;        // 단계별 요구 비용
    public int n_NormalUpgradeValue; // 일반 등급 강화 능력치 증가량
    public int n_RareUpgradeValue;   // 고급 등급 강화 능력치 증가량
    public int n_EpicUpgradeValue;   // 희귀 등급 강화 능력치 증가량
}
