using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Text;

public class ReadCSVTextAsset : MonoBehaviour {

	public string m_LoadFileName = "";
    public TextAsset m_TextAsset;

	// Use this for initialization
	void Start () {
        m_TextAsset = (TextAsset)Resources.Load(m_LoadFileName) as TextAsset;

        Debug.Log(m_TextAsset.text);

        string[] strLines = (m_TextAsset.text).Split('\n');

		int lineNum = 1;

        for (int i = 0; i < strLines.Length; i++)
        {
            Debug.Log(string.Format("Line : {0}", lineNum++));

            string[] strCells = strLines[i].Split(',');

            foreach (var item in strCells)
            {
                Debug.Log(item);
            }
        }
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
