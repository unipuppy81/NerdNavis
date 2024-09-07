using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;
    public Transform contentTr;

    public Slider tabSlider;
    public RectTransform[] btnRect, btnImageRect;

    const int SIZE = 2;
    float[] pos = new float[SIZE];
    float distance;
    float targetPos;
    float curPos;
    bool isDrag;
    int targetIndex;

    void Start()
    {
        distance = 1f / (SIZE - 1); 
        for(int i = 0; i < SIZE; i++) 
        {
            pos[i] = distance * i; 
        }
    }
    void Update()
    {
        tabSlider.value = scrollbar.value;

        if (!isDrag)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);

            for(int i =0;i < SIZE; i++)
            {
                btnRect[i].sizeDelta = new Vector2(i == targetIndex ? 360 : 180, btnRect[i].sizeDelta.y);
            }
        }

        if (Time.time < 0.1f) return;

        for(int i = 0; i < SIZE; i++)
        {
            Vector3 btnTargetPos = btnRect[i].anchoredPosition3D;
            Vector3 btnTargetScale = Vector3.one;
            bool textActive = false;

            if(i == targetIndex)
            {
                btnTargetPos.y = 0f;
                btnTargetScale = new Vector3(1.2f, 1.2f, 1f);
                textActive = true;
            }

            btnImageRect[i].anchoredPosition3D = Vector3.Lerp(btnImageRect[i].anchoredPosition3D, btnTargetPos, 0.25f);
            btnImageRect[i].localScale = Vector3.Lerp(btnImageRect[i].localScale, btnTargetScale, 0.25f);
            btnImageRect[i].transform.GetChild(0).gameObject.SetActive(textActive);
        }

    }

    float SetPos()
    {
        for (int i = 0; i < SIZE; i++)
        {
            if (scrollbar.value < pos[i] + distance * .5f && scrollbar.value > pos[i] - distance * .5f)
            {
                targetIndex = i;
               return pos[i];
            }
        }
        return 0;
    }

    public void OnBeginDrag(PointerEventData eventData) => curPos = SetPos();

    public void OnDrag(PointerEventData eventData) => isDrag = true;

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        targetPos = SetPos();

        if(curPos == targetPos)
        {
            if(eventData.delta.x > 18 && curPos - distance >= 0)
            {
                --targetIndex;
                targetPos = curPos - distance;
            }
            else if(eventData.delta.x < -18 && curPos + distance <= 1.01f)
            {
                ++targetIndex;
                targetPos = curPos + distance;
            }
        }

        for(int i = 0; i < SIZE; i++)
        {
            if(contentTr.GetChild(i).GetComponent<ScrollRect>() && curPos != pos[i] && targetPos == pos[i])
                contentTr.GetChild(i).GetChild(1).GetComponent<Scrollbar>().value = 1;
        }

        GameManager.Instance.uiManager.ResourcesTabUpdate(targetIndex);
    }

    public void TabClick(int n)
    {
        targetIndex = n;
        targetPos = pos[n];
        GameManager.Instance.uiManager.ResourcesTabUpdate(targetIndex);
    }


}
