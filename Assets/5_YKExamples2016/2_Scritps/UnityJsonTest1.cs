using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnityJsonTest1 : MonoBehaviour {

	[Serializable]
	public class MyClass
	{
		public int level;
		public float timeElapsed;
		public string playerName;
	}

	public MyClass m_Data1;
	public string m_JsonString;

	public MyClass m_LoadedData;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.S))
		{
			m_JsonString = JsonUtility.ToJson(m_Data1);
		}

		if(Input.GetKeyUp(KeyCode.L))
		{
			m_LoadedData = JsonUtility.FromJson<MyClass>(m_JsonString);	
		}

	}
}
