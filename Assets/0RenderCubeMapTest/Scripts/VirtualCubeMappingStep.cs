using UnityEngine;
using System.Collections;

public class VirtualCubeMappingStep : MonoBehaviour {

   // 가상 큐브 맵 중앙
   public Transform m_VirtualCubeCenter;

   // 시점에서 쐈을 때 충돌 시킬 레이어 (환경 맵핑 대상)
   public LayerMask m_RayLayer;

   // 가상 큐브 맵 중간에서 쐈을 때 충돌 시킬 레이어
   public LayerMask m_CubemapLayer;

   public float m_delay = 1f;

   void Start()
   {
      StartCoroutine(RayCast());
   }

   IEnumerator RayCast()
   {
      while (true)
      {
         yield return null;

         Vector3 viewVec = transform.forward;
         Vector3 reflVec = Vector3.zero;

         RaycastHit hit;

         RaycastHit cubePixel;


         // 1. 시점 벡터 방향으로 레이를 쏘아
         if (Physics.Raycast(transform.position, viewVec, out hit, 5f, m_RayLayer))
         {
            // 반사 벡터를 구한다.
            reflVec = Reflection(hit.normal, viewVec);

            // 뷰 벡터 방향 선분 (뷰와 뷰 벡터가 표면에 충돌한 점을 연결하는 선)
            Debug.DrawLine(transform.position, hit.point, Color.red);
            //yield return new WaitForSeconds(m_delay);
            //Debug.Break();

            // 표면 노멀 벡터
            Debug.DrawRay(hit.point, hit.normal, Color.green);
            //yield return new WaitForSeconds(m_delay);
            //Debug.Break();

            // 반사 벡터
            Debug.DrawRay(hit.point, reflVec, Color.blue);
            //yield return new WaitForSeconds(m_delay);
            //Debug.Break();

            // 큐브 중앙에서 반사 벡터 방향으로 레이를 쏴 준다. 
            // (반사 벡터가 잘 보이게 하기 위해 적당한 값을 곱하여 주었음)
            Debug.DrawRay(m_VirtualCubeCenter.position, reflVec * 10f, Color.blue);
            //yield return new WaitForSeconds(m_delay);
            Debug.Break();

            // 2. 가상 큐브 맵 중앙에서 반사 벡터 방향으로 레이를 쏜다.
            if (Physics.Raycast(m_VirtualCubeCenter.position, reflVec, out cubePixel,
               20f, m_CubemapLayer))
            {

               // 3. 시점 벡터와 환경 맵핑이 될 물체 표면의 교점에 색상을 적용한다.
               cubePixel.transform.position = hit.point;
               cubePixel.transform.localScale /= 50f;
            }
         }      
      
      }

   }


   /// <summary>
   /// 반사 벡터를 반환 한다.
   /// </summary>
   /// <param name="a_Normal"> 노멀 벡터 </param>
   /// <param name="a_InVec"> 뷰 벡터 </param>
   /// <returns> 반사 벡터 </returns>
   Vector3 Reflection(Vector3 a_Normal, Vector3 a_InVec)
   {
      Vector3 outVec = -Vector3.Dot(a_Normal, a_InVec) * a_Normal * 2f;
      Vector3 reflectionVec = outVec + a_InVec;

      return reflectionVec;
   }

}
