using UnityEngine;
using System.Collections;
using RenderHeads.Media.AVProVideo;

public class PlayManager : MonoBehaviour
{
	[SerializeField] MediaPlayer mediaPlayer;

	void Awake()
	{
		string path = PlayerPrefs.GetString("VideoPath");

		mediaPlayer.m_VideoPath = path;
	}
}

