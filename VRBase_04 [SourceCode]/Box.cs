using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Box : EventTrigger
{
    private Circular_Gauge circularGauge;
    private bool isOn;

    private void Awake()
    {
        circularGauge = GameObject.Find("CircularGauge").GetComponent<Circular_Gauge>();
        isOn = false;

        GetComponent<Renderer>().material.color =
            new Color(Random.value, Random.value, Random.value);
    }

    private void Update()
    {
        if (!isOn) return;

        if (circularGauge.IsFull)
        {
            circularGauge.ExitGauge();
            Destroy(gameObject);
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        circularGauge.EnterGauge();
        isOn = true;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        circularGauge.ExitGauge();
        isOn = false;
    }
}