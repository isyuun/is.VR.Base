using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : _MonoBehaviour
{
    [UnityEngine.Range(1, 100)]
    [SerializeField]
    protected int box_count = 100;
    [SerializeField] GameObject box_prefab;

    [SerializeField] Text textPlayTime;
    float playTime;

    private void Awake()
    {
        for (int i = 0; i < box_count; i++)
        {
            MakeBox();
        }

        playTime = 0.0f;
        InvokeRepeating("UpdateTime", 1.0f, 1.0f);
    }

    protected GameObject MakeBox()
    {
        GameObject clone = Instantiate(box_prefab);

        float fx = UnityEngine.Random.Range(-5.0f, 5.0f);
        float fy = UnityEngine.Random.Range(-5.0f, 5.0f);
        float fz = UnityEngine.Random.Range(-5.0f, 5.0f);
        clone.transform.position = new Vector3(fx, fy, fz);

        return clone;
    }

    void UpdateTime()
    {
        playTime += 1.0f;
        textPlayTime.text = string.Format("{0:D2}{1}{2:D2}", (int)playTime / 60, ":", (int)playTime % 60);
    }
}
