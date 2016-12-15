using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class UnityJsonTest3 : MonoBehaviour {

	public JsonData m_Target;

	public string m_JsonString;

	//public MyClass[] m_LoadedData;
	public JsonData m_Copy;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.S))
		{
			m_JsonString = JsonUtility.ToJson(m_Target);
		}

		if(Input.GetKeyUp(KeyCode.L))
		{
			m_Copy = JsonUtility.FromJson<JsonData>(m_JsonString);	
		}

	}
}
