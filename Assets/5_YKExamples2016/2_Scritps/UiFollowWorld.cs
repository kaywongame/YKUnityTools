using UnityEngine;
using System.Collections;

public class UiFollowWorld : MonoBehaviour {
	
	public Camera m_WorldCamera;
	public Transform m_WorldObjTransform;
	public RectTransform m_UiRectTransform;

    public RectTransform m_UiCanvasRect;
    public float m_WidthAdj = 1f;

	// Use this for initialization
	void Start () {
        //Debug.Log(Screen.width);
        //m_UiCanvasRect.sizeDelta.Set(Screen.width * 0.1f, Screen.height * 0.1f);
        m_WidthAdj = Screen.width / Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Screen.width);
        Vector2 viewportPos = m_WorldCamera.WorldToViewportPoint(m_WorldObjTransform.position);

        viewportPos = new Vector2(
            ((viewportPos.x - 0.5f) * m_WidthAdj) + 0.5f, 
            viewportPos.y);
		m_UiRectTransform.anchorMin = viewportPos;
        m_UiRectTransform.anchorMax = viewportPos;
        //m_UiRectTransform.sizeDelta = new Vector2(500f, 200f);
	}
}
