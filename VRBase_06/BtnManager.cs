using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace IntroScene
{
	public class BtnManager : EventTrigger
	{
		IntroManager introManager;

		void Awake()
		{
			introManager = GameObject.Find("IntroManager").GetComponent<IntroManager>();
		}
		public override void OnPointerEnter(PointerEventData eventData)
		{
			introManager.Target = this;
		}
		public override void OnPointerExit(PointerEventData eventData)
		{
			if ( introManager.Target == this )
				introManager.Target = null;
		}
		public void Btn_GameStart()
		{
			SceneManager.LoadScene("Game");
		}
		public void Btn_GameExit()
		{
			Application.Quit();
		}
	}
}

