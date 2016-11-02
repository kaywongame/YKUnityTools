using UnityEngine;
using System.Collections;

public class LengthAndText: MonoBehaviour {

	public Vector3 m_StartVec = Vector3.zero;
	public Vector3 m_EndVec = Vector3.zero;
	
	public enum AlignDirection {XAxis, YAxis, ZAxis};

	public AlignDirection m_Direction = AlignDirection.XAxis;
	public float m_LineOffset = 0.1f;


	// Use this for initialization
	void Start () {
	
	}
	
	void DrawLengthLines (bool a_Gizmo){
		Vector3 offsetVec;

		switch (m_Direction)
		{
			case AlignDirection.XAxis:
				offsetVec = Vector3.up * m_LineOffset;
				break;

			case AlignDirection.YAxis:
				offsetVec = Vector3.forward * m_LineOffset;
				break;

			case AlignDirection.ZAxis:
				offsetVec = Vector3.right * m_LineOffset;
				break;

			default:
				offsetVec = Vector3.zero;
				print("error");
				break;
		}

		if(a_Gizmo){
			Gizmos.matrix = transform.localToWorldMatrix;
			Gizmos.color = Color.white;
			// Length line
			Gizmos.DrawLine(m_StartVec + offsetVec, m_EndVec + offsetVec);
			// Start sub-line
			Gizmos.DrawLine(m_StartVec, m_StartVec + offsetVec);
			// End sub-line
			Gizmos.DrawLine(m_EndVec, m_EndVec + offsetVec);
		
		}else{
			// Length line
			Debug.DrawLine(m_StartVec + offsetVec, m_EndVec + offsetVec, Color.white);
			// Start sub-line
			Debug.DrawLine(m_StartVec, m_StartVec + offsetVec, Color.white);
			// End sub-line
			Debug.DrawLine(m_EndVec, m_EndVec + offsetVec, Color.white);
		
		}
		
		
	}

	// Update is called once per frame
	void Update () {
		DrawLengthLines(false);		
	}

	void OnDrawGizmos () {
		DrawLengthLines(true);
	}
}
