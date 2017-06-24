using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public	bool	IsOnMagnet	{ set; get; }
	public	Box		Target		{ set; get; }
	
	[SerializeField] Text textScore;
	[SerializeField] Text textTargetData;
	[SerializeField] Text textPlayTime;
	int		score;
	float	playTime;

	void Awake()
	{
		IsOnMagnet	= false;
		Target		= null;
		score		= 0;
		playTime	= 300.0f;

		UpdateScore(0);
	}
	void Update()
	{
		UpdateTargetData();
		UpdatePlayTime();

		if ( IsOnMagnet )
		{
			if ( Target != null ) Target.Exit(0);

			IsOnMagnet = false;
		}
	}
	public void UpdateScore(int _score)
	{
		score += _score;
		if ( score < 0 ) score = 0;

		textScore.text = "Score : "+score;
	}
	public void UpdateTargetData()
	{
		if ( Target == null )	textTargetData.text = "Target is null";
		else					textTargetData.text = Target.name+"("+Target.BoxColor+")";
	}
	public void UpdatePlayTime()
	{
		if ( playTime > 0.0f )
		{
			playTime -= Time.deltaTime;
			textPlayTime.text = string.Format("{0}{1:D2}{2}{3:D2}", "Play Time ", (int)playTime/60, ":", (int)playTime%60);
		}
		else textPlayTime.text = "Game Over";
	}
}

