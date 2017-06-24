using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BOX_COLOR { RED = 0, BLUE, GREEN }
public class BoxManager3 : BoxManager
{
    float createTime;
    int boxCount;

    private void Awake()
    {
        createTime = 2.0f;
        boxCount = 0;
        InvokeRepeating("CreateBox", 0.0f, createTime);
    }

    //private void Update()
    //{
    //    createTime -= Time.deltaTime;
    //    if (createTime > 0.0f)
    //    {
    //        CreateBox();
    //        MakeBox();
    //        createTime = 1.0f;
    //    }
    //}

    private void CreateBox()
    {
        GameObject clone = base.MakeBox();
        Box2 box = clone.GetComponent<Box2>();

        clone.transform.name = string.Format("{0}{1:D3}", "BOX_", boxCount++);

        Vector3 _pos = new Vector3((float)UnityEngine.Random.Range(-3, 4), (float)UnityEngine.Random.Range(-3, 4), 20.0f);
        //_pos.x = (float)UnityEngine.Random.Range(-3, 4);
        //_pos.y = (float)UnityEngine.Random.Range(-3, 4);

        BOX_COLOR _color = (BOX_COLOR)UnityEngine.Random.Range(0, 3);

        box.Init(_pos, _color);
    }
}
