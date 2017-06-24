using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
	[Range(1, 100)]
	[SerializeField] int box_count = 100;
	[SerializeField] GameObject box_prefab;

	[SerializeField] Text textPlayTime;
	float playTime;

	void Awake()
	{
		for ( int i = 0; i < box_count; ++ i )
		{
			GameObject clone = Instantiate(box_prefab) as GameObject;
			float fx = Random.Range(-5.0f, 5.0f);
			float fy = Random.Range(-5.0f, 5.0f);
			float fz = Random.Range(-5.0f, 5.0f);
			clone.transform.position = new Vector3(fx, fy, fz);
		}

		playTime = 0.0f;
		InvokeRepeating("UpdateTime", 1.0f, 1.0f);
	}
	void UpdateTime()
	{
		playTime += 1.0f;
		textPlayTime.text = string.Format("{0:D2}{1}{2:D2}", (int)playTime/60, ":", (int)playTime%60);
	}
}


/*
void Update()
	{
		if ( Application.platform == RuntimePlatform.Android )
		{
			if ( Input.GetKeyDown(KeyCode.Escape) )
			{
				// 안드로이드 뒤로가기 키 눌렀을 때
				Application.Quit();	// 종료
			}
			else if ( Input.GetKeyDown(KeyCode.Home) )
			{
				// 안드로이드 홈 키 눌렀을 때
			}
			else if ( Input.GetKeyDown(KeyCode.Menu) )
			{
				// 안드로이드 메뉴 키 눌렀을 때
			}
		}
	}
*/