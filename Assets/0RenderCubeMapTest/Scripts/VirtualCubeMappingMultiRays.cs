using UnityEngine;
using System.Collections;

public class VirtualCubeMappingMultiRays : MonoBehaviour {

   // 가상 큐브 맵 중앙
   public Transform m_VirtualCubeCenter;

   // 시점에서 쐈을 때 충돌 시킬 레이어 (환경 맵핑 대상)
   public LayerMask m_RayLayer;

   // 가상 큐브 맵 중간에서 쐈을 때 충돌 시킬 레이어
   public LayerMask m_CubemapLayer;

   // Use this for initialization
   void Start () {
            
   }
   
   // Update is called once per frame
   void Update () {

      Vector3 viewVec = transform.forward;
      Vector3 reflVec = Vector3.zero;

      RaycastHit hit;

      RaycastHit cubePixel;

      // 빠른 실행을 위해 여러번 레이를 쏜다.
      for (int x = -1; x < 2; x++)
      {
         for (int y = -1; y < 2; y++)
         {
            viewVec += new Vector3(x * 0.01f, y * 0.01f, 0);
            // 1. 시점 벡터 방향으로 레이를 쏘아
            if (Physics.Raycast(transform.position, viewVec, out hit, 5f, m_RayLayer))
            {
               // 반사 벡터를 구한다.
               reflVec = Reflection(hit.normal, viewVec);

               Debug.DrawLine(transform.position, hit.point, Color.red);
               Debug.DrawRay(hit.point, hit.normal, Color.green);
               Debug.DrawRay(hit.point, reflVec, Color.blue);

               // 2. 가상 큐브 맵 중앙에서 반사 벡터 방향으로 레이를 쏜다.
               if (Physics.Raycast(m_VirtualCubeCenter.position, reflVec, out cubePixel,
                  20f, m_CubemapLayer))
               {
                  Debug.DrawLine(m_VirtualCubeCenter.position, cubePixel.point,
                     Color.blue, 2.0f);

                  // 3. 시점 벡터와 환경 맵핑이 될 물체 표면의 교점에 색상을 적용한다.
                  cubePixel.transform.position = hit.point;
                  cubePixel.transform.localScale /= 50f;
               }
            }      
         }// for y
      }// for x
      
      
   }

   /// <summary>
   /// 반사 벡터를 반환 한다.
   /// </summary>
   /// <param name="a_Normal"> 노멀 벡터 </param>
   /// <param name="a_InVec"> 뷰 벡터 </param>
   /// <returns> 반사 벡터 </returns>
   Vector3 Reflection(Vector3 a_Normal, Vector3 a_InVec)
   {
      //Quaternion approachRotation = Quaternion.FromToRotation(currentDirection, contact.normal);
      //Vector3 reflectDirection = (approachRotation * contact.normal) * -1;

      Vector3 outVec = -Vector3.Dot(a_Normal, a_InVec) * a_Normal * 2f;
      Vector3 reflectionVec = outVec + a_InVec;

      return reflectionVec;
   }

}
