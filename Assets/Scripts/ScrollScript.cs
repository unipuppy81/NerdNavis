using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollScript : ScrollRect
{
    bool forParent;
    NestedScrollManager nScrollManger;
    ScrollRect parentScrollRect;

    protected override void Start()
    {
        nScrollManger = GameObject.FindWithTag("NestedScrollManager").GetComponent<NestedScrollManager>();
        parentScrollRect = GameObject.FindWithTag("NestedScrollManager").GetComponent<ScrollRect>();
    }
    public override void OnBeginDrag(PointerEventData eventData)
    {
        forParent = Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y);

        if(forParent)
        {
            nScrollManger.OnBeginDrag(eventData);
            parentScrollRect.OnBeginDrag(eventData);
        }
        else 
            base.OnBeginDrag(eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (forParent)
        {
            nScrollManger.OnDrag(eventData);
            parentScrollRect.OnDrag(eventData);
        }
        else
            base.OnDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (forParent)
        {
            nScrollManger.OnEndDrag(eventData);
            parentScrollRect.OnEndDrag(eventData);
        }
        else
            base.OnEndDrag(eventData);
    }
}
