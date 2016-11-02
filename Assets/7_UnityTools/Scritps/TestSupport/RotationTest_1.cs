using UnityEngine;
using System.Collections;

public class RotationTest_1 : MonoBehaviour
{
   public Space m_Space;

   // Update is called once per frame
   void Update()
   {
      transform.Rotate(Time.deltaTime * 30, 0, 0, m_Space);
   }
}
