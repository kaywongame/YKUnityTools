/// <summary>
/// Gimbol Lock Test
/// 
/// by Yunkyu Choi
/// Last Update: 2011/10/27
/// </summary>
using UnityEngine;
using System.Collections;


public class UTMouseRotationGimbalLockTest : MonoBehaviour
{
   public enum RotationType { 
      EULER, 
      QUATERNION,
   };

   public RotationType m_RotationType = RotationType.EULER;

   float m_RotXAcc = 0f;
   float m_RotYAcc = 0f;
   float m_RotZAcc = 0f;

   float m_RotX = 0f;
   float m_RotY = 0f;
   float m_RotZ = 0f;

   void Update()
   {
      // 비누적 회전 각도
      // X축에 대한 회전 (C키, 90도 씩 )
      m_RotX = (Input.GetKeyDown(KeyCode.C) ? 90f : 0f);
      // Y축에 대한 회전 (마우스 X)
      m_RotY = Input.GetAxis("Mouse X");
      // Z축에 대한 회전 (마우스 Y)
      m_RotZ = Input.GetAxis("Mouse Y");


      // 누적된 회전 각도
      // X축에 대한 회전 (C키, 90도 씩 )
      m_RotXAcc += ( Input.GetKeyDown(KeyCode.C) ? 90f : 0f ) ;
      // Y축에 대한 회전 (마우스 X)
      m_RotYAcc += Input.GetAxis("Mouse X") ;
      // Z축에 대한 회전 (마우스 Y)
      m_RotZAcc += Input.GetAxis("Mouse Y") ;


      switch (m_RotationType)
      {
         case RotationType.EULER:
            // 짐벌락 ------------------------------------------
            transform.eulerAngles = new Vector3(m_RotXAcc, m_RotYAcc, m_RotZAcc);
            //transform.Rotate(new Vector3(m_RotX, m_RotY, m_RotZ), Space.Self);
            break;

         case RotationType.QUATERNION:
            // 쿼터니언 -------------------------------------------
            
            // 쿼터니언 만들기
            Quaternion rotX = Quaternion.AngleAxis(m_RotX, Vector3.right);
            Quaternion rotY = Quaternion.AngleAxis(m_RotY, Vector3.up);
            Quaternion rotZ = Quaternion.AngleAxis(m_RotZ, Vector3.forward);

            // 쿼터니언 회전 적용
            transform.rotation *= rotZ;
            transform.rotation *= rotX;
            transform.rotation *= rotY;
            break;

         default:
            break;
      }

      print("X : " + m_RotXAcc + " Y: " + m_RotYAcc + " Z:" + m_RotZAcc);

   }

}


