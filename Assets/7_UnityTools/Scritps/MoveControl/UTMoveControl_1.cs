using UnityEngine;
using System.Collections;

/// <summary>
/// 방향키와 마우스 조작으로 캐릭터를 움직이는 스크립트.
/// </summary>
public class UTMoveControl_1 : MonoBehaviour
{
   void Update ()
   {
      // 키보드나 조이스틱의 좌/우, 상/하 방향 입력을 얻어 온다.
      // 좌/우 입력을 xVec에 저장한다. 좌측은x 값이 -1~0 값, 우측은 0~1 값이 된다. 
      Vector3 xVec = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
      // 상/하 입력을 zVec에 저장한다. 좌측은z 값이 -1~0 값, 우측은 0~1 값이 된다.
      Vector3 zVec = new Vector3(0, Input.GetAxis("Vertical"), 0);

      Vector3 dirVec = xVec + zVec;

      // 정규화된 벡터를 구함.
      Vector3 moveVec = dirVec.normalized;

      // 기종 및 각 프레임을 그리는 시간에 상관업이 일정한 속도로 
      // 움직이기 위해 프레임간 경과 시간을 곱해준다.
      transform.position += moveVec * Time.deltaTime;

      // #if UNITY_EDITOR 와 #endif 사이의 내용은 유니티 에디터에서만  
      // 실행되며 유니티 최종 빌드에서는 포함 되지 않는다.
#if UNITY_EDITOR
      // 월드 좌표계 위치를 X와 Z축으로 각 0.01, 0.02 만큼 씩 이동한 위치를 구하여.
      // 선이 겹쳐져 그려지는 것을 방지하기 위한 새로운 기준점으로 사용한다.
      Vector3 offsetPos = transform.position + new Vector3(0.02f, 0, 0.02f);
      Vector3 offsetPos2 = transform.position + new Vector3(-0.02f, 0, -0.02f);

      // 빨간색으로 정규화 되지 않은 X축 이동 방향 벡터를 그려준다.
      Debug.DrawLine(offsetPos2, offsetPos2 + xVec, Color.red);

      // 파란색으로 정규화 되지 않은 Z축 이동 방향 벡터를 그려준다.
      Debug.DrawLine(offsetPos, offsetPos + zVec, Color.blue);

      // 자홍색으로 정규화 되지 않은 이동 방향 벡터를 그려준다.
      Debug.DrawLine(offsetPos, offsetPos + dirVec, Color.magenta);

      // 흰색으로 정규화 된 이동 벡터를 그려준다.
      Debug.DrawLine(transform.position, transform.position + moveVec, Color.white);
#endif
   }
}




