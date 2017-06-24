using UnityEngine;
using System.Collections;
using System.IO;

public class DataManager : MonoBehaviour
{
	[SerializeField] TileManager tileManager;

	void Awake()
	{
#if UNITY_EDITOR
		LoadMapData_InEditor("RandomMaze.txt");
#endif
#if !UNITY_EDITOR && UNITY_ANDROID
		StartCoroutine(LoadMapData_InAndroid("RandomMaze.txt"));
#endif
	}
	void LoadMapData_InEditor(string _fileName)
	{
		string fileName = Path.Combine(Application.streamingAssetsPath, _fileName);
		StreamReader sr = new StreamReader(fileName);

		string		str_map_size	= sr.ReadLine();
		string[]	size_arr		= str_map_size.Split('\t');
		int			map_x			= int.Parse(size_arr[1]);
		int			map_y			= int.Parse(size_arr[2]);

		string		str_map_data	= sr.ReadToEnd();
		string[]	data_arr		= str_map_data.Split('\t');
		int[]		int_arr			= new int[data_arr.Length-1];

		for ( int i = 0; i < int_arr.Length; ++ i )
		{
			int_arr[i] = int.Parse(data_arr[i]);
		}

		sr.Close();

		tileManager.CreateAllTiles_InFile(map_x, map_y, int_arr);
	}
	IEnumerator LoadMapData_InAndroid(string _fileName)
	{
		string fileName = Path.Combine(Application.streamingAssetsPath, _fileName);
		WWW www = new WWW(fileName);
		yield return www;

		string[]	data = www.text.Split('/');

		string[]	size_arr		= data[0].Split('\t');
		int			map_x			= int.Parse(size_arr[1]);
		int			map_y			= int.Parse(size_arr[2]);

		string[]	data_arr		= data[1].Split('\t');
		int[]		int_arr			= new int[data_arr.Length-1];

		for ( int i = 0; i < int_arr.Length; ++ i )
		{
			int_arr[i] = int.Parse(data_arr[i]);
		}

		tileManager.CreateAllTiles_InFile(map_x, map_y, int_arr);
	}
}

