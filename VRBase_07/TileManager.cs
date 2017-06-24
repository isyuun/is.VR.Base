using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TILE_TYPE { NONE=-1, ROAD=0, WALL }

public class TileManager : MonoBehaviour
{
	[SerializeField] GameObject	tilePrefab;
	List<Transform> roadList;

	public void CreateAllTiles_InFile(int _width, int _height, int[] _types)
	{
		roadList = new List<Transform>();
		for ( int y = 0; y < _height; ++ y )
		{
			for ( int x = 0; x < _width; ++ x )
			{
				int		idx = y * _width + x;
				Vector3 pos = new Vector3(-(_width*0.5f-1.0f)+x*2.0f, 0.0f, (_height*0.5f-1.0f)-y*2.0f);
				CreateTile((TILE_TYPE)_types[idx], pos);
			}
		}
	}
	void CreateTile(TILE_TYPE _type, Vector3 _pos)
	{
		GameObject clone	= Instantiate(tilePrefab) as GameObject;
		clone.name			= "Tile";
		clone.transform.SetParent(transform);

		Tile tile = clone.GetComponent<Tile>();
		tile.Init(_type, _pos);

		if ( _type == TILE_TYPE.ROAD )
			roadList.Add(tile.transform);
	}
	public List<Transform> GetRoads()	{ return roadList; }
}

