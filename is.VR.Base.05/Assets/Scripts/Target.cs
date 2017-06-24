using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : _MonoBehaviour
{
    [SerializeField] Circular_Gauge circularGauge;

    private void Update()
    {
        if (circularGauge != null && circularGauge.IsFull)
        {
            circularGauge.ExitGauge();
            OnEvent();
        }
    }

    public void OnEvent()
    {
        GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }
}
