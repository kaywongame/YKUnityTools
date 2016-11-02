using UnityEngine;
using System.Collections;

public class RotationTest_2 : MonoBehaviour
{
   
   public Vector3 m_RotationPos;
   

   // Update is called once per frame
   void Update()
   {
      
      transform.RotateAround(m_RotationPos, Vector3.right, Time.deltaTime * 30);
      
   }
}
