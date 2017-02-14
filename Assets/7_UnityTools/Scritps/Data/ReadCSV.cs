using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Text;

public class ReadCSV : MonoBehaviour {

	public string m_LoadFileName = "";

	// Use this for initialization
	void Start () {
		StreamReader reader = new StreamReader(m_LoadFileName);
		string strLine = "";

		int lineNum = 1;
		
		while( (strLine = reader.ReadLine()) != null)
		{
			Debug.Log( string.Format( "Line : {0}", lineNum++ ) );
 
			string[] strCells = strLine.Split(',');

			foreach (var item in strCells) {
				Debug.Log( item );
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
