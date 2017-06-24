using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using RenderHeads.Media.AVProVideo;

public class VideoBox : EventTrigger
{
	public	string	VideoPath { private set; get; }
	SelectManager	selectManager;

	void Awake()
	{
		string strName	= name.Replace("Video", "MediaPlayer");
		VideoPath		= GameObject.Find(strName).GetComponent<MediaPlayer>().m_VideoPath;
		selectManager	= GameObject.Find("SelectManager").GetComponent<SelectManager>();
	}
	public override void OnPointerEnter(PointerEventData eventData)
	{
		selectManager.Target = this;
	}
	public override void OnPointerExit(PointerEventData eventData)
	{
		if ( selectManager.Target == this ) selectManager.Target = null;
	}
}

