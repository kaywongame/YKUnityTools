using UnityEngine;
using System.Collections;
using System.IO;
using Newtonsoft.Json;


public class TransformRecorder : MonoBehaviour {
	
	private TransformRecord m_RecordTransform;
	
	public bool m_TestRecord = false;
	public TextMesh m_DebugText;
	
	public bool m_Record = false;
	public bool m_RecordPos = false;
	public bool m_RecordRot = false;
	
	public float m_RecordFrequency = 0.5f;	// every 0.5s

	public string m_SaveFileName = "";

	void TestCase1()
	{
		m_RecordTransform.m_PosList.Add(new Vec3(0, 0, 0));
		m_RecordTransform.m_PosList.Add(new Vec3(0, 0, 1));
		m_RecordTransform.m_PosList.Add(new Vec3(0, 0, 2));

		string jsonString = JsonConvert.SerializeObject(m_RecordTransform, Formatting.Indented);
		print(jsonString);
	}

	// Use this for initialization
	void Start()
	{
		if(m_SaveFileName == "")
		{
			m_SaveFileName = name + ".txt";
		}

		m_RecordTransform = new TransformRecord();
		m_RecordTransform.m_Name = name;
		
		if(m_TestRecord)	TestCase1();

		// Start Recording
		StartCoroutine(Record());
	}

	public IEnumerator Record()
	{
		while(m_Record)
		{
			if(m_RecordPos)
			{
				m_RecordTransform.m_PosList.Add(new Vec3(transform.localPosition.x,
															transform.localPosition.y,
															transform.localPosition.z));
			}
			
			if(m_RecordRot)
			{
				m_RecordTransform.m_AngleList.Add(new Vec4(transform.localRotation.x,
																	transform.localRotation.y,
																	transform.localRotation.z,
																	transform.localRotation.w));
			}
			
			yield return new WaitForSeconds(m_RecordFrequency);
		}

		yield return null;
	}

	

	void OnApplicationQuit()
	{
		// Put last value mark
		//m_RecordTransform.m_PosList.Add(new Vec3(20000, 0, 2));

		m_RecordTransform.m_RecordFrequency = m_RecordFrequency;

		string jsonString = JsonConvert.SerializeObject(m_RecordTransform, Formatting.Indented);
		//print(jsonString);

		// Write to file
		if (m_RecordTransform.m_PosList.Count > 0)
		{
			StreamWriter fileW = new StreamWriter(".\\" + m_SaveFileName);
			fileW.Write(jsonString);
			fileW.Close();
		}

		

	}
}

