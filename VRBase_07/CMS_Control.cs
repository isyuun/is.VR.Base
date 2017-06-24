using UnityEngine;
using System.Collections;

public class CMS_Control : MonoBehaviour
{
	GameManager	gameManager;

	void Awake()
	{
		gameManager = GetComponent<GameManager>();

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		CardboardMagnetSensor.SetEnabled(true);
	}
	void Update()
	{
		if ( CardboardMagnetSensor.CheckIfWasClicked() )
		{
			gameManager.IsOnMagnet = true;

			CardboardMagnetSensor.ResetClick();
		}
	}
}

