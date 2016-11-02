using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct Vec3
{

	public float x;
	public float y;
	public float z;

	public Vec3(float a_x, float a_y, float a_z)
	{
		x = a_x;
		y = a_y;
		z = a_z;
	}

	/* Override ToString()
	public override string ToString()
	{

		return "x:" + x + " y:" + y + " z:" + z;
	}
	*/
}


public struct Vec4
{
	public float x;
	public float y;
	public float z;
	public float w;

	public Vec4(float a_x, float a_y, float a_z, float a_w)
	{
		x = a_x;
		y = a_y;
		z = a_z;
		w = a_w;
	}
}


public class TransformRecord {
	public string m_Name;
	public float m_RecordFrequency = 0.5f;
	public List<Vec3> m_PosList;	// = new List<Vec3>();
	public List<Vec4> m_AngleList;

	//public Transform m_Transform;
	//public Vector3 m_Pos;

	public TransformRecord()
	{
		m_PosList = new List<Vec3>();
		m_AngleList = new List<Vec4>();
	}
	
}



