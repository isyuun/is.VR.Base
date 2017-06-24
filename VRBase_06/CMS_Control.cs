using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CMS_Control : MonoBehaviour
{
	IntroScene.IntroManager	introManager;
	GameScene.GameManager	gameManager;

	int curScene;

	void Awake()
	{
		curScene = SceneManager.GetActiveScene().buildIndex;

		if ( curScene == 0 )		introManager = GetComponent<IntroScene.IntroManager>();
		else if ( curScene == 1 )	gameManager = GetComponent<GameScene.GameManager>();

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		CardboardMagnetSensor.SetEnabled(true);
	}
	void Update()
	{
		if ( CardboardMagnetSensor.CheckIfWasClicked() || Input.GetMouseButtonDown(0) )
		{
			if ( curScene == 0 )		introManager.IsOnMagnet = true;
			else if ( curScene == 1 )	gameManager.IsOnMagnet = true;

			CardboardMagnetSensor.ResetClick();
		}
	}
}

