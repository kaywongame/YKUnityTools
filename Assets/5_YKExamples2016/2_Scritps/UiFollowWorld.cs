using UnityEngine;
using System.Collections;

public class UiFollowWorld : MonoBehaviour {
	
	public Camera m_WorldCamera;
	public Transform m_WorldObjTransform;
	public RectTransform m_UiRectTransform;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Vector2 viewportPos = m_WorldCamera.WorldToViewportPoint(m_WorldObjTransform.position);
		m_UiRectTransform.anchorMin = viewportPos;
        m_UiRectTransform.anchorMax = viewportPos;
        //m_UiRectTransform.sizeDelta = new Vector2(500f, 200f);
	}
}
