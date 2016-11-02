using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))]
public class UTGUIText : MonoBehaviour
{
   public string m_Text = "";

   public Vector3 m_ViewportOffset = Vector3.zero;
   
   // 부모 게임오브젝트의 월드 좌표계를 저장 할 변수
   private Vector3 m_WorldPos;
   
   // 문자를 출력 할 뷰포트 좌표계를 저장 할 변수 
   private Vector3 m_ViewportPos;

   void Reset()
   {
      m_Text = transform.parent.name;
      GetComponent<GUIText>().alignment = TextAlignment.Center;
      GetComponent<GUIText>().anchor = TextAnchor.UpperCenter;
   }

   /*
   void LateUpdate()
   {
      OnDrawGizmos();
   }
   */

   void OnDrawGizmos()
   {
      
      Camera cam;
      
     // 실행 중인 경우는 메인 카메라를 기준으로
      if (Application.isPlaying)
      {
         cam = Camera.main;
      }
      else // 비 실행 중에는 씬뷰 카메라를 기준으로 한다.
      {
         cam = Camera.current;
      }

      // 부모 게임오브젝트의 월드 좌표계를 얻어 온다
      m_WorldPos = transform.parent.position;
      
      // 게임 오브젝트가 카메라 뒤쪽에 있을 경우 GUI Label을 그리지 않는다.
     float distFromCamPlane =
        cam.transform.InverseTransformPoint(transform.position).z;

     if (distFromCamPlane < 0)		return;
      
      
      // 부모 게임오브젝트의 뷰포트 좌표계를 얻어 온다.
      m_ViewportPos = cam.WorldToViewportPoint(m_WorldPos);
      
      // Offset을 더해서 출력할 위치를 정해준다. 
      transform.position = m_ViewportPos + m_ViewportOffset;
      
      // 출력될 글자를 정해 준다.
      GetComponent<GUIText>().text = m_Text;
   }
}

