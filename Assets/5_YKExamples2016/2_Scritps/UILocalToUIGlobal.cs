using UnityEngine;
using System.Collections;

public class UILocalToUIGlobal : MonoBehaviour {
    public Transform m_WorldObjTransform;
    public RectTransform m_UiRectTransform;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        m_UiRectTransform.position = m_WorldObjTransform.position;
        
    }
}
