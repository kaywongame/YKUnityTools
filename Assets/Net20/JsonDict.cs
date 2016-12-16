using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine.UI;

public class JsonDict : MonoBehaviour {

	
	[Serializable]
	public class MyStruct{

		public Dictionary<string, int> points;
	}
	
	public MyStruct m_Struct;	 
	public string json;
	public MyStruct m_StructLoaded;	 

	public Text Output;

    void WriteLine(string msg)
    {
        Output.text = Output.text + msg + "\n";
    }

	// Use this for initialization
	void Start () {
		m_Struct.points = new Dictionary<string, int>
		 {
		     { "James", 9001 },
		     { "Jo", 3474 },
		     { "Jess", 11926 }
		 };

		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.S))
		{
			json = JsonConvert.SerializeObject(m_Struct, Formatting.Indented);
			WriteLine(json);
		}

		if(Input.GetKeyUp(KeyCode.L))
		{
			m_StructLoaded = (MyStruct)JsonConvert.DeserializeObject(json, typeof(MyStruct));

			foreach (var item in m_StructLoaded.points) {
				Debug.Log(item.Key + " : " + item.Value);
			}
		}

		
	}
}
