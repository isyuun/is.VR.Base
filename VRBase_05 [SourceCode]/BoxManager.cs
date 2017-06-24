using UnityEngine;
using System.Collections;

public enum BOX_COLOR { RED=0, BLUE, GREEN }

public class BoxManager : MonoBehaviour
{
	[SerializeField] GameObject box_prefab;

	//float	createTime;
	int		boxCount;

	void Awake()
	{
		//createTime	= 1.0f;
		boxCount	= 0;
		InvokeRepeating("CreateBox", 0.0f, 1.0f);
	}
	/*void Update()
	{
		createTime -= Time.deltaTime;
		if ( createTime <= 0.0f )
		{
			CreateBox();
			createTime = 1.0f;
		}
	}*/
	void CreateBox()
	{
		GameObject	clone = Instantiate(box_prefab);
		Box			box	  = clone.GetComponent<Box>();

		clone.transform.name = string.Format("{0}{1:D3}", "BOX_", boxCount++);

		Vector3 _pos;
		_pos.x = (float)Random.Range(-3, 4);
		_pos.y = (float)Random.Range(-3, 4);
		_pos.z = 20.0f;

		BOX_COLOR _color = (BOX_COLOR)Random.Range(0, 3);

		box.Init(_pos, _color);
	}
}

