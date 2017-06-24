using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
	[SerializeField] Circular_Gauge circularGauge;

	void Update()
	{
		if ( circularGauge.IsFull )
		{
			circularGauge.ExitGauge();
			OnEvent();
		}
	}
	public void OnEvent()
	{
		GetComponent<Renderer>().material.color =
			new Color(Random.value, Random.value, Random.value);
	}
}

