using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class JsonData : MonoBehaviour {

//	[Serializable]
	public string m_GOName;

//	[Serializable]
	public Vector3 m_Pos;
	
	
	// Use this for initialization
	void Start () {
		m_GOName = name;
		m_Pos = transform.position;
	}

}
