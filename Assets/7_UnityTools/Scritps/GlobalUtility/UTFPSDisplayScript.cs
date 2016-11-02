using UnityEngine;
using System.Collections;



public class UTFPSDisplayScript : MonoBehaviour
{
	float timeA;

	//public UILabel m_Text;
	public int fps;

	public int lastFPS;

	private float m_Timer;
	//public GUIStyle textStyle;

	void Start()
	{
		timeA = Time.timeSinceLevelLoad;
		DontDestroyOnLoad(this);
		m_Timer = 0f;
	}

	void Update()
	{

		//Debug.Log(Time.timeSinceLevelLoad+" "+timeA);

		if (Time.timeSinceLevelLoad - timeA <= 1)
		{
			fps++;
		}

		else
		{
			lastFPS = fps + 1;
			timeA = Time.timeSinceLevelLoad;
			fps = 0;
		}


		m_Timer += Time.deltaTime;


		//if( ( (int)m_Timer & 2 ) == 2)
		//{
		//	m_Text.text = lastFPS.ToString() + "           ";
		//}
		//else
		//{
		//	m_Text.text = "           " + lastFPS.ToString();
		//}
		
	}
	
	/*
	void OnGUI()
	{
		GUI.Label(new Rect(450, 5, 30, 30), "" + lastFPS, textStyle);
	}
	*/

}