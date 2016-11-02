using UnityEngine;
using System.Collections;

public class UTVertexVisualizer_1 : MonoBehaviour {
	
	public Mesh m_Mesh;
	
	public int m_VertNum = 0;
	
	public int m_Range = 16;
	
	public int m_MinIdx = 0;
	public int m_MaxIdx = 16;
	
	
	// Use this for initialization
	void Start () {
		m_Mesh = ((MeshFilter)GetComponent<MeshFilter>()).mesh;
	}
	
	
	// Update is called once per frame
	void Update () {
		
		// Min Max Index
		if(Input.GetKeyUp(KeyCode.C))
		{
			m_MinIdx -= m_Range;
			m_MaxIdx -= m_Range;
		}
		
		if(Input.GetKeyUp(KeyCode.V))
		{
			m_MinIdx += m_Range;
			m_MaxIdx += m_Range;
		}
		
		// Range
		if(Input.GetKeyUp(KeyCode.B))
		{
			m_Range--;
			m_MaxIdx = m_MinIdx + m_Range;
		}
		
		if(Input.GetKeyUp(KeyCode.N))
		{
			m_Range++;
			m_MaxIdx = m_MinIdx + m_Range;
		}
	}
	
	
	void OnGUI()
	{	
		int max = m_Mesh.vertices.Length < m_MaxIdx ? m_Mesh.vertices.Length : m_MaxIdx;
		int min = 0 > m_MinIdx ? 0 : m_MinIdx;
		
		for (int i = min; i < max; i++) {
			
			
			Vector3 vertPos = transform.TransformPoint(m_Mesh.vertices[i]);
			//Vector3 vertPos = transform.rotation * m_Mesh.vertices[i] + transform.position;	// The same as above
			
			
			Vector3 screenPos = Camera.main.WorldToScreenPoint(vertPos);
			
			GUI.Label( new Rect( screenPos.x , Screen.height -screenPos.y, 30,20), i.ToString());	
		}
	}
	
}


