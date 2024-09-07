using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ResourceManager : Singleton<ResourceManager>
{
    [SerializeField] private int currentResources;
    private int newResources;
    private float resourceAccumulator;
    private float timer = 0;
    private float duration = 3f;


    [SerializeField] private TextMeshProUGUI resourceChargeText;
    [SerializeField] private Slider resourcesChargeSlider;

    public int GetCurResource()
    {
        return currentResources;
    }

    public void ResourcesSet(int count)
    {
        currentResources += count;
        UpdateResourceUI();
    }


    void Start()
    {
        LoadGameData();
        UpdateResourceUI();
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
        resourcesChargeSlider.minValue = 20f;
        resourcesChargeSlider.maxValue = 100f;
        resourcesChargeSlider.value = resourcesChargeSlider.minValue;

        GameManager.Instance.uiManager.totalResourcesSet(currentResources);
        GameManager.Instance.uiManager.UpdateButton(false);
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

    #region 게임 종료

    void OnApplicationQuit()
    {
        SaveGameData();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveGameData();
        }
    }

    void LoadGameData()
    {
        currentResources = PlayerPrefs.GetInt("currentResources");
        resourceAccumulator = PlayerPrefs.GetFloat("resourceAccumulator");
        string lastLoginString = PlayerPrefs.GetString("LastLoginTime", "");
        if (!string.IsNullOrEmpty(lastLoginString))
        {
            DateTime lastLoginTime = DateTime.Parse(lastLoginString);
            DateTime currentTime = DateTime.Now;

            TimeSpan timeDifference = currentTime - lastLoginTime;
            double elapsedSeconds = timeDifference.TotalSeconds;

            int offlineResources = Mathf.FloorToInt((float)(elapsedSeconds * GlobalValueData.n_RefillMoneyCount));

            resourceAccumulator += offlineResources;

            if (resourceAccumulator > GlobalValueData.n_MaxMoneyLimit)
            {
                resourceAccumulator = GlobalValueData.n_MaxMoneyLimit;
            }
        }
    }

    void SaveGameData()
    {
        PlayerPrefs.SetInt("currentResources", currentResources);
        PlayerPrefs.GetFloat("resourceAccumulator", resourceAccumulator);

        string currentTime = DateTime.Now.ToString();
        PlayerPrefs.SetString("LastLoginTime", currentTime);

        PlayerPrefs.Save();
    }
    #endregion
}
