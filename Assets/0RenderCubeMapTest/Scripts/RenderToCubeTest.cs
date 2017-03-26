using UnityEngine;
using System.Collections;

// 카메라 영상을 큐브 맵으로 출력하는 클레스

public class RenderToCubeTest : MonoBehaviour
{
   // 큐브맵을 생성 할 시 사용/ 할 카메라
   public Camera m_Cam;

   // 렌더 텍스쳐로 카메라 영상을 출력 할 시 결과를 저장 할 렌더 텍스쳐
   
   public RenderTexture m_RenderTexture;
   // 큐브 맵으로 카메라 영상을 출력 할 시 결과를 저장할 큐브 맵
   public Cubemap m_CubeMap;

   // 큐브 맵으로 출력 할지 렌더 텍스쳐 큐브 맵으로 출력 할 지 정한다.
   public bool m_isCubeMapMode = true;


   void Update()
   {
      // 큐브 맵 모드이면
      if (m_isCubeMapMode)
      {
         // 큐브 맵에 m_Cam에서 렌더링한 큐브 6면 영상을 출력 한다.
         m_Cam.GetComponent<Camera>().RenderToCubemap(m_CubeMap);
      }
      else // 렌더 텍스쳐 모드이면
      {
         // 렌더 텍스쳐 큐브 맵에 큐브 6면 영상을 출력 한다.
         m_Cam.GetComponent<Camera>().RenderToCubemap(m_RenderTexture);
      }
   }
}

