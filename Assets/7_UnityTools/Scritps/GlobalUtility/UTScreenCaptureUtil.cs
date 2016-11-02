using UnityEngine;
using System.Collections;

public class UTScreenCaptureUtil : MonoBehaviour {
	public int m_Scale = 1;
	public KeyCode m_CaptureKey = KeyCode.C;
	public string m_CaptureName = "./Asset/Screenshot";
	public int m_Postfix = 1;
	
	void Update()
	{
		if(Input.GetKeyDown(m_CaptureKey)) Capture();
			
	}
	
	void Capture() {
        Application.CaptureScreenshot(m_CaptureName + m_Postfix++ + ".png", m_Scale);
		print ("Shot");
    }
}
