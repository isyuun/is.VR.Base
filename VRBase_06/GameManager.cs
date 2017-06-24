using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameScene
{
	public class GameManager : MonoBehaviour
	{
		BoxManager	boxManager;
		bool		isGameOver;

		public	bool	IsOnMagnet	{ set; get; }
		public	Box		Target		{ set; get; }

		[SerializeField] Text	textPlayTime;
		[SerializeField] Text	textCount;
		float	playTime;

		void Awake()
		{
			boxManager	= GameObject.Find("BoxManager").GetComponent<BoxManager>();
			isGameOver	= false;
			IsOnMagnet	= false;
			Target		= null;
			playTime	= 0.0f;
			InvokeRepeating("UpdateTime", 1.0f, 1.0f);
		}
		void Update()
		{
			if ( Input.GetKeyDown(KeyCode.Escape) )
			{
				Application.Quit();
			}

			if ( IsOnMagnet )
			{
				if ( isGameOver )
				{
					SceneManager.LoadScene("Intro");
					return;
				}
				if ( Target != null )
				{
					Target.Change_Box_Color();
					CompareBoxs();
				}
				IsOnMagnet = false;
			}
		}
		void CompareBoxs()
		{
			Box[]	boxs	= boxManager.BoxArr;
			UIBox[]	uiboxs	= boxManager.UIBoxArr;

			int count = 0;
			for ( int i = 0; i < boxs.Length; ++ i )
			{
				if ( boxs[i].Box_Color == uiboxs[i].Box_Color )
					count ++;
			}
			textCount.text = "맞은 개수 : "+count;

			if ( count == boxs.Length )
			{
				textCount.text = "Game Clear";
				isGameOver = true;
			}
		}
		void UpdateTime()
		{
			playTime += 1.0f;
			textPlayTime.text = string.Format("{0}{1:D2}{2}{3:D2}", "PlayTime ", (int)playTime/60, ":", (int)playTime%60);
		}
	}
}

