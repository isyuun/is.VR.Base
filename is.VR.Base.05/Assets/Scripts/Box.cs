using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Box : _EventTrigger
{
    Circular_Gauge circularGauge;
    bool isOn;

    private void Awake()
    {
        circularGauge = GameObject.Find("CircularGauge").GetComponent<Circular_Gauge>();
        isOn = false;

        GetComponent<Renderer>().material.color =  new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    private void Update()
    {
        if (!isOn)
        {
            return;
        }

        if (circularGauge != null)
        {
            circularGauge.ExitGauge();
            Destroy(gameObject);
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(this.GetMethodName());
        base.OnPointerEnter(eventData);
        circularGauge.EnterGauge();
        isOn = true;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log(this.GetMethodName());
        base.OnPointerExit(eventData);
        circularGauge.ExitGauge();
        isOn = false;
    }
}
