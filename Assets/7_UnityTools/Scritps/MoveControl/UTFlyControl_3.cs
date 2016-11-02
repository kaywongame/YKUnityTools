using UnityEngine;
using System.Collections;
using UnityTools.Math;

//////////////////////////////////////////////////////////////////////////
/// Changed for Fly Mode
public class UTFlyControl_3: MonoBehaviour
{
   public float m_Speed = 2f;

   private Transform m_CameraTransform;

   void Start()
   {
      m_CameraTransform = Camera.main.transform;
   }


   // Update is called once per frame
   void Update()
   {
      if (Input.GetKeyUp(KeyCode.Z))
      {
         GetComponent<MouseLook>().enabled = false;
      }

      if (Input.GetKeyUp(KeyCode.X))
      {
         GetComponent<MouseLook>().enabled = true;
      }

      float upDownVal = 0f;

      if (Input.GetKey(KeyCode.Q))
      {
         upDownVal = 1f;
      }
      if (Input.GetKey(KeyCode.E))
      {
         upDownVal = -1f;
      }

      
      // 카메라의 월드상에서 방향을 고려하여 좌/우 전/후 방향을 얻어 온다
      Vector3 xVec = m_CameraTransform.right * Input.GetAxis("Horizontal");
      Vector3 yVec = m_CameraTransform.up * upDownVal;
      Vector3 zVec = m_CameraTransform.forward * Input.GetAxis("Vertical");

      // 이동 벡터를 카메라 방향으로 회전시켜줌
      Vector3 dirVec = xVec + yVec + zVec;

      // 정규화된 벡터를 구함.
      Vector3 moveVec = dirVec.normalized;

      transform.position += moveVec * Time.deltaTime * m_Speed;

#if UNITY_EDITOR
      // 월드 좌표계 위치를 X와 Z축으로 각 0.01, 0.02 만큼 씩 이동한 위치를 구하여.
      // 선이 겹쳐져 그려지는 것을 방지하기 위한 새로운 기준점으로 사용한다.
      Vector3 offsetPos = transform.position + new Vector3(0f, 0f, 0.01f);

      // 빨간색으로 정규화 되지 않은 X축 이동 방향 벡터를 그려준다.
      Debug.DrawLine(offsetPos, offsetPos + xVec, Color.red);
      offsetPos += new Vector3(0.01f, 0);

      // 파란색으로 정규화 되지 않은 Z축 이동 방향 벡터를 그려준다.
      Debug.DrawLine(offsetPos, offsetPos + zVec, Color.blue);
      offsetPos += new Vector3(0.01f, 0);

      // 자홍색으로 정규화 되지 않은 이동 방향 벡터를 그려준다.
      Debug.DrawLine(offsetPos, offsetPos + dirVec, Color.magenta);
      offsetPos += new Vector3(0.01f, 0);

      // 흰색으로 정규화 된 이동 벡터를 그려준다.
      Debug.DrawLine(transform.position, transform.position + moveVec, Color.white);
#endif
   }

   void OnDrawGizmos()
   {
      UTGlobalGizmosUtility.DrawArrowInLocal(Vector3.zero, Vector3.forward, transform, 1f,Color.yellow);
   }

}

