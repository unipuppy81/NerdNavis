using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int currentResources;
    private int newResources;
    private float resourceAccumulator;
    private float timer = 0;
    private float duration = 3f;


    [SerializeField] private TextMeshProUGUI resourceChargeText;
    [SerializeField] private Slider resourcesChargeSlider;


    void Start()
    {
        currentResources = GlobalValueData.n_DefaultMoneyCount;
        resourceAccumulator = 0f;
        resourcesChargeSlider.minValue = 20f;
        resourcesChargeSlider.maxValue = 100f;
        resourcesChargeSlider.value = resourcesChargeSlider.minValue;

        UpdateResourceUI();
        GameManager.Instance.uiManager.UpdateButton(false);
        StartCoroutine(AnimateSlider());
    }

    void Update()
    {
        ResourcesAccumulatorUpdate();
    }

    void ResourcesAccumulatorUpdate()
    {
        resourceAccumulator += GlobalValueData.n_RefillMoneyCount * Time.deltaTime;
        timer += Time.deltaTime;
        resourcesChargeSlider.value = resourceAccumulator;

        if (timer >= 1.0f)
        {
            resourceChargeText.text = GameManager.Instance.FormatResource(resourceAccumulator);
            timer = 0.0f;
        }

        if (resourceAccumulator >= 100)
        {
            GameManager.Instance.uiManager.UpdateButton(true);
        }
    }

    public void CollectResources()
    {
        newResources = Mathf.FloorToInt(resourceAccumulator);
        resourceAccumulator -= newResources;
        AddResources(newResources);
        GameManager.Instance.uiManager.UpdateButton(false);
    }

    private void AddResources(int amount)
    {
        currentResources = currentResources + amount;
        UpdateResourceUI();
    }

    private void UpdateResourceUI()
    {
        GameManager.Instance.uiManager.totalResourcesSet(currentResources);
    }

    private IEnumerator AnimateSlider()
    {
        while (true)
        {
            float startTime = Time.time;
            float startValue = resourcesChargeSlider.minValue;
            float endValue = resourcesChargeSlider.maxValue;

            while (Time.time - startTime < duration)
            {
                float t = (Time.time - startTime) / duration;
                resourcesChargeSlider.value = Mathf.Lerp(startValue, endValue, t);
                yield return null;
            }

            resourcesChargeSlider.value = resourcesChargeSlider.minValue;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
