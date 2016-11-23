using UnityEngine;
using System.Collections;

public class UiFollowWorldCam : MonoBehaviour {
	
	public Camera m_WorldCamera;
	public Transform m_WorldObjTransform;
	public RectTransform m_UiRectTransform;
    
    public float m_WidthAdj = 1f;


	// Use this for initialization
	void Start () {
        m_WidthAdj = Screen.width / Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
        m_WidthAdj = Screen.width / Screen.height;

        Vector2 viewportPos = m_WorldCamera.WorldToViewportPoint(m_WorldObjTransform.position);

        viewportPos = new Vector2(
            (viewportPos.x * m_WidthAdj) - ((m_WidthAdj - 1) * 0.5f), viewportPos.y);

		m_UiRectTransform.anchorMin = viewportPos;
        m_UiRectTransform.anchorMax = viewportPos;
        //m_UiRectTransform.sizeDelta = new Vector2(500f, 200f);
	}
}
