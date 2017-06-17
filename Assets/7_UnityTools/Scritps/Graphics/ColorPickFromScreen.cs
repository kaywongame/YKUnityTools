using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickFromScreen : MonoBehaviour
{
	Texture2D m_Tex;
	Vector3 m_MousePos;
	Vector3 m_ColorToVec;
	Color m_PickColor;
	RaycastHit m_Hit;

	// Use this for initialization
	void Start ()
	{
		
	}

	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			ShootRay ();
		}
	 
		if (m_ColorToVec != null) {
			Debug.DrawRay (m_Hit.point, m_ColorToVec.normalized, 
				new Color (1f - m_PickColor.r, 1f - m_PickColor.g, 1f - m_PickColor.b, 1f));

		}
		
	}

	void  ShootRay ()
	{
		m_MousePos = Input.mousePosition;
		Ray ray = Camera.main.ScreenPointToRay (m_MousePos);
		if (Physics.Raycast (ray, out m_Hit, 100f)) {
			Debug.DrawRay (m_Hit.point, m_Hit.normal, Color.white);
		}

		// Application.CaptureScreenshot("Assets/savedmeshes/assets/ " + "Screenshot.png");
	    
	}

	void OnPostRender ()
	{
		// Make a new texture of the right size and
		// read the camera image into it.
		m_Tex = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
		//yield  return new WaitForEndOfFrame ();
		m_Tex.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
		m_Tex.Apply ();
	 
		m_PickColor = m_Tex.GetPixel ((int)m_MousePos.x, (int)m_MousePos.y);
		print (m_PickColor);
		m_ColorToVec = new Vector3 (m_PickColor.r - 0.5f, m_PickColor.g - 0.5f, m_PickColor.b - 0.5f);
	}

 
}
