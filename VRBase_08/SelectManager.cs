using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
	public	bool		 IsOnMagnet	{ set; get; }
	public	VideoBox	 Target		{ set; get; }

	void Awake()
	{
		IsOnMagnet	= false;
		Target		= null;
	}
	void Update()
	{
		if ( IsOnMagnet )
		{
			if ( Target != null )
			{
				PlayerPrefs.SetString("VideoPath", Target.VideoPath);
				SceneManager.LoadScene("Demo360Play");
			}
			IsOnMagnet = false;
		}
	}
}

