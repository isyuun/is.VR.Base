using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRManager : _MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
            Debug.Log(this.GetMethodName() + ":" + GvrViewer.Instance.VRModeEnabled);
        }
    }
}
