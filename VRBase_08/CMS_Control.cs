using UnityEngine;
using System.Collections;

public class CMS_Control : MonoBehaviour
{
	SelectManager	selectManager;

	void Awake()
	{
		selectManager = GetComponent<SelectManager>();

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		CardboardMagnetSensor.SetEnabled(true);
	}
	void Update()
	{
		if ( CardboardMagnetSensor.CheckIfWasClicked() || Input.GetMouseButtonDown(0) )
		{
			selectManager.IsOnMagnet = true;

			CardboardMagnetSensor.ResetClick();
		}
	}
}

