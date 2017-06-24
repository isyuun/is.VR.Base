using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
	[SerializeField] GameManager gameManager;
	[SerializeField] GameObject	 head;
	float	speed;

	public	bool IsRun { set; get; }

	void Awake()
	{
		speed = 3.0f;
		IsRun = false;
	}
	void Update()
	{
		if ( !IsRun ) return;

		RaycastHit hit;
		Vector3 pos = head.transform.TransformDirection(Vector3.forward);
		if ( Physics.Raycast(transform.position, pos, out hit, 1.0f) )
		{
			if ( hit.transform.name.Equals("Tile") )
				return;
		}
		pos.y = 0.0f;

		transform.position += pos * speed * Time.deltaTime;
	}
	void OnTriggerEnter(Collider col)
	{
		if ( col.name.Equals("Particle") )
		{
			gameManager.CreateParticle();
			Destroy(col.gameObject);
		}
	}
}

