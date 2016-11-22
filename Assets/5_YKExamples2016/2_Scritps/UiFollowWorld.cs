using UnityEngine;
using System.Collections;

public class UiFollowWorld : MonoBehaviour {
	
	public Camera m_WorldCamera;
	public Transform m_WorldObjTransform;
	public RectTransform m_UiRectTransform;
	private float m_ScreenRatio = 1f;

	// Use this for initialization
	void Start () {
		m_ScreenRatio = Screen.width / Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		m_ScreenRatio = Screen.width / Screen.height;

		Vector2 viewportPos = m_WorldCamera.WorldToViewportPoint(m_WorldObjTransform.position);

		viewportPos = new Vector2(
			m_ScreenRatio * viewportPos.x - ((m_ScreenRatio - 1) * 0.5f), 
			viewportPos.y); 
		
		m_UiRectTransform.anchorMin = viewportPos;
        m_UiRectTransform.anchorMax = viewportPos;
        //m_UiRectTransform.sizeDelta = new Vector2(500f, 200f);
	}
}
