using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeTest : MonoBehaviour {

	public enum TimeOptions{
		Time,
		RealTimeSinceStartUp,
		FixedTime,
		DeltaTime,
		FixedDeltaTime,
	}

	public TimeOptions m_Option = TimeOptions.Time;
	public float m_StartTime = 0f;
	public float m_CurrentTime = 0f;
	public float m_ElapsedTime = 0f;
	public float m_Time = 0f;
	public Text m_Text;

	public float m_TimeScale = 1f;

	void CalElapsedTime()
	{
		m_CurrentTime = Time.time;
		m_ElapsedTime = m_CurrentTime - m_StartTime;

	}

	// Use this for initialization
	void Start () {
		if(m_Text == null)
		{
			m_Text = GetComponent<Text>();
		}

		m_StartTime = Time.time;
		CalElapsedTime();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyUp(KeyCode.DownArrow))
		{
			m_TimeScale -= 0.1f;
			Time.timeScale = m_TimeScale;
		}

		if(Input.GetKeyUp(KeyCode.UpArrow))	
		{
			m_TimeScale += 0.1f;
			Time.timeScale = m_TimeScale;
		}


		CalElapsedTime();
		
		switch (m_Option) {
		case TimeOptions.Time:
			m_Text.text = (m_Time = m_ElapsedTime).ToString();
			break;
		case TimeOptions.RealTimeSinceStartUp:
			m_Text.text = (m_Time = Time.realtimeSinceStartup).ToString();
			break;
		case TimeOptions.FixedTime:
			m_Text.text = (m_Time = Time.fixedTime).ToString();
			break;
		case TimeOptions.DeltaTime:
			m_Text.text = (m_Time += Time.deltaTime).ToString();
			break;
//		case TimeOptions.FixedDeltaTime:
//			m_Text.text = (m_Time += Time.fixedDeltaTime).ToString();
//			break;
		default:
			break;
		}
		
	}

	void FixedUpdate()
	{
		switch (m_Option) {
		
		case TimeOptions.FixedDeltaTime:
			m_Text.text = (m_Time += Time.fixedDeltaTime).ToString();
			break;

		default:
			break;
		}
	}
}





