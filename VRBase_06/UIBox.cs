using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace GameScene
{
	public class UIBox : MonoBehaviour
	{
		private	BOX_COLOR box_color;
		public	BOX_COLOR Box_Color
		{
			get { return box_color; }
			set
			{
				box_color = value;

				switch ( box_color )
				{
					case BOX_COLOR.WHITE:	GetComponent<Image>().color = Color.white;		break;
					case BOX_COLOR.MAGENTA:	GetComponent<Image>().color = Color.magenta;	break;
					case BOX_COLOR.RED:		GetComponent<Image>().color = Color.red;		break;
					case BOX_COLOR.BLUE:	GetComponent<Image>().color = Color.blue;		break;
					case BOX_COLOR.GREEN:	GetComponent<Image>().color = Color.green;		break;
				}
			}
		}
		public void Init(BOX_COLOR _color, int _x, int _y)
		{
			Box_Color = _color;
		
			transform.localPosition	= new Vector3(200.0f+40.0f*_x, 150.0f-40.0f*_y, .0f);
			transform.localScale	= new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
}

