using UnityEngine;
using System.Collections;

public class QuaternionTest1 : MonoBehaviour {
 
   public Transform m_TransA;
   public Transform m_TransB;
   
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   
      float QuatResult = UTGlobalMath.QuaternionDistance(m_TransA.rotation, m_TransB.rotation);
      
      print("Quat Result  " + QuatResult );
      
      float QuatResult2 = Quaternion.Dot(m_TransA.rotation, m_TransB.rotation);
      
      print("Quat Result2 " + QuatResult2 );
      
      float QuatAngle = UTGlobalMath.QuaternionDistanceAngle(m_TransA.rotation, m_TransB.rotation);
      
      print("Quat Angle  " + QuatAngle );
      
      Quaternion a = m_TransA.rotation * m_TransB.rotation;
      
      Quaternion b = UTGlobalMath.QuaternionMult(m_TransA.rotation, m_TransB.rotation);
      
      print("Quat mul a " + a + " Quat mul b " + b);
      
      
      
      Matrix4x4 matA = m_TransA.localToWorldMatrix;
         
      Matrix4x4 matB = UTGlobalMath.MatrixFromQuaternionPosLH(m_TransA.rotation, m_TransA.position);
      
      print("mat a \n" + matA );
      print("mat b \n" + matB );
      
      
      Matrix4x4 matZL = UTGlobalMath.ZFTMatrixFromQuaternionPosLH(m_TransA.rotation, m_TransA.position);
      Matrix4x4 matZR = UTGlobalMath.ZFTMatrixFromQuaternionPosRH(m_TransA.rotation, m_TransA.position);
         
      Matrix4x4 matUR = UTGlobalMath.MatrixFromQuaternionPosRH(m_TransA.rotation, m_TransA.position);
      
      print("mat Z L \n" + matZL );
      print("mat Z R \n" + matZR );
      print("mat U R \n" + matUR );
      
      
	}
}
