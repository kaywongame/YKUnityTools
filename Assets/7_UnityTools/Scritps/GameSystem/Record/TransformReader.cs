using UnityEngine;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

public class TransformReader : MonoBehaviour {

	public bool m_PlayRecord = false;

	public string m_LoadFileName = "";
	//public string m_JsonString;
	TransformRecord m_RecordTransform;


	// Use this for initialization
	void Start () {
		StreamReader reader = new StreamReader(".\\" + m_LoadFileName);
		string jsonString = "";

		try
		{
			jsonString = reader.ReadToEnd();

		}

		catch
		{
			print("File is empty");
		}

		finally
		{
			reader.Close();
		}

		m_RecordTransform = new TransformRecord();

		m_RecordTransform = JsonConvert.DeserializeObject<TransformRecord>(jsonString);


		if(m_PlayRecord)
			StartCoroutine(ReadTransform());
	}

	public IEnumerator ReadTransform()
	{

		for (int i = 0; i < m_RecordTransform.m_PosList.Count; i++)
		{
			transform.localPosition = new Vector3(m_RecordTransform.m_PosList[i].x,
															m_RecordTransform.m_PosList[i].y,
															m_RecordTransform.m_PosList[i].z);

			yield return new WaitForSeconds(m_RecordTransform.m_RecordFrequency);

		}

		print(m_RecordTransform.m_Name + " : Record Play Finished");
		yield return null;
	}

}
