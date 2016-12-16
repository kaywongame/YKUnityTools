using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class UnityJsonTest2 : MonoBehaviour {

	[Serializable]
	public class MyClass
	{
		public int level;
		public float timeElapsed;
		public string playerName;
		
	}
	
	[Serializable]
	public class MyClassArray
	{
		public MyClass[] classArray = new MyClass[2];
	}

	//public MyClass[] m_DataArray = new MyClass[3];
	public MyClassArray m_DataArrayClass;

	public string m_JsonString;

	//public MyClass[] m_LoadedData;
	public MyClassArray m_LoadedDataArray;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.S))
		{
			m_JsonString = JsonUtility.ToJson(m_DataArrayClass);
		}

		if(Input.GetKeyUp(KeyCode.L))
		{
			m_LoadedDataArray = JsonUtility.FromJson<MyClassArray>(m_JsonString);	
		}

	}
}
