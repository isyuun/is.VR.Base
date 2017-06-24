using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager2 : BoxManager {

	// Update is called once per frame
	void Update () {
        //CancelInvoke();
        Invoke("RespawnBox", 0.1f);
	}

    void RespawnBox()
    {
        int count = box_count - GameObject.FindGameObjectsWithTag("BOX").Length;
        for (int i = 0; i < count; i++)
        {
            MakeBox();
        }
    }

}
