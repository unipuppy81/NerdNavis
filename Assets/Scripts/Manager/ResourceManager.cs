using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int initialResources = 500;
    public float resourceRate = 0.75f;
    public int maxResources = 100000;

    public TextMeshProUGUI resourceText;
    public Button collectButton;

    private int currentResources;
    private float resourceAccumulator;

    void Start()
    {
        currentResources = initialResources;
        resourceAccumulator = 0f;
        UpdateResourceUI();
        collectButton.interactable = false;
    }

    void Update()
    {
        resourceAccumulator += resourceRate * Time.deltaTime;
        int newResources = Mathf.FloorToInt(resourceAccumulator);
        if (newResources > 0)
        {
            resourceAccumulator -= newResources;
            AddResources(newResources);
        }

        if (currentResources >= 100)
        {
            collectButton.interactable = true;
        }
    }

    // ÀÚ¿øÈ¹µæ ¹öÆ° ¿¬°á
    public void CollectResources()
    {
        currentResources += Mathf.FloorToInt(resourceAccumulator);
        resourceAccumulator = 0f;
        UpdateResourceUI();
        collectButton.interactable = false;
    }

    private void AddResources(int amount)
    {
        currentResources = Mathf.Clamp(currentResources + amount, 0, maxResources);
        UpdateResourceUI();
    }

    private void UpdateResourceUI()
    {
        resourceText.text = FormatResource(currentResources);
    }

    private string FormatResource(int value)
    {
        if (value < 1000) return value.ToString();
        if (value < 1000000) return (value / 1000f).ToString("F2").TrimEnd('0').TrimEnd('.') + "K";
        return (value / 1000000f).ToString("F2").TrimEnd('0').TrimEnd('.') + "M";
    }
}
