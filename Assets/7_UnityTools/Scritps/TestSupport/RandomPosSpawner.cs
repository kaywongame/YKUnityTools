using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosSpawner : MonoBehaviour {

	public Vector3 m_SizeVec = Vector3.one;
	

	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		
	}


	void OnDrawGizmos()
	{
		Vector3 rightOffset = transform.right * m_SizeVec.x * 0.5f;
		Vector3 upOffset = transform.up * m_SizeVec.y * 0.5f;
		Vector3 frontOffset = transform.forward * m_SizeVec.z * 0.5f;

//		Vector3 topRightFront = transform.position + rightOffset + upOffset + frontOffset;
//		Vector3 topLeftFront = transform.position - rightOffset + upOffset + frontOffset;
//		Vector3 bottomRightFront = transform.position + rightOffset - upOffset + frontOffset;							
//		Vector3 bottomLeftFront = transform.position - rightOffset - upOffset + frontOffset;

		Vector3[] poss = new Vector3[8];
		int i = 0;

		for (int x = -1; x < 2; x+=2) {
			for (int y = -1; y < 2; y+=2) {
				for (int z = -1; z < 2; z+=2) {

					poss[i++] = transform.position + rightOffset * x + upOffset * y + frontOffset * z;
					
				}
			}
		}
		// z
		Gizmos.DrawLine(poss[0],poss[1]);
		Gizmos.DrawLine(poss[2],poss[3]);
		Gizmos.DrawLine(poss[4],poss[5]);
		Gizmos.DrawLine(poss[6],poss[7]);
		// y
		Gizmos.DrawLine(poss[0],poss[2]);
		Gizmos.DrawLine(poss[1],poss[3]);
		Gizmos.DrawLine(poss[4],poss[6]);
		Gizmos.DrawLine(poss[5],poss[7]);
		// x
		Gizmos.DrawLine(poss[0],poss[4]);
		Gizmos.DrawLine(poss[1],poss[5]);
		Gizmos.DrawLine(poss[2],poss[6]);
		Gizmos.DrawLine(poss[3],poss[7]);

		//Gizmos.DrawCube(transform.position, m_SizeVec);
	}
	
}
