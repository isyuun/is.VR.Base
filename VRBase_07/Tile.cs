using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
	[SerializeField]
	Texture2D[] tex;
	Renderer	render;

	private	TILE_TYPE	tileType;
	public	TILE_TYPE	TileType
	{
		get { return tileType; }
		set
		{
			tileType = value;
			render.material.mainTexture		 = tex[(int)tileType];
			render.material.mainTextureScale = new Vector2(2.0f, 2.0f);

			switch ( tileType )
			{
				case TILE_TYPE.WALL:
					transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
					Vector3 pos = transform.position;
					pos.y = 0.95f;
					transform.position = pos;
					break;
				case TILE_TYPE.ROAD:
					transform.localScale = new Vector3(2.0f, 0.1f, 2.0f);
					break;
			}
		}
	}
	public void Init(TILE_TYPE _type, Vector3 _pos)
	{
		render				= GetComponent<Renderer>();
		transform.position	= _pos;
		TileType			= _type;
	}
}

