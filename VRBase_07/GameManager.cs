using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	[SerializeField] CameraManager	cameraManager;
	[SerializeField] GameObject		particlePrefab;
	[SerializeField] TileManager	tileManager;

	public	bool	IsOnMagnet	{ set; get; }
	
	void Awake()
	{
		IsOnMagnet = false;
		Invoke("CreateParticle", 3.0f);
	}
	void Update()
	{
#if UNITY_EDITOR
		if ( Input.GetKeyDown(KeyCode.Space) )
			cameraManager.IsRun = !cameraManager.IsRun;
#endif
#if !UNITY_EDITOR && UNITY_ANDROID
		if ( IsOnMagnet )
		{
			cameraManager.IsRun = !cameraManager.IsRun;
			IsOnMagnet = false;
		}
#endif
	}
	public void CreateParticle()
	{
		GameObject clone = Instantiate(particlePrefab);
		clone.name = "Particle";

		int idx = Random.Range(0, tileManager.GetRoads().Count);
		clone.transform.position = tileManager.GetRoads()[idx].position;
	}
}

