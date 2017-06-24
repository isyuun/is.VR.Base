using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class Circular_Gauge : MonoBehaviour
{
	private	Vector3[]	vertices;
	private	Vector2[]	uv;
	private	int[]		indices;

	private	Vector3[]	vertices2;
	private	Vector2[]	uv2;
	private	int[]		indices2;

	[Range(1,10)]
	public	int			speed = 1;

	private	float		fillAmount;
	private	float		prevFillAmount;

	private	bool		fillOn;
	public	bool		IsFull	{ private set; get; }

	void Awake()
	{
		ExitGauge();
	}
	void Update()
	{
		if ( !fillOn ) return;

		if ( fillAmount < 1.0f ) fillAmount += 0.5f * speed * Time.deltaTime;
		else					 IsFull = true;

		if ( fillAmount != prevFillAmount ) RebuildMesh();
	}
	public void EnterGauge()
	{
		fillOn = true;
	}
	public void ExitGauge()
	{
		fillAmount = .0f;

		fillOn = false;
		IsFull = false;

		RebuildMesh();
	}
	private void RebuildMesh()
	{
		Mesh		mesh		= BuildQuadMesh();
		MeshFilter	meshFilter	= GetComponent<MeshFilter>();

		if ( meshFilter != null )
			meshFilter.mesh = mesh;

		prevFillAmount = fillAmount;
	}
	private Mesh BuildQuadMesh()
	{
		vertices2	= new Vector3[10];
		uv2			= new Vector2[10];

		vertices = new Vector3[10]{new Vector3(.0f, .0f, .0f),
			new Vector3(.0f, .0f, .5f), new Vector3(.5f, .0f, .5f), new Vector3(.5f, .0f, .0f),
			new Vector3(.5f, .0f, -.5f), new Vector3(.0f, .0f, -.5f), new Vector3(-.5f, .0f, -.5f),
			new Vector3(-.5f, .0f, .0f), new Vector3(-.5f, .0f, .5f), new Vector3(.0f, .0f, .5f)};
		
		uv = new Vector2[10]{new Vector2(.5f, .5f),
			new Vector2(.5f, 1.0f), new Vector2(1.0f, 1.0f), new Vector2(1.0f, .5f),
			new Vector2(1.0f, .0f), new Vector2(.5f, .0f), new Vector2(.0f, .0f),
			new Vector2(.0f, .5f), new Vector2(.0f, 1.0f), new Vector2(.5f, 1.0f)};

		indices = new int[24]{0,1,2, 0,2,3, 0,3,4, 0,4,5, 0,5,6, 0,6,7, 0,7,8, 0,8,9};

		FillQuadData();

		Mesh mesh = new Mesh();
		mesh.name = "Generated Mesh";

		mesh.vertices	= vertices2;
		mesh.triangles	= indices2;
		mesh.uv			= uv2;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		;

		return mesh;
	}
	private void FillQuadData()
	{
		Array.Copy(vertices, vertices2, 10);
		Array.Copy(uv, uv2, 10);

		fillAmount = Mathf.Clamp01(fillAmount);

		int tri_count = (int)(fillAmount * 8.0f);

		// 8조각으로 나누어 떨어지지 않고 잔여분이 있을 경우(버텍스 정보 수정)
		if ( tri_count < fillAmount * 8.0f )
		{
			float adp_fill = -fillAmount + .25f;
			tri_count += 1;
			float nz = Mathf.Sin(adp_fill * Mathf.PI * 2) * .5f;
			float nx = Mathf.Cos(adp_fill * Mathf.PI * 2) * .5f;

			if ( Mathf.Abs(nz) > Mathf.Abs(nx) )
			{
				float nz_temp = Mathf.Sign(nz) * .5f;
				nx = nz_temp * nx / nz;
				nz = nz_temp;
			}
			else
			{
				float nx_temp = Mathf.Sign(nx) * .5f;
				nz = nx_temp * nz / nx;
				nx = nx_temp;
			}

			vertices2[tri_count+1].z = nz;
			vertices2[tri_count+1].x = nx;
			uv2[tri_count+1].x		 = nx + .5f;
			uv2[tri_count+1].y		 = nz + .5f;
		}

		indices2 = new int[3 * tri_count];
		Array.Copy(indices, indices2, 3 * tri_count);
	}
}

