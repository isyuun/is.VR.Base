using UnityEngine;
using System.Collections;

public class CMS_Control : MonoBehaviour
{
	[SerializeField] GameObject box_prefab;

	void Awake()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		CardboardMagnetSensor.SetEnabled(true);
	}
	void Update()
	{
		if ( CardboardMagnetSensor.CheckIfWasClicked() || Input.GetMouseButtonDown(0) )
		{
			GameObject clone = Instantiate(box_prefab);
			
			float fx = Random.Range(-4.0f, 4.0f);
			float fz = Random.Range(-4.0f, 4.0f);
			clone.transform.position = new Vector3(fx, 4.0f, fz);
			clone.GetComponent<Renderer>().material.color =
				new Color(Random.value, Random.value, Random.value);

			CardboardMagnetSensor.ResetClick();
		}
	}
}

