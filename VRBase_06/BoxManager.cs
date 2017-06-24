using UnityEngine;
using System.Collections;

namespace GameScene
{
	public enum BOX_COLOR { WHITE=0, MAGENTA, RED, BLUE, GREEN }

	public class BoxManager : MonoBehaviour
	{
		[SerializeField] GameObject box_prefab;
		[SerializeField] GameObject	uiBox_prefab;

		public	Box[]	BoxArr		{ private set; get; }
		public	UIBox[]	UIBoxArr	{ private set; get; }

		void Awake()
		{
			Create_All_Box(4, 4);
		}
		private	void Create_All_Box(int width, int height)
		{
			BoxArr	 = new Box[width * height];
			UIBoxArr = new UIBox[width * height];

			for ( int y = 0; y < height; ++ y )
			{
				for ( int x = 0; x < width; ++ x )
				{
					int		idx = y * width + x;
					Vector3	pos	= new Vector3(-width*0.5f+0.5f+x, height*0.5f-0.5f-y, 0.0f);
					
					Create_Box(pos, idx);
					Create_UIBox(x, y, idx);
				}
			}
		}
		private void Create_Box(Vector3 base_pos, int _idx)
		{
			GameObject clone = Instantiate(box_prefab) as GameObject;
		
			BOX_COLOR _color = (BOX_COLOR)Random.Range(0, 5);
		
			Box box = clone.GetComponent<Box>();
			box.Init(base_pos, _color);

			BoxArr[_idx] = box;
		}
		private void Create_UIBox(int x, int y, int _idx)
		{
			GameObject clone = Instantiate(uiBox_prefab) as GameObject;

			BOX_COLOR _color = (BOX_COLOR)Random.Range(0, 5);
		
			clone.transform.SetParent(GameObject.Find("Canvas").transform);

			UIBox box = clone.GetComponent<UIBox>();
			box.Init(_color, x, y);

			UIBoxArr[_idx] = box;
		}
	}
}

