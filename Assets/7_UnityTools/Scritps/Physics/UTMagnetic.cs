using UnityEngine;
using System.Collections;

public class UTMagnetic : MonoBehaviour {
	
	public float m_PullPow = 3f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay (Collider a_Col)
	{
		
		Vector3 moveVec = transform.position - a_Col.transform.position;
		moveVec = moveVec.normalized;
		
		if (moveVec.magnitude > 0.5f)
		{
			float force = m_PullPow / (moveVec.magnitude * moveVec.magnitude);
			force = Mathf.Min ( force, 20f );
				
			a_Col.transform.Translate (moveVec * force * Time.deltaTime);
		}
	}
}
