using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Box2 : _EventTrigger
{
	private	GameManager		gameManager;
	private	Circular_Gauge	circularGauge;
	private	float			moveSpeed;
	private	bool			isOn;
	private	BOX_COLOR		boxColor;
	public	BOX_COLOR		BoxColor
	{
		get { return boxColor; }
		set
		{
			boxColor = value;

			switch ( boxColor )
			{
				case BOX_COLOR.RED:		GetComponent<Renderer>().material.color = Color.red;	break;
				case BOX_COLOR.BLUE:	GetComponent<Renderer>().material.color = Color.blue;	break;
				case BOX_COLOR.GREEN:	GetComponent<Renderer>().material.color = Color.green;	break;
			}
		}
	}
	public void Init(Vector3 _basePos, BOX_COLOR _color)
	{
		gameManager	  = GameObject.Find("GameManager").GetComponent<GameManager>();
		circularGauge = GameObject.Find("CircularGauge").GetComponent<Circular_Gauge>();
		moveSpeed	  = 1.0f;
		BoxColor	  = _color;
		isOn		  = false;

		transform.position = _basePos;
	}
    void Update()
    {
        transform.position += Vector3.back * moveSpeed * Time.deltaTime;

        if (isOn && circularGauge.IsFull) Exit(1);

        if (transform.position.z < -6.0f) Exit(2);
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        isOn = true;
        gameManager.Target = this;
        circularGauge.EnterGauge();
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        isOn = false;
        if (gameManager.Target == this) gameManager.Target = null;
        circularGauge.ExitGauge();
    }
    public void Exit(int _type)
    {
        Debug.Log(this.GetMethodName() + ":" + _type + ":" + BoxColor);

        // _type은 어떤 방식으로 박스에 영향을 주었는지
        // 0 : Magnet Trigger, 1 : 조준점, 2 : 종료 위치에서 사라지기
        switch (_type)
        {
            case 0:
                if (BoxColor == BOX_COLOR.RED) gameManager.UpdateScore(200);
                //else gameManager.UpdateScore(-100);
                isOn = false;
                circularGauge.ExitGauge();
                break;
            case 1:
                if (BoxColor == BOX_COLOR.BLUE) gameManager.UpdateScore(200);
                //else gameManager.UpdateScore(-100);
                isOn = false;
                circularGauge.ExitGauge();
                break;
            case 2:
                if (BoxColor == BOX_COLOR.GREEN) gameManager.UpdateScore(200);
                //else gameManager.UpdateScore(-100);
                break;
        }
        Destroy(gameObject);
    }
}
