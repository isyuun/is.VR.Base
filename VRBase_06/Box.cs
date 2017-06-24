using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace GameScene
{
	public class Box : EventTrigger
	{
		private	GameManager	gameManager;
		private	BOX_COLOR box_color;
		public	BOX_COLOR Box_Color
		{
			get { return box_color; }
			set
			{
				box_color = value;

				switch ( box_color )
				{
					case BOX_COLOR.WHITE:	GetComponent<Renderer>().material.color = Color.white;		break;
					case BOX_COLOR.MAGENTA:	GetComponent<Renderer>().material.color = Color.magenta;	break;
					case BOX_COLOR.RED:		GetComponent<Renderer>().material.color = Color.red;		break;
					case BOX_COLOR.BLUE:	GetComponent<Renderer>().material.color = Color.blue;		break;
					case BOX_COLOR.GREEN:	GetComponent<Renderer>().material.color = Color.green;		break;
				}
			}
		}

		public void Init(Vector3 _basePos, BOX_COLOR _color)
		{
			gameManager		   = GameObject.Find("GameManager").GetComponent<GameManager>();
			Box_Color		   = _color;
			transform.position = _basePos;
		}
		public override void OnPointerEnter(PointerEventData eventData)
		{
			gameManager.Target = this;
		}
		public override void OnPointerExit(PointerEventData eventData)
		{
			if ( gameManager.Target == this ) gameManager.Target = null;
		}
		public void Change_Box_Color()
		{
			if ( (int)Box_Color < 4 )	Box_Color ++;
			else						Box_Color = 0;
		}
	}
}

