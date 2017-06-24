using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMS_Control : _MonoBehaviour
{
    [SerializeField] GameObject box_prefab;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        CardboardMagnetSensor.SetEnabled(true);
    }

    private void Update()
    {
        if (CardboardMagnetSensor.CheckIfWasClicked() || Input.GetMouseButtonDown(0))
        {
            GameObject clone = Instantiate(box_prefab);

            float fx = UnityEngine.Random.Range(-0.4f, -0.4f);
            float fz = UnityEngine.Random.Range(-0.4f, -0.4f);
            clone.transform.position = new Vector3(fx, 4.0f, fz);
            clone.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);

            CardboardMagnetSensor.ResetClick();
        }
    }
}
