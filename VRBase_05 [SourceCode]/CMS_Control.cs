using UnityEngine;
using System.Collections;

public class CMS_Control : MonoBehaviour
{
	GameManager	gameManager;

	void Awake()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
		CardboardMagnetSensor.SetEnabled(true);

		gameManager = GetComponent<GameManager>();
	}
	void Update()
	{
		if ( CardboardMagnetSensor.CheckIfWasClicked() || Input.GetMouseButtonDown(0) )
		{
			gameManager.IsOnMagnet = true;

			CardboardMagnetSensor.ResetClick();
		}
	}
}

